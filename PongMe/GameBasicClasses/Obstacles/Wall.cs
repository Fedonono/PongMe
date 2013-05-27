using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.MVC;
using GameBasicClasses.BasicClasses;
using System.Drawing.Drawing2D;
using System.Drawing;



namespace GameBasicClasses.Obstacles
{
    /// <summary>
    /// Bord haut et bas de la zone de jeu.
    /// </summary>
    public class Wall : Obstacle
    {

        private GraphicsPath path;

        public GraphicsPath Path
        {
            get { return this.path; }
            set { this.path = value; }
        }


        public Wall(int clientWidth, int clientHeight)
            : base(clientWidth, clientHeight)
        {

        }

        public Wall(int clientWidth, int clientHeight, GraphicsPath path)
            : base(clientWidth, clientHeight)
        {
            this.path = path;
        }

        public void addLine(int x1, int y1, int x2, int y2)
        {
            this.path.AddLine(x1, y1, x2, y2);
        }


        public void addRectangle(Rectangle rect)
        {
            this.path.AddRectangle(rect);
        }

        public void addPolygon(Point[] points)
        {
            this.path.AddPolygon(points);
        }

        public void addPie(int x, int y, int width, int height, float startAngle, float sweepAngle)
        {
            this.path.AddPie(x, y, width, height, startAngle, sweepAngle);
        }



        public void addWall(Wall wall, bool connect)
        {
            this.addPath(wall.Path, connect);
        }

        public void addPath(GraphicsPath path, bool connect)
        {
            this.path.AddPath(path, connect);
        }

        public void addEllipse(int x, int y, int width, int height)
        {
            this.path.AddEllipse(x, y, width, height);
        }

        public void addCurve(Point[] points, int offset, int numberOfSegments, float tension)
        {
            this.path.AddCurve(points, offset, numberOfSegments, tension);
        }

        public void addBezier(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            this.path.AddBezier(x1, y1, x2, y2, x3, y3, x4, y4);
        }


        public void addClosedCurve(Point[] points, float tension)
        {
            this.path.AddClosedCurve(points, tension);
        }


        public override bool contains(Ball b)
        {
            List<Point> ballBounds = b.getBounds();

            throw new System.NotImplementedException();

        }

    }
}
