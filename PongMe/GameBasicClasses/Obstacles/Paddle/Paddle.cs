using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameBasicClasses.MVC;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles
{
    public class Paddle : Obstacle
    {
        private ObstacleView view;

        public Point Position { get {return this.view.Position;} }
        public Size Dimensions { get {return this.view.Dimensions; } } 

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

        public Paddle() : this(0, 0, 50, 200, 3, 1000, 600)
        {
        }

        public Paddle(int x, int y, int width, int height, int speed, int clientWidth, int clientHeight) : base(clientWidth,clientHeight)
        {
            this.view = new RectanglePaddle(x, y, width, height);
            this.Speed = speed;
        }

        public override bool contains(Ball b)
        {
            List<Point> bounds = b.getBounds();
            foreach (Point p in bounds)
            {
                if (this.view.Contains(p))
                {
                    return true;
                }
            }
            return false;
        }

        public void down()
        {
            if (this.view.Position.Y + this.view.Dimensions.Height + this.speed <= this.ClientHeight)
            {
                this.view.Position = new Point(this.view.Position.X, this.view.Position.Y + this.speed);
            }
        }

        public void up()
        {
            if (this.view.Position.Y - this.speed >= 0)
            {
                this.view.Position = new Point(this.view.Position.X, this.view.Position.Y - this.speed);
            }
        }
    }
}
