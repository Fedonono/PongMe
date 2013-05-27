using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBasicClasses.BasicClasses
{
    public class Movable : Drawable
    {
        public Vector Direction { get; set; }

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
    }
}
