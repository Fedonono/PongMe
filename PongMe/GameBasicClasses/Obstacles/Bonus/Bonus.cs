using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.MVC;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles.Bonus
{
    public class Bonus : Obstacle
    {
        private int timeout;
        public int Timeout
        {
            get { return timeout; }
            set {
                if (value <= 0)
                {
                    value = 1;
                }
                timeout = value;
            }
        }

        public Bonus(int clientWidth, int clientHeight, int timeout) : base(clientWidth, clientHeight)
        {
            this.Timeout = timeout;
        }

        public override bool contains(Ball b)
        {
            throw new System.NotImplementedException();
        }
    }
}
