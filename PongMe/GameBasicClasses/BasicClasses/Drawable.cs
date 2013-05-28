using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GameBasicClasses.BasicClasses
{
    public class Drawable
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

        public Rectangle bounds;

        public Vector Position
        {
            get { return new Vector(this.bounds.X, this.bounds.Y); }
            set { this.bounds.X = (int)value.X; this.bounds.Y = (int)value.Y; }
        }

        public Image Image { get; set; }
        protected Image initialImage;

        private PictureBox box;
        public PictureBox Box
        {
            get
            {
                if (this.Image != null)
                {
                    box.Image = this.Image;
                    box.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    box.BackColor = this.Color;
                }
                box.Size = this.bounds.Size;
                box.Location = new Point((int)this.Position.X, (int)this.Position.Y);
                return box;
            }
            set { box = value; }
        }

        public Color Color { get; set; }
        protected Color initialColor;

        public Drawable()
        {
            this.ClientSize = new Size(1000, 600);
            this.bounds = new Rectangle();
            this.Position = Vector.Zero();
            this.Image = null;
            this.initialImage = this.Image;
            this.Box = new PictureBox();
            this.Color = Color.Blue;
            this.initialColor = this.Color;
        }
    }
}
