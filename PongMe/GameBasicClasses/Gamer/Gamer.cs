using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.Obstacles;
using GameBasicClasses.Obstacles.Paddle;
using GameBasicClasses.MVC;
using GameBasicClasses.Options;

namespace GameBasicClasses.Gamer
{
    public abstract class Gamer:Controller
    {
        /// <summary>
        /// Points du joueur durant une partie
        /// </summary>
        private int points;
        public int Points
        {
            get { return points; }
        }

        public void resetPoints()
        {
            this.points = 0;
        }

        public void incPoints()
        {
            this.points++;
        }

        protected GamerOptions commands;

        protected Paddle paddle;
        public Paddle Paddle { get { return this.paddle; } }

        public Gamer(Keys up, Keys down, Paddle paddle)
        {
            commands = new GamerOptions(up, down);
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
