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
        private float speed;
        private float initialSpeed;
        public float Speed
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
        private readonly static int MAX_SPEED = 10;

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
            }
        }
        private readonly static int MAX_DIAMETER = 100;

        private Rectangle ballRepresentation;
        public Rectangle BallRepresentation
        {
            get { return ballRepresentation; }
        }

        public Vector Position
        {
            get { return new Vector(this.ballRepresentation.X, this.ballRepresentation.Y); }
            private set { this.ballRepresentation.X = (int) value.X; this.ballRepresentation.Y = (int) value.Y; }
        }
        public Vector Direction { get; set; }

        private PictureBox ballBox = new PictureBox();
        public PictureBox BallBox
        {
            get {
                ballBox.Size = this.BallRepresentation.Size;
                ballBox.Location = new Point((int) this.Position.X, (int) this.Position.Y);
                ballBox.BackColor = this.Color;
                return ballBox; 
            }
            set { ballBox = value; }
        }

        public Color Color { get; set; }
        private Color initialColor;

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
        
        public Ball(float speed, int diameter, Color color, int clientWidth, int clientHeight)
        {
            this.Speed = speed;
            this.initialSpeed = this.Speed;
            this.Diameter = diameter;
            this.initialDiameter = this.Diameter;
            this.Color = color;
            this.initialColor = this.Color;
            this.ClientWidth = clientWidth;
            this.ClientHeight = clientHeight;
            this.Initialize();
        }

        public void Initialize()
        {
            this.Speed = this.initialSpeed;
            this.Diameter = this.initialDiameter;
            this.Color = this.initialColor;
            this.Direction = new Vector(10, 10);
            this.Position = new Vector(this.ClientWidth / 2 - this.Diameter / 2, this.ClientHeight / 2 - this.Diameter / 2);
            this.ballRepresentation = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.diameter, this.diameter);
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
            if (this.clientWidth < this.Position.X)
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
                Direction = new Vector(Direction.X, -Direction.Y);
            }
        }

        private void checkObstaclesCollision(List<Paddle> ob)
        {
            foreach (Paddle obstacle in ob)
            {
                if (obstacle.contains(this))
                {
                    this.Direction = new Vector(-this.Direction.X, this.Direction.Y);
                    this.Speed += 0.05f;
                    this.Direction.Y++;
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
