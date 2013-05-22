using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNAView
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private KeyboardState _keyboardState;
        private MouseState _mouseState;

        private Sprite _centralBar;

        private Bat _batP1;
        private Bat _batP2;
        private Ball _ball;

        private SpriteFont _scoreFont;

        private bool _isPaused;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Créé et initialise toutes les variables du jeu (balle, raquettes, etc...)
        /// </summary>
        protected override void Initialize()
        {
            _centralBar = new Sprite();

            _ball = new Ball(Window.ClientBounds.Width, Window.ClientBounds.Height);
            _ball.Initialize();

            _batP1 = new Bat(Window.ClientBounds.Width, Window.ClientBounds.Height, 1);
            _batP1.Initialize();

            _batP2 = new Bat(Window.ClientBounds.Width, Window.ClientBounds.Height, 2);
            _batP2.Initialize();

            _isPaused = true;

            base.Initialize();
        }

        /// <summary>
        /// Charge tout le contenu du jeu (images, spritefont, etc..)
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _centralBar.LoadContent(Content, "barre");
            _centralBar.Position = new Vector2(Window.ClientBounds.Width / 2 - _centralBar.Texture.Width / 2, 0);

            _ball.LoadContent(Content, "ball");
            _batP1.LoadContent(Content, "bat");
            _batP2.LoadContent(Content, "bat");

            _scoreFont = Content.Load<SpriteFont>("scoreText");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Met le jeu à jour en appelant les méthodes de gestion de clavier
        /// et de déplacement de chaque élément du jeu
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // On récupère les états du clavier et de la souris.
            _keyboardState = Keyboard.GetState();
            _mouseState = Mouse.GetState();

            // On gère le fait que le jeu soit en pause pour permettre au joueur
            // de se préparer avant de commencer
            if (!_isPaused)
            {
                _ball.Update(gameTime, _batP1.CollisionRectangle, _batP2.CollisionRectangle);
                _batP1.HandleInput(_keyboardState, _mouseState);
                _batP2.HandleInput(_keyboardState, _mouseState);

                _batP1.Update(gameTime);
                _batP2.Update(gameTime);

                // Verifie si la balle est passé derrière une raquette et agit en fonction
                CheckIfBallOut();
            }
            else
            {
                // Si on est en pause alors on attend que espace soit appuyé pour démarrer
                if (_keyboardState.IsKeyDown(Keys.Space))
                {
                    _isPaused = false;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Vérifie si la balle est sortie du jeu.
        /// Si c'est le cas, en fonction du coté où elle est sortie, on rajoute un point au bon joueur.
        /// On remet ensuite tout en place pour une autre partie.
        /// </summary>
        private void CheckIfBallOut()
        {
            if (_ball.Position.X <= 0)
            {
                _batP2.Score++;
                _ball.Initialize();
                _ball.Position = new Vector2(Window.ClientBounds.Width / 2 - _ball.Texture.Width / 2,
                                             Window.ClientBounds.Height / 2 - _ball.Texture.Height / 2);
                _isPaused = true;
            }
            else if (_ball.Position.X >= Window.ClientBounds.Width - _ball.Texture.Width)
            {
                _batP1.Score++;
                _ball.Initialize();
                _ball.Position = new Vector2(Window.ClientBounds.Width / 2 - _ball.Texture.Width / 2,
                                             Window.ClientBounds.Height / 2 - _ball.Texture.Height / 2);
                _isPaused = true;
            }
        }

        /// <summary>
        /// Dessine tout le jeu en utilisant un seul spriteBatch.Begin() et End().
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // On ouvre une seule fois le spriteBatch pour toutes les opérations de dessin.
            spriteBatch.Begin();

            // On dessine la barre du milieu en tout premier (pour que les autres éléments puissent passer dessus)
            _centralBar.Draw(spriteBatch, gameTime);

            // On dessine ensuite le score en calculant au préalable la position où le placer.
            Vector2 scoreP1Size = _scoreFont.MeasureString(_batP1.Score.ToString());
            Vector2 scoreP1Position = new Vector2(Window.ClientBounds.Width / 4 - scoreP1Size.X / 2,
                                                  scoreP1Size.Y);
            spriteBatch.DrawString(_scoreFont, _batP1.Score.ToString(), scoreP1Position, Color.White);

            Vector2 scoreP2Size = _scoreFont.MeasureString(_batP2.Score.ToString());
            Vector2 scoreP2Position = new Vector2(3 * Window.ClientBounds.Width / 4 - scoreP2Size.X / 2,
                                                  scoreP2Size.Y);
            spriteBatch.DrawString(_scoreFont, _batP2.Score.ToString(), scoreP2Position, Color.White);

            // On dessine ensuite les élements du jeu (balle, raquettes)
            _batP1.Draw(spriteBatch, gameTime);
            _batP2.Draw(spriteBatch, gameTime);
            _ball.Draw(spriteBatch, gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}