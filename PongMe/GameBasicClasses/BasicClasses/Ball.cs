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
    public class Ball
    {
        private int speed;
        public int Speed
        {
            get { return this.speed; }
            set
            {
                if (value > 0 && value < MAX_SPEED)
                {
                    this.speed = value;
                }
                else
                {
                    this.speed = MAX_SPEED;
                }
            }
        }
        private readonly static int MAX_SPEED = 100;

        private int diameter;
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
            }
        }
        private readonly static int MAX_DIAMETER = 100;

        private bool backX, backY;

        private Rectangle ballRepresentation;
        public Rectangle BallRepresentation
        {
            get { return ballRepresentation; }
        }

        public Point Position
        {
            get { return new Point(this.ballRepresentation.X, this.ballRepresentation.Y); }
        }

        private PictureBox ballBox = new PictureBox();
        public PictureBox BallBox
        {
            get {
                ballBox.Size = this.BallRepresentation.Size;
                ballBox.Location = this.Position;
                ballBox.BackColor = this.Color;
                return ballBox; 
            }
            set { ballBox = value; }
        }

        public Color Color { get; set; }

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
        public Size ClientSize
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

        public bool isMoving { get; set; }

        public bool isOutLeft { get; set; }
        public bool isOutRight { get; set; }
        
        public Ball(int speed, int diameter, Color color, int clientWidth, int clientHeight)
        {
            this.Speed = speed;
            this.Diameter = diameter;
            this.Color = color;
            this.ClientWidth = clientWidth;
            this.ClientHeight = clientHeight;
            this.ballRepresentation = new Rectangle(this.ClientWidth/2 - this.Diameter/2, this.ClientHeight/2 - this.Diameter/2, this.diameter, this.diameter);
            this.backX = this.backY = false;
            this.isMoving = false;
            this.isOutLeft = false;
            this.isOutRight = false;
        }

        public void nextPosition()//très incomplet
        {
            if (!this.isMoving) { return; }
            this.checkBoardCollision();
            CurrentGame cg = CurrentGame.getInstance();
            this.checkObstaclesCollision(cg.GameModel.listePaddle());
            this.move();
        }

        private void checkBoardCollision()
        {
            if (this.clientWidth < this.ballRepresentation.X)
            {
                this.isOutRight = true;
            }
            else if (this.clientHeight <= this.ballRepresentation.Y + this.diameter)
            {
                this.backY = true;
            }
            if (this.ballRepresentation.X + this.Diameter < 0)
            {
                this.isOutLeft = true;
            }
             else if (this.ballRepresentation.Y <= 0)
            {
                this.backY = false;
            }
        }

        private void checkObstaclesCollision(List<Paddle> ob)
        {
            foreach (Paddle obstacle in ob)
            {
                if (obstacle.contains(this))
                {
                    if (this.backX) { this.backX = false; } else { this.backX = true; }
                    //if (this.backY) { this.backY = false; } else { this.backY = true; }
                }
            }
        }

        private void move()
        {
            if (this.backX)
            {
                this.ballRepresentation.X -= this.speed;
            }
            else
            {
                this.ballRepresentation.X += this.speed;
            }
            if (this.backY)
            {
                this.ballRepresentation.Y -= this.speed;
            }
            else
            {
                this.ballRepresentation.Y += this.speed;
            }
        }

        public void resetPosition()
        {
            this.ballRepresentation.Location = new Point(this.ClientWidth / 2 - this.Diameter / 2, this.ClientHeight / 2 - this.Diameter/2);
            this.isOutLeft = false;
            this.isOutRight = false;
            this.isMoving = false;
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
