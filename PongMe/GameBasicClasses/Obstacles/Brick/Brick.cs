using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;
using System.Drawing;
using System.Windows.Forms;

namespace GameBasicClasses.Obstacles
{
    /// <summary>
    /// Brique apparaissant dans la zone de jeu.
    /// Peut être détruite.
    /// </summary>
    public class Brick : Obstacle
    {
        private static int width = 60;
        public static int Width
        {
            get { return width; }
            private set { width = value; }
        }

        private int health;
        public int Health
        {
            get { return health; }
            set
            {
                if (value > 0)
                {
                    health = value;
                }
                else
                {
                    health = 1;
                }
            }
        }

        public bool Active { get; set; }

        public Brick(int clientWidth, int clientHeight, int health, Vector position)
        {
            this.ClientHeight = clientHeight;
            this.ClientWidth = clientWidth;
            this.Health = health;
            this.Image = Properties.Resources.free_companion_cube_icon_by_ashunnoodles_d4w979m;
            this.InitialImage = this.Image;
            Random r = new Random();
            this.Color = Color.Empty;// System.Drawing.Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            this.InitialColor = this.Color;
            this.Position = position;
            this.Bounds = new Rectangle((int)this.Position.X, (int)this.Position.Y, Brick.Width, Brick.Width);
            this.InitialBounds = this.Bounds;
            this.Active = true;
        }

        public void Touched()
        {
            this.health--;
            if (this.Health == 0)
            {
                this.Active = false;
            }
        }
    }
}
