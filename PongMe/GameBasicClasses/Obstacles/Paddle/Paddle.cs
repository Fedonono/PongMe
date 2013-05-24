using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameBasicClasses.MVC;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles.Paddle
{
    public class Paddle : Obstacle
    {
        private Rectangle paddleRepresentation;
        public Rectangle PaddleRepresentation
        {
            get { return paddleRepresentation; }
        }

        public Point Position
        {
            get { return this.paddleRepresentation.Location; }
            set { this.paddleRepresentation.Location = value; }
        }

        public Color Color { get; set; }

        public override Size ClientSize
        {
	          get 
	        { 
		         return base.ClientSize;
	        }
	          set 
	        { 
		        base.ClientSize = value;
                if (this.Position.X != 0)
                {
                    this.Position = new Point(this.ClientWidth - this.PaddleRepresentation.Width, 0);
                }
	        }
        }

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

        public Paddle() : this(true, 50, 200, 3, 1000, 600)
        {
        }

        public Paddle(bool left, int width, int height, int speed, int clientWidth, int clientHeight) : base(clientWidth,clientHeight)
        {
            if (width <= 0 || width >= this.ClientWidth)
            {
                width = 50;
            }
            if (height <= 0 || height >= this.ClientHeight)
            {
                height = 200;
            }
            Point paddlePosition;
            if (left)
            {
                paddlePosition = new Point(0, 0);
            }
            else
            {
                paddlePosition = new Point(this.ClientWidth - width);
            }
            this.paddleRepresentation = new Rectangle(paddlePosition.X, paddlePosition.Y, width, height);
            this.Speed = speed;
        }

        public override bool contains(Ball b)
        {
            List<Point> bounds = b.getBounds();
            foreach (Point p in bounds)
            {
                if (this.paddleRepresentation.Contains(p))
                {
                    return true;
                }
            }
            return false;
        }

        public void down()
        {
            if (this.Position.Y + this.PaddleRepresentation.Height + this.speed <= this.ClientHeight)
            {
                this.Position = new Point(this.Position.X, this.Position.Y + this.speed);
            }
        }

        public void up()
        {
            if (this.Position.Y - this.speed >= 0)
            {
                this.Position = new Point(this.Position.X, this.Position.Y - this.speed);
            }
        }
    }
}
