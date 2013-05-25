using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using GameBasicClasses.MVC;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles
{
    public abstract class Obstacle
    {
        private int clientWidth;
        public int ClientWidth
        {
            get
            {
                return this.clientWidth;
            }
            set
            {
                if (value > 0)
                {
                    this.clientWidth = value;
                }
                else
                {
                    this.clientWidth = 1000;
                }
            }
        }

        private int clientHeight;
        public int ClientHeight
        {
            get
            {
                return this.clientHeight;
            }
            set
            {
                if (value > 0)
                {
                    this.clientHeight = value;
                }
                else
                {
                    this.clientHeight = 600;
                }
            }
        }

        private Size clientSize;
        public virtual Size ClientSize
        {
            get
            {
                return this.clientSize;
            }
            set
            {
                this.clientSize = value;
                this.ClientWidth = this.clientSize.Width;
                this.ClientHeight = this.clientSize.Height;
            }
        }

        public Obstacle(int clientWidth, int clientHeight)
        {
            this.ClientWidth = clientWidth;
            this.ClientHeight = clientHeight;
        }

        public abstract bool contains(Ball b);
    }
}
