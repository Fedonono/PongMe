using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using GameBasicClasses.MVC;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles
{
    public abstract class Obstacle : Movable
    {
        public bool contains(Ball b)
        {
            return !(Rectangle.Intersect(this.Bounds, b.Bounds) == Rectangle.Empty);
        }

        public bool containsLeftOrRight(Ball b)
        {
            Point[] path = b.GetPath();

            foreach (Point p in path)
            {
                bool isInHorizontalBounds =(p.Y >= this.Bounds.Top && p.Y <= this.Bounds.Bottom) ;

                if ((p.X < this.Bounds.Left || p.X > this.Bounds.Right) && isInHorizontalBounds)
                {
                    if(p.X > this.Bounds.Right)
                    {
                        b.Position.X = this.Bounds.Right + 1000;
                    }
                    else if (p.X < this.Bounds.Left)
                    {
                        b.Position.X = this.Bounds.Left - b.Bounds.Width - 1;
                    }

                    return true;
                }
            }
            return false;
        }

        public bool containsUpOrDown(Ball b)
        {
            Point[] path = b.GetPath();

            foreach (Point p in path)
            {

                bool isInVerticalBounds = (p.X >= this.Bounds.Left && p.X <= this.Bounds.Right);

                if ((p.Y < this.Bounds.Top || p.Y > this.Bounds.Bottom) && isInVerticalBounds)
                {

                    if (p.Y < this.Bounds.Top)
                    {
                        b.Position.Y = this.Bounds.Top - b.Bounds.Height - 1;
                    }
                    else if (p.Y > this.Bounds.Bottom)
                    {
                        b.Position.Y = this.Bounds.Bottom + 1; 
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
