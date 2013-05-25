using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameBasicClasses.Obstacles
{
    interface ObstacleView
    {
        bool Contains(Point p);
        Point Position { get; set; }
        Size Dimensions { get; set; }
    }
}
