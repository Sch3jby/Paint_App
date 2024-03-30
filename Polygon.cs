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

        protected override void DrawSelection(Graphics g)
        {
            var pen = new Pen(Color.Red, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;

            var ltx = points.Min(p => p.X);
            var lty = points.Min(p => p.Y);
            var rbx = points.Max(p => p.X);
            var rby = points.Max(p => p.Y);

            g.DrawRectangle(pen, ltx, lty,
                rbx - ltx, rby - lty);
        }
    }
}
