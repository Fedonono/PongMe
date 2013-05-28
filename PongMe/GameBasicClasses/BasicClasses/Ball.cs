using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using GameBasicClasses.Obstacles.Paddle;
using System.Windows;

namespace GameBasicClasses.BasicClasses
{
    public class Ball : Movable
    {
        private int diameter;
        private int initialDiameter;
        public int Diameter
        {
            get { return this.diameter; }
            set
            {
                if (value > 0 && value < MAX_DIAMETER)
                {
                    this.diameter = value;
                }
                else
                {
                    this.diameter = MAX_DIAMETER;
                }
                this.bounds.Width = this.diameter;
                this.bounds.Height = this.diameter;
            }
        }
        private readonly static int MAX_DIAMETER = 100;

        public bool isMoving { get; set; }

        public bool isOutLeft { get; set; }
        public bool isOutRight { get; set; }
        
        public Ball(float speed, int diameter, Color color, Image image, int clientWidth, int clientHeight)
        {
            this.Speed = speed;
            this.initialSpeed = this.Speed;
            this.Diameter = diameter;
            this.initialDiameter = this.Diameter;
            this.Color = color;
            this.initialColor = this.Color;
            this.Image = image;
            this.initialImage = this.Image;
            this.ClientWidth = clientWidth;
            this.ClientHeight = clientHeight;
            this.Initialize();
        }

        public void Initialize()
        {
            this.Speed = this.initialSpeed;
            this.Diameter = this.initialDiameter;
            this.Color = this.initialColor;
            this.Image = this.initialImage;
            this.Direction = new Vector(10, 10);
            this.Position = new Vector(this.ClientWidth / 2 - this.Diameter / 2, this.ClientHeight / 2 - this.Diameter / 2);
            this.PreviousPosition = this.Position;
            this.bounds = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.diameter, this.diameter);
            this.isMoving = false;
            this.isOutLeft = false;
            this.isOutRight = false;
        }

        public void nextPosition()//très incomplet
        {
            if (!this.isMoving) { return; }
            this.checkBoardCollision();
            this.checkOut();
            CurrentGame cg = CurrentGame.getInstance();
            this.checkObstaclesCollision(cg.GameModel.listePaddle());
            this.move();
        }

        private void checkOut()
        {
            if (this.ClientWidth < this.Position.X)
            {
                this.isOutRight = true;
            } else if (this.Position.X + this.Diameter < 0)
            {
                this.isOutLeft = true;
            }
        }

        private void checkBoardCollision()
        {
            if ((this.Position.Y <= 0 && this.Direction.Y < 0)
                || (this.Position.Y >= this.ClientHeight - this.Diameter && this.Direction.Y > 0))
            {
                this.Direction = new Vector(Direction.X, -Direction.Y);
                this.PreviousPosition = Position;
            }
        }

        private void checkObstaclesCollision(List<Paddle> ob)
        {
            foreach (Paddle obstacle in ob)
            {
                if (obstacle.contains(this))
                {
                    if(obstacle.containsLeftOrRight(this))
                    {
                        this.Direction = new Vector(-this.Direction.X, this.Direction.Y);
                        this.PreviousPosition = Position;
                        this.move();
                        this.Speed += 0.05f;
                        return;
                    }
                    else if(obstacle.containsUpOrDown(this))
                    {
                        this.Direction = new Vector(this.Direction.X, -this.Direction.Y);
                        this.PreviousPosition = Position;
                        this.move();
                        this.Speed += 0.05f;
                        return;
                    }
                }
            }
        }

        private void move()
        {
            this.Position += this.Direction * this.Speed;
        }

        public List<Point> getBounds()
        {
            List<Point> bounds = new List<Point>();
            int nbOfPoints = 100;
            double teta = (2 * Math.PI) / nbOfPoints;
            double x,y,tempTeta;
            tempTeta = 0;
            for (int i = 0; i < nbOfPoints; i++)
            {
                x = (this.Diameter/2) * Math.Cos(tempTeta) + this.Position.X + this.Diameter/2;
                y = (this.Diameter/2) * Math.Sin(tempTeta) + this.Position.Y + this.Diameter/2;
                bounds.Add(new Point((int)x, (int)y));
                tempTeta += teta;
            }
            return bounds;
        }
    }
}
