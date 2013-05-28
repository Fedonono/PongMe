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
                if (this.bounds.Contains(p))
                {
                    return true;
                }
            }
            return false;
        }

        public bool containsLeftOrRight(Ball b)
        {
            Rectangle left = new Rectangle((int)this.Position.X, (int)this.Position.Y, 1, this.bounds.Height);
            Rectangle right = new Rectangle((int)this.Position.X + this.bounds.Width-1, (int)this.Position.Y, 1, this.bounds.Height);
            List<Point> bounds = b.getBounds();
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
            Rectangle up = new Rectangle((int)this.Position.X+1, (int)this.Position.Y, this.bounds.Width-2, 1);
            Rectangle down = new Rectangle((int)this.Position.X+1, (int)this.Position.Y + this.bounds.Height-1, this.bounds.Width-2, 1);
            List<Point> bounds = b.getBounds();
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
