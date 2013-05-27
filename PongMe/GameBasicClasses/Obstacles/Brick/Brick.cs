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

        public Brick(int clientWidth, int clientHeight, int health) : base(clientWidth, clientHeight)
        {
            this.Health = health;
        }

        public override bool contains(BasicClasses.Ball b)
        {
            throw new NotImplementedException();
        }

        public void touched()
        {
            this.health--;
        }
    }
}
