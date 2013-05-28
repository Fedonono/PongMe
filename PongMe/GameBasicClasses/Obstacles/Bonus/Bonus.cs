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
                    value = 5;
                }
                timeout = value;
            }
        }

        public Bonus(int clientWidth, int clientHeight, int timeout)
        {
            this.ClientHeight = clientHeight;
            this.ClientWidth = clientWidth;
            this.Timeout = timeout;
        }

    }
}
