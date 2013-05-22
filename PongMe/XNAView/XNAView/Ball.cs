using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace XNAView
{
    public class Ball : Sprite
    {
        // Les dimensions de la fenêtre de jeu
        private int _screenHeight;
        private int _screenWidth;

        /// <summary>
        /// Crée une balle et renseigne les dimensions de la fenêtre
        /// </summary>
        /// <param name="screenWidth">Largeur de la fenêtre</param>
        /// <param name="screenHeight">Longueur de la fenêtre</param>
        public Ball(int screenWidth, int screenHeight)
        {
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
        }

        /// <summary>
        /// Met une direction par défaut (en diagonale bas droite) et une vitesse par défaut
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Direction = new Vector2(1, 1);
            Speed = 0.2f;
        }

        /// <summary>
        /// Charge l'image de la balle donnée en paramêtre
        /// </summary>
        /// <param name="content">Le content manager avec lequel charger l'image</param>
        /// <param name="assetName">Le nom de l'image à charger pour la balle</param>
        public override void LoadContent(ContentManager content, String assetName)
        {
            base.LoadContent(content, assetName);
            Position = new Vector2(_screenWidth / 2 - Texture.Width / 2, _screenHeight / 2 - Texture.Height / 2);
        }

        /// <summary>
        /// Méthode Update spécifique à la balle.
        /// Fait rebondir la balle sur les bords haut et bas de l'écran
        /// et sur les raquettes des joueurs.
        /// Lorsque les modifications de direction et de vitesse sont faites,
        /// on appelle l'Update parent (de la classe Sprite) pour déplacer la balle.
        /// </summary>
        /// <param name="gameTime">Objet de temps relatif à la frame en cours</param>
        /// <param name="batRectangleP1">Le rectangle de collision du joueur 1</param>
        /// <param name="batRectangleP2">Le rectangle de collision du joueur 2</param>
        public void Update(GameTime gameTime, Rectangle batRectangleP1, Rectangle batRectangleP2)
        {
            // On fait rebondir la balle si elle touche le haut ou le bas de l'écran
            if ((Position.Y <= 0 && Direction.Y < 0)
                || (Position.Y > _screenHeight - Texture.Height && Direction.Y > 0))
            {
                Direction = new Vector2(Direction.X, -Direction.Y);
            }

            // Si la balle va vers un joueur et qu'elle touche la raquette dudit joueur,
            // on la fait changer de sens et on la fait accélérer
            if ((Direction.X < 0 && batRectangleP1.Contains((int)Position.X, (int)Position.Y + Texture.Height / 2))
                || (Direction.X > 0 && batRectangleP2.Contains((int)Position.X + Texture.Width, (int)Position.Y + Texture.Height / 2)))
            {
                Direction = new Vector2(-Direction.X, Direction.Y);
                Speed += 0.05f;
            }

            base.Update(gameTime);
        }
    }
}
