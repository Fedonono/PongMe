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

        public Vector PreviousPosition { get; set; }

        private int NbWayPoints{ get; set; }
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
            this.Speed = 0.2f;
            this.initialSpeed = this.Speed;
            this.PreviousPosition = this.Position;

            this.NbWayPoints = 300;
            this.Path = new Point[this.NbWayPoints];
        }

        public Point[] GetPath()
        {
            Point Initial = new Point((int)(this.PreviousPosition.X + this.bounds.Width / 2), (int)(this.PreviousPosition.Y + this.bounds.Height / 2));
            Point Final = new Point((int)(this.Position.X + this.bounds.Width / 2), (int)(this.Position.Y + this.bounds.Height / 2));
            int HorizontalStep = (int)(Final.X - Initial.X)/this.NbWayPoints;  
            int VerticalStep = (int)(Final.Y - Initial.Y)/this.NbWayPoints;  

            this.Path[0] = Initial;
            this.Path[this.NbWayPoints - 1] = Final;
            for (int i = 1; i < this.NbWayPoints-1; i++)
            {
                this.Path[i] = new Point(this.Path[i - 1].X + HorizontalStep, this.Path[i - 1].Y + VerticalStep);
            }

            return this.Path;
        }
    }
}
