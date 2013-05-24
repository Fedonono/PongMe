using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.MVC;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles
{
    public class Wall : Obstacle
    {
        private int health;
        public int Health
        {
            get { return health; }
            set {
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

        public Wall(int health, int clientWidth, int clientHeight) : base(clientWidth,clientHeight)
        {
            this.Health = health;
        }

        public override bool contains(Ball b)
        {
            throw new System.NotImplementedException();
        }

        public void touched()
        {
            this.health--;
        }
    }
}
