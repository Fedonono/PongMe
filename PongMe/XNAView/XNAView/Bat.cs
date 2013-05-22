using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNAView
{
    public class Bat : Sprite
    {
        // Les dimensions de la fenêtre de jeu
        private int _screenHeight;
        private int _screenWidth;

        // Le score du joueur
        private int _score;
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        /// <summary>
        /// Récupère le rectangle qui entoure la raquette
        /// pour permettre la gestion des collisions
        /// </summary>
        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        private int _playerNumber;

        /// <summary>
        /// Crée une raquette en fournissant les dimensions de la fenêtre de jeu.
        /// </summary>
        /// <param name="screenWidth">Largeur de la fenêtre</param>
        /// <param name="screenHeight">Hauteur de la fenêtre</param>
        /// <param name="playerNumber">Le numero du joueur que l'on est en train de créer (1 ou 2)</param>
        public Bat(int screenWidth, int screenHeight, int playerNumber)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;

            _playerNumber = playerNumber;
        }

        /// <summary>
        /// Initialise les variables nécessaires à la raquette.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            _score = 0;
        }

        /// <summary>
        /// Charge l'image de la raquette
        /// </summary>
        /// <param name="content">Le content manager à utiliser pour charger l'image</param>
        /// <param name="assetName">L'asset name de l'image de raquette à charger</param>
        public override void LoadContent(ContentManager content, string assetName)
        {
            base.LoadContent(content, assetName);

            // En fonction du joueur que l'on est en train de charger,
            // on place la texture d'un coté ou de l'autre de la fenêtre
            if (_playerNumber == 1)
            {
                Position = new Vector2(10, _screenHeight / 2 - Texture.Height / 2);
            }
            else if (_playerNumber == 2)
            {
                Position = new Vector2(_screenWidth - 10 - Texture.Width, _screenHeight / 2 - Texture.Height / 2);
            }
        }

        /// <summary>
        /// Gère les entrées clavier de l'utilisateur en fonction du joueur concerné
        /// </summary>
        /// <param name="keyboardState">L'état du clavier</param>
        /// <param name="mouseState">L'état de la souris</param>
        public override void HandleInput(KeyboardState keyboardState, MouseState mouseState)
        {
            if (_playerNumber == 1)
            {
                if (keyboardState.IsKeyDown(Keys.Z))
                {
                    Direction = -Vector2.UnitY;
                    Speed = 0.3f;
                }
                else if (keyboardState.IsKeyDown(Keys.S))
                {
                    Direction = Vector2.UnitY;
                    Speed = 0.3f;
                }
                else
                {
                    Speed = 0;
                }
            }
            else if (_playerNumber == 2)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    Direction = -Vector2.UnitY;
                    Speed = 0.3f;
                }
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    Direction = Vector2.UnitY;
                    Speed = 0.3f;
                }
                else
                {
                    Speed = 0;
                }
            }
        }

        /// <summary>
        /// Vérifie que la raquette ne sort pas de l'écran et l'arrète si c'est le cas
        /// </summary>
        /// <param name="gameTime">Etat du temps à la frame</param>
        public override void Update(GameTime gameTime)
        {
            if (Position.Y <= 0 && Direction.Y < 0)
                Speed = 0;
            if (Position.Y >= _screenHeight - Texture.Height && Direction.Y > 0)
                Speed = 0;

            base.Update(gameTime);
        }
    }
}