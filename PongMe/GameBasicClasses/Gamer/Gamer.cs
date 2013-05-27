using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.Obstacles;
using GameBasicClasses.Obstacles.Paddle;
using GameBasicClasses.Options;

namespace GameBasicClasses.Gamer
{
    public abstract class Gamer
    {
        /// <summary>
        /// Points du joueur durant une partie
        /// </summary>
        private int points;
        public int Points { get; }

        public void resetPoints()
        {
            this.points = 0;
        }

        public void incPoints()
        {
            this.points++;
        }


        private GamerOptions options;

        /// <summary>
        /// Touches utilisées par le joueur
        /// </summary>

        protected Paddle paddle;
        public Paddle Paddle { get { return this.paddle; } }

        public bool Left { get; set; }

        public Gamer(bool left, Keys up, Keys down, Paddle paddle)
        {
            this.Left = left;
            this.options = new GamerOptions(up, down);
            if (paddle.Left != left)
            {
                paddle.Left = left;
            }
            this.paddle = paddle;
            this.points = 0;
        }

        /// <summary>
        /// Contient le code faisant bouger la raquette.
        /// Un évnement est envoyé depuis la MainFrame
        /// </summary>
        public abstract void run(Keys e);
    }
}
