using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBasicClasses.Obstacles
{
    /// <summary>
    /// Brique apparaissant dans la zone de jeu.
    /// Peut être détruite.
    /// </summary>
    public class Brick : Obstacle
    {
        private int health;
        public int Health
        {
            get { return health; }
            set
            {
                if (value > 0)
                {
                    health = value;
                }
                else
                {
                    health = 1;
                }
            }
        }

        public Brick(int health)
        {
            this.Health = health;
        }

        public void touched()
        {
            this.health--;
        }
    }
}
