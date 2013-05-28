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
            List<Point> bounds = b.getBounds();
            foreach (Point p in bounds)
            {
                if (this.Bounds.Contains(p))
                {
                    return true;
                }
            }
            return false;
        }

        public bool containsLeftOrRight(Ball b)
        {
            Rectangle left = new Rectangle((int)this.Position.X-b.Diameter*2, (int)this.Position.Y, b.Diameter*2, this.Bounds.Height);
            Rectangle right = new Rectangle((int)this.Position.X + this.Bounds.Width, (int)this.Position.Y, b.Diameter * 2, this.Bounds.Height);
            Point[] bounds = b.GetPath();
            foreach (Point p in bounds)
            {
                if (left.Contains(p) || right.Contains(p))
                {
                    return true;
                }
            }
            return false;
        }

        public bool containsUpOrDown(Ball b)
        {
            Rectangle up = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Bounds.Width, b.Diameter * 2);
            Rectangle down = new Rectangle((int)this.Position.X, (int)this.Position.Y + this.Bounds.Height - b.Diameter * 2, this.Bounds.Width, b.Diameter * 2);
            Point[] bounds = b.GetPath();
            foreach (Point p in bounds)
            {
                if (up.Contains(p) || down.Contains(p))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
