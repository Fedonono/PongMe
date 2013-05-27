using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameBasicClasses.Options
{
    class GamerOptions
    {
        private Keys up;
        private Keys down;
        private String pseudo;

        public GamerOptions(Keys up, Keys down) 
        {
            this.up = up;
            this.down = down;
            this.pseudo = "Default";
        }

        public Keys UpKey()
        {
            return this.up;
        }

        public static Keys EscapeKey()
        {
            return Keys.Escape;
        }

        public Keys DownKey()
        {
            return this.down;
        }

        public override String ToString()
        {
            return String.Format("{0}, your commands are : {1} to go up and {2} to go down", this.pseudo, this.up, this.down);
        }
    }
}
