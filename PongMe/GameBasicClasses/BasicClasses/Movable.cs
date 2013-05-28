using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameBasicClasses.BasicClasses
{
    public class Movable : Drawable
    {
        public Vector Direction { get; set; }
        protected Vector initialDirection;

        public Vector PreviousPosition { get; set; }

        private int nbWayPoints;
        private Point[] Path{ get; set; }

        private float speed;
        protected float initialSpeed;
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

        public Movable()
        {
            this.Direction = new Vector(1, 1);
            this.initialDirection = this.Direction;
            this.Speed = 0.2f;
            this.initialSpeed = this.Speed;
            this.PreviousPosition = this.Position;

            this.nbWayPoints = 100;
            this.Path = new Point[this.nbWayPoints];
        }

        public Point[] GetPath()
        {
            Point Initial = new Point((int)(this.PreviousPosition.X + this.Bounds.Width / 2), (int)(this.PreviousPosition.Y + this.Bounds.Height / 2));
            Point Final = new Point((int)(this.Position.X + this.Bounds.Width / 2), (int)(this.Position.Y + this.Bounds.Height / 2));
            int HorizontalStep = (int)(Final.X - Initial.X)/this.nbWayPoints;  
            int VerticalStep = (int)(Final.Y - Initial.Y)/this.nbWayPoints;  

            this.Path[0] = Initial;
            this.Path[this.nbWayPoints - 1] = Final;
            for (int i = 1; i < this.nbWayPoints-1; i++)
            {
                this.Path[i] = new Point(this.Path[i - 1].X + HorizontalStep, this.Path[i - 1].Y + VerticalStep);
            }

            return this.Path;
        }
    }
}
