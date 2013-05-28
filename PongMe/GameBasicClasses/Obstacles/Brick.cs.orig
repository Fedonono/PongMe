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
<<<<<<< HEAD
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

=======
        /*
         * Sur ses bornes
         */
>>>>>>> 1a9c128dd231e9c2d8f1caf5a16b3c65e91aaf03
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
