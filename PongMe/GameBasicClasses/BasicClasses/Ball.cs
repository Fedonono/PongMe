using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using GameBasicClasses.Obstacles.Paddle;
using System.Windows;
using GameBasicClasses.Obstacles.Bonus;

namespace GameBasicClasses.BasicClasses
{
    public class Ball : Movable
    {
        private int diameter;
        public int InitialDiameter { get; protected set; }
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
                this.Bounds = new Rectangle(this.Bounds.X, this.Bounds.Y, this.diameter, this.diameter);
            }
        }
        private readonly static int MAX_DIAMETER = 100;

        public bool isMoving { get; set; }

        public bool isOutLeft { get; set; }
        public bool isOutRight { get; set; }
        private float MAX_SPEED { get; set; }

        public Ball(float speed, int diameter, Color color, Image image, int clientWidth, int clientHeight)
        {
            this.MAX_SPEED = 1.5f;
            this.Speed = speed;
            this.InitialSpeed = this.Speed;
            this.Diameter = diameter;
            this.InitialDiameter = this.Diameter;
            this.Color = color;
            this.InitialColor = this.Color;
            this.Image = image;
            this.InitialImage = this.Image;
            this.Position = new Vector(this.ClientWidth / 2 - this.Diameter / 2, this.ClientHeight / 2 - this.Diameter / 2);
            this.Bounds = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.diameter, this.diameter);
            this.InitialBounds = this.Bounds;
            this.Direction = new Vector(10, 10);
            this.InitialDirection = this.Direction;
            this.ClientWidth = clientWidth;
            this.ClientHeight = clientHeight;
            this.Initialize();
        }

        public void Initialize()
        {
            this.Speed = this.InitialSpeed;
            this.Diameter = this.InitialDiameter;
            this.Color = this.InitialColor;
            this.Image = this.InitialImage;
            this.Direction = this.InitialDirection;
            this.PreviousPosition = this.Position;
            this.Bounds = this.InitialBounds;
            this.isMoving = false;
            this.isOutLeft = false;
            this.isOutRight = false;
        }

        public void ToogleMovement(bool movement)
        {
            this.isMoving = movement;
        }

        public void nextPosition()//très incomplet
        {
            if (!this.isMoving) { return; }
            this.checkBoardCollision();
            this.checkOut();
            CurrentGame cg = CurrentGame.GetInstance();
            this.checkObstaclesCollision(cg.GameModel.listePaddle());
            this.checkObstaclesCollision(cg.GameModel.ListeBrick);
            this.checkObstaclesCollision(cg.GameModel.ListeBonus);
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

        private void checkObstaclesCollision<T>(List<T> ob) where T : GameBasicClasses.Obstacles.Obstacle
        {
            foreach (GameBasicClasses.Obstacles.Obstacle obstacle in ob)
            {
                if (obstacle.contains(this))
                {
                    if (!(obstacle is Bonus))
                    {
                        if (obstacle.containsLeftOrRight(this))
                        {
                            this.Direction = new Vector(-this.Direction.X, this.Direction.Y);
                        this.PreviousPosition = Position;
                            this.move();
                            this.Speed += 0.05f;
                            return;
                        }
                        else if (obstacle.containsUpOrDown(this))
                        {
                            this.Direction = new Vector(this.Direction.X, -this.Direction.Y);
                        this.PreviousPosition = Position;
                            this.move();
                            this.Speed += 0.05f;
                            return;
                        }
                    }
                    else
                    {
                        Bonus b = obstacle as Bonus;
                        if (!b.Active)
                        {
                            b.startTimeOut(this);
                        }
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
