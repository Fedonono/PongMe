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

        private Rectangle bounds;
        public Rectangle Bounds
        {
            get { return this.bounds; }
            set
            {
                this.bounds = value;
                this.box.Size = this.Bounds.Size;
            }
        }
        protected Rectangle initialBounds;

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
                    this.box.Image = this.Image;
                    this.box.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    this.box.BackColor = this.Color;
                }
                this.box.Size = this.bounds.Size;
                this.box.Location = new Point((int)this.Position.X, (int)this.Position.Y);
                return this.box;
            }
            set
            {
                this.box = value;
            }
        }
        protected PictureBox initialBox;

        public Color Color { get; set; }
        protected Color initialColor;

        public Drawable()
        {
            this.ClientSize = new Size(1000, 600);
            this.Box = new PictureBox();
            this.Bounds = new Rectangle();
            this.initialBounds = this.Bounds;
            this.Position = Vector.Zero();
            this.Image = null;
            this.initialImage = this.Image;
            this.initialBox = this.Box;
            this.Color = Color.Blue;
            this.initialColor = this.Color;
        }
    }
}
