using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBasicClasses.BasicClasses
{
    public class Ball
    {
        private float speed;
        public float Speed
        {
            get { return this.speed; }
            set
            {
                if (value > 0 && value < MAX_SPEED)
                {
                    this.speed = value;
                }
            }
        }
        private readonly static float MAX_SPEED = 100;

        private float diameter;
        public float Diameter
        {
            get { return this.diameter; }
            set
            {
                if (value > 0 && value < MAX_DIAMETER)
                {
                    this.diameter = value;
                }
            }
        }
        private readonly static float MAX_DIAMETER = 50;

        public Point Position { get; private set; }

        public Ball(float speed, float diameter, int startX, int startY)
        {
            this.Speed = speed;
            this.Diameter = diameter;
            this.setPosition(startX, startY);
        }

        private void setPosition(int x, int y)
        {
            this.Position.X = x;
            this.Position.Y = y;
        }
    }
}
