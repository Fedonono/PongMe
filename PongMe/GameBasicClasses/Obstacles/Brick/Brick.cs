using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;
using System.Drawing;

namespace GameBasicClasses.Obstacles
{
    /// <summary>
    /// Brique apparaissant dans la zone de jeu.
    /// Peut être détruite.
    /// </summary>
    public class Brick : Obstacle
    {
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

        public Brick(int clientWidth, int clientHeight, int health, Vector position)
        {
            this.ClientHeight = clientHeight;
            this.ClientWidth = clientWidth;
            this.Health = health;
            this.Image = null;// Properties.Resources.brick;
            this.InitialImage = this.Image;
            Random r = new Random();
            this.Color = System.Drawing.Color.FromArgb(r.Next(255),r.Next(255),r.Next(255));
            this.InitialColor = this.Color;
            this.Position = position;
            this.Bounds = new Rectangle((int)this.Position.X, (int)this.Position.Y, r.Next(50,100), r.Next(50,100));
            this.InitialBounds = this.Bounds;
            this.Active = true;
        }

        public void touched()
        {
            this.health--;
            if (this.Health == 0)
            {
                this.Active = false;
            }
        }

        public bool Active { get; set; }
    }
}
