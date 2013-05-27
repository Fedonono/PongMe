using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameBasicClasses.MVC;
using GameBasicClasses.BasicClasses;
using System.Windows.Forms;

namespace GameBasicClasses.Obstacles.Paddle
{
    public class Paddle : Obstacle
    {
        public bool Left { get; set; }

        public override Size ClientSize
        {
            get
            {
                return base.ClientSize;
            }
            set
            {
                base.ClientSize = value;
                if (!this.Left)
                {
                    this.Position = new Vector(this.ClientWidth - this.bounds.Width - 7, this.Position.Y);
                }
            }
        }

        public Paddle(bool left, Color color, Image image, int width, int height, int speed, int clientWidth, int clientHeight)
        {
            this.ClientWidth = clientWidth;
            this.ClientHeight = clientHeight;
            if (width <= 0 || width >= this.ClientWidth)
            {
                width = 14;
            }
            if (height <= 0 || height >= this.ClientHeight)
            {
                height = 60;
            }
            
            Vector paddlePosition;
            if (left)
            {
                paddlePosition = new Vector(2, 0);
            }
            else
            {
                paddlePosition = new Vector(this.ClientWidth - width - 7, 0);
            }
            this.Direction = new Vector(0, 10);
            this.Position = paddlePosition;
            this.bounds = new Rectangle((int)this.Position.X, (int)this.Position.Y, width, height);
            this.Speed = speed;
            this.Color = color;
            this.Image = image;
            this.initialImage = this.Image;
            this.Left = left;
        }

        public void down()
        {
            if (this.Position.Y + this.bounds.Height + this.Speed <= this.ClientHeight)
            {
                this.Position = new Vector(this.Position.X, this.Position.Y + this.Speed);
            }
            else
            {
                this.Position = new Vector(this.Position.X, this.ClientHeight - this.bounds.Height);
            }
        }

        public void up()
        {
            if (this.Position.Y - this.Speed >= 0)
            {
                this.Position = new Vector(this.Position.X, this.Position.Y - this.Speed);
            }
            else
            {
                this.Position = new Vector(this.Position.X, 0);
            }
        }
    }
}