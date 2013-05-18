using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

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
        
        public Ball(int speed, int diameter, int startX, int startY, int clientWidth, int clientHeight)
        {
            this.Speed = speed;
            this.Diameter = diameter;
            this.ClientWidth = clientWidth;
            this.ClientHeight = clientHeight;
            this.ballRepresentation = new Rectangle(startX, startY, this.diameter, this.diameter);
            this.backX = this.backY = false;
        }

        public void nextPosition()//très incomplet
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
            if (this.clientWidth <= this.ballRepresentation.X + this.diameter + this.speed)
            {
                this.backX = true;
            }
            if (this.clientHeight <= this.ballRepresentation.Y + this.diameter + this.speed)
            {
                this.backY = true;
            }
            if (this.ballRepresentation.X <= this.speed)
            {
                this.backX = false;
            }
            if (this.ballRepresentation.Y <= this.speed)
            {
                this.backY = false;
            }
        }

        public Point Position
        {
            get { return new Point(this.ballRepresentation.X, this.ballRepresentation.Y); }
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
                x = (this.diameter+1) * Math.Cos(tempTeta) + this.Position.X;
                y = (this.diameter+1) * Math.Sin(tempTeta) + this.Position.Y;
                bounds.Add(new Point((int)x, (int)y));
                tempTeta += teta;
            }
            return bounds;
        }
    }
}
