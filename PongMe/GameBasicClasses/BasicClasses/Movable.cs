using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameBasicClasses.BasicClasses
{
    public abstract class Movable : Drawable
    {
        public Vector Direction { get; set; }
        public Vector InitialDirection { get; protected set; }

        public Vector PreviousPosition { get; set; }

        private int nbWayPoints;
        private Point[] Path{ get; set; }

        private float speed;
        public float InitialSpeed { get; protected set; }
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
        protected float MAX_SPEED = 10;

        public Movable()
        {
            this.Direction = new Vector(1, 1);
            this.InitialDirection = this.Direction;
            this.Speed = 0.2f;
            this.InitialSpeed = this.Speed;
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
