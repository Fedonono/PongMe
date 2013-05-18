using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameBasicClasses.MVC;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles
{
    public class Racket : IObstacle
    {
        private Rectangle racketRepresentation;
        public Rectangle RacketRepresentation
        {
            get { return racketRepresentation; }
        }

        public Point Position
        {
            get { return this.racketRepresentation.Location; }
            set { this.racketRepresentation.Location = value; }
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

        public Racket() : this(0, 0, 50, 200, 3)
        {
        }

        public Racket(int x, int y, int width, int height, int speed)
        {
            this.racketRepresentation = new Rectangle(x, y, width, height);
            this.Speed = speed;
        }

        public bool contains(Ball b)
        {
            List<Point> bounds = b.getBounds();
            foreach (Point p in bounds)
            {
                if (this.racketRepresentation.Contains(p))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
