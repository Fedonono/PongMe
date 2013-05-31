using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameBasicClasses.Options
{
    public class GamerOptions
    {
        private Keys up;
        private Keys down;

        private static Keys stop = Keys.Escape;
        private static Keys pause = Keys.P;
        private static Keys launch = Keys.Space;

        private static LinkedList<Keys> taken = new LinkedList<Keys>();

        public GamerOptions(Keys up, Keys down)
        {
            this.Up = up;
            this.Down = down;
        }

        public Keys Up
        {
            set
            {
                //if (taken.Find(value) == null)
                //{
                    this.up = value;
                    //taken.AddLast(value);
                //}
            }

            get
            {
                return this.up;
            }
        }

        public Keys Down
        {
            set
            {
                //if (taken.Find(value) == null)
                //{
                    this.down = value;
                  //  taken.AddLast(value);
                //}
            }

            get
            {
                return this.down;
            }
        }

        public static Keys Stop {
            set
            {
                if (taken.Find(value) == null)
                {
                    stop = value;
                    taken.AddLast(value);
                }
            }

            get
            {
                return stop;
            }
        }

        public static Keys Pause
        {
            set
            {
                if (taken.Find(value) == null)
                {
                    pause = value;
                    taken.AddLast(value);
                }
            }

            get
            {
                return pause;
            }
        }

        public static Keys Launch
        {
            set
            {
                if (taken.Find(value) == null)
                {
                    pause = value;
                    taken.AddLast(value);
                }
            }

            get
            {
                return launch;
            }
        }

        public override String ToString()
        {
            return String.Format("{0} to go up - {1} to go down - {2} to stop the game - {3} to pause the game", 
                this.Up, this.Down, Stop, Pause);
        }

        public void swapCommands()
        {
            Keys tmp = this.up;
            this.up = this.down;
            this.down = tmp;
        }
    }
}
