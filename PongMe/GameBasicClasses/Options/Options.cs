using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.MVC;
using System.Drawing;

namespace GameBasicClasses.Options
{
    public class Options : Model
    {
        private Size defaultClientDim;
        public Size DefaultClientDim
        {
            get;
            set
            {
                /*
                 * Prevent new Size(a, b)
                 */
                this.clientDim.Width = value.Width;
                this.clientDim.Height = value.Height;
            }
        }

        public Options()
        {
            this.DefaultClientDim = new Size(1000, 600);
        }

    }
}
