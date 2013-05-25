using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameBasicClasses.MVC;
using GameBasicClasses.BasicClasses;
using System.Windows.Forms;

namespace GameBasicClasses.Obstacles.Paddle
{
    public class Paddle : Obstacle
    {
        private ObstacleView view;

        public Point Position 
        { 
            get { return this.view.Position; }
            set { this.view.Position = value; }
        }
        public Size Dimensions 
        { 
            get { return this.view.Dimensions; }
            set { this.view.Dimensions = value; }
        }

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
                    this.Position = new Point(this.ClientWidth - this.Dimensions.Width,this.Position.Y);
                }
            }
        }
        
        public Color Color { get; set; }

        private PictureBox paddleBox = new PictureBox();
        public PictureBox PaddleBox
        {
            get {
                paddleBox.Size = this.Dimensions;
                paddleBox.Location = this.Position;
                paddleBox.BackColor = this.Color;
                return paddleBox; 
            }
            set { paddleBox = value; }
        }

        public bool Left { get; set; }

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

        public Paddle() : this(true, Color.Red, 50, 200, 3, 1000, 600)
        {
        }

        public Paddle(bool left, Color color, int width, int height, int speed, int clientWidth, int clientHeight) : base(clientWidth,clientHeight)
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
            this.view = new RectanglePaddle(paddlePosition.X, paddlePosition.Y, width, height);
            this.Speed = speed;
            this.Color = color;
            this.Left = left;
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
            else
            {
                this.view.Position = new Point(this.view.Position.X, this.ClientHeight - this.view.Dimensions.Height);
            }
        }

        public void up()
        {
            if (this.Position.Y - this.speed >= 0)
            {
                this.view.Position = new Point(this.view.Position.X, this.view.Position.Y - this.speed);
            }
            else
            {
                this.view.Position = new Point(this.view.Position.X, 0);
            }
        }
    }
}