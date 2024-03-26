using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv3
{
    public class Polygon : Geometry
    {
        private Point[] points;
        
        public Polygon(Point[] pts)
        {
            points = pts;

            var sum = 0;
            for (int i = 0; i < points.Length; i++)
            {
                sum += points[i].X;
            }
            OX = sum / points.Length;

            OY = (int)points.Average(p => p.Y);
        }

        public Polygon(Point[] pts, int penWidth)
            : this(pts)
        {
            PenWidth = penWidth;
        }

        public Polygon(Point[] pts, int penWidth, Color penColor)
            : this(pts, penWidth)
        {
            PenColor = penColor;
        }

        public Polygon(Point[] pts, int penWidth, Color penColor,
            Color fillColor)
            : this(pts, penWidth, penColor)
        {
            FillColor = fillColor;
        }

        internal override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            var pen = new Pen(PenColor, PenWidth);
            graphics.DrawPolygon(pen, points);            
        }
    }
}
