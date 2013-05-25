using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameBasicClasses.Obstacles
{
    public class RectanglePaddle : ObstacleView
    {
        private Rectangle view;

        public RectanglePaddle(int x, int y, int width, int height)
        {
            this.view = new Rectangle(x, y, width, height);
        }

        public bool Contains(Point p)
        {
            return view.Contains(p);
        }

        public Point Position
        {
            get { return this.view.Location; }
            set { this.view.Location = value; }
        }

        /*
         * Dimensions = dimensions de la bounded box 
        */
        public Size Dimensions {
            get { return this.view.Size;}
            set { this.view.Size = value; }
        }
    }
}
