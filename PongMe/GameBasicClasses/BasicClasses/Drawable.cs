using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GameBasicClasses.BasicClasses
{
    public abstract class Drawable
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
        public Rectangle InitialBounds { get; protected set; }

        public Vector Position
        {
            get { return new Vector(this.bounds.X, this.bounds.Y); }
            set 
            {
                this.bounds.X = (int)value.X; this.bounds.Y = (int)value.Y;
                if (this.box != null)
                {
                    this.box.Location = this.box.Location = new Point((int)this.Position.X, (int)this.Position.Y);
                }
            }
        }

        private Image image;
        public Image Image
        {
            get { return this.image; }
            set
            {
                this.image = value;
                if (this.Image != null)
                {
                    this.box.Image = this.Image;
                    this.box.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    this.box.BackColor = this.Color;
                }
            }
        }
        public Image InitialImage { get; protected set; }

        protected PictureBox box;
        public virtual PictureBox Box
        {
            get
            {
                return this.box;
            }
            set
            {
                this.box = value;
                if (this.Image != null)
                {
                    this.box.Image = this.Image;
                    this.box.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.box.BackColor = Color.Transparent;
                }
                else
                {
                    this.box.BackColor = this.Color;
                }
                this.box.Size = this.bounds.Size;
                this.box.Location = new Point((int)this.Position.X, (int)this.Position.Y);
            }
        }
        public PictureBox InitialBox { get; protected set; }

        private Color color;
        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
                this.box.BackColor = this.Color;
            }
        }
        public Color InitialColor { get; protected set; }

        public Drawable()
        {
            this.ClientSize = new Size(1000, 600);
            this.Box = new PictureBox();
            this.Bounds = new Rectangle();
            this.InitialBounds = this.Bounds;
            this.Position = Vector.Zero();
            this.Image = null;
            this.InitialImage = this.Image;
            this.InitialBox = this.Box;
            this.Color = Color.Blue;
            this.InitialColor = this.Color;
        }
    }
}
