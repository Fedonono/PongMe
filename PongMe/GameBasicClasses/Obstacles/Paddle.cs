﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameBasicClasses.BasicClasses;
using System.Windows.Forms;

namespace GameBasicClasses.Obstacles.Paddle
{
    public class Paddle : Obstacle
    {
        public bool Left { get; set; }
        public bool PortalMode { get; set; }
        public int Id { get; set; }

        // Lorsque la taille de la fenetre change, il faut déplacer la raquette de droite
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
                    this.Position = new Vector(this.ClientWidth - this.Bounds.Width - 7, this.Position.Y);
                }
            }
        }

        public Paddle(bool left, Color color, Image image, int id, int width, int height, int speed, bool portalMode, int clientWidth, int clientHeight)
        {
            this.PortalMode = portalMode;
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
            this.Id = id;
            Vector paddlePosition;
            if (left)
            {
                paddlePosition = new Vector(2, this.ClientHeight/2-height/2);
            }
            else
            {
                paddlePosition = new Vector(this.ClientWidth - width - 7, this.ClientHeight / 2 - height / 2);
            }
            this.Direction = new Vector(0, 10);
            this.Position = paddlePosition;
            this.InitialDirection = this.Direction;
            this.Bounds = new Rectangle((int)this.Position.X, (int)this.Position.Y, width, height);
            this.InitialBounds = this.Bounds;
            this.Speed = speed;
            this.InitialSpeed = this.Speed;
            this.Color = color;
            this.InitialColor = this.Color;
            this.Image = image;
            this.InitialImage = this.Image;
            this.Left = left;
            this.Initialize();
        }

        public void Initialize()
        {
            this.Direction = this.InitialDirection;
            this.Bounds = this.InitialBounds;
            this.Speed = this.InitialSpeed;
            this.Color = this.InitialColor;
            this.Image = this.InitialImage;
        }

        public void Down()
        {
            if (this.Position.Y + this.Bounds.Height + this.Speed <= this.ClientHeight)
            {
                this.Position = new Vector(this.Position.X, this.Position.Y + this.Speed);
            }
            else
            {
                this.Position = new Vector(this.Position.X, this.ClientHeight - this.Bounds.Height);
            }
        }

        public void Up()
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