using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.Obstacles;

namespace GameBasicClasses.BasicClasses
{
    public abstract class Gamer
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

        /// <summary>
        /// Touches utilisées par le joueur
        /// </summary>
        protected Keys up;
        protected Keys down;

        protected Paddle paddle;
        public Paddle Paddle { get { return this.paddle; } }

        public Gamer(Keys up, Keys down, Paddle paddle)
        {
            this.up = up;
            this.down = down;
            this.paddle = paddle;
            this.points = 0;
        }

        public Gamer()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Contient le code faisant bouger la raquette.
        /// Un évnement est envoyé depuis la MainFrame
        /// </summary>
        public abstract void run(object sender, KeyEventArgs e);
    }
}
