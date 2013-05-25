using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBasicClasses.BasicClasses
{
    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static float operator *(Vector vector1, Vector vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y;
        }

        public static Vector operator *(Vector vector, float scalar)
        {
            return new Vector(vector.X * scalar, vector.Y * scalar);
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X - vector2.X, vector1.Y - vector2.Y);
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        public static Vector Zero()
        {
            return new Vector(0, 0);
        }
    }
}
