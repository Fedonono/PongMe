using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GameView
{
    public class MenuItem : LinkLabel
    {
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = System.Drawing.SystemColors.ControlDark;
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = Color.Transparent;
        }

        public MenuItem() : base()
        {
            this.ActiveLinkColor = System.Drawing.Color.White;
            this.AutoSize = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkColor = System.Drawing.Color.White;
        }
    }
}
