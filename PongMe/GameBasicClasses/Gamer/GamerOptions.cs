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
                this.up = value;
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
                this.down = value;
            }

            get
            {
                return this.down;
            }
        }

        public static Keys Stop {
            set
            {
                stop = value;
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
                pause = value;
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
                launch = value;
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

        public void SwapCommands()
        {
            Keys tmp = this.up;
            this.up = this.down;
            this.down = tmp;
        }

        public GamerOptions Clone()
        {
            return new GamerOptions(this.Up, this.Down);
        }
    }
}
