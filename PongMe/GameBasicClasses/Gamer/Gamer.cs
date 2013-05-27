using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.Obstacles;
using GameBasicClasses.Obstacles.Paddle;
<<<<<<< HEAD
using GameBasicClasses.Options;
=======
using GameBasicClasses.MVC;
>>>>>>> 5dc767122a80e3da5bd96d8957cc00c59c4df4f2

namespace GameBasicClasses.Gamer
{
    public abstract class Gamer:Controller
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

        public Gamer(Keys up, Keys down, Paddle paddle)
        {
<<<<<<< HEAD
            this.Left = left;
            this.options = new GamerOptions(up, down);
            if (paddle.Left != left)
            {
                paddle.Left = left;
            }
=======
            this.up = up;
            this.down = down;
>>>>>>> 5dc767122a80e3da5bd96d8957cc00c59c4df4f2
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
