using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBasicClasses.BasicClasses
{
    public class Ball
    {
        private float speed;
        private readonly static float MAX_SPEED = 100;

        public float Speed
        {
            get { return speed; }
            set
            {
                if (Speed > 0 && Speed < MAX_SPEED)
                {
                    speed = value;
                }
            }
        }

        private float diameter;
        private readonly static float MAX_DIAMETER = 50;

        public float Diameter
        {
            get { return diameter; }
            set
            {
                if (Diameter > 0 && Diameter < MAX_DIAMETER)
                {
                    diameter = value;
                }
            }
        }

        public Ball(float speed, float diameter)
        {
            this.Speed = speed;
            this.Diameter = diameter;
        }
    }
}
