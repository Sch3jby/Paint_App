using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv3
{
    public class Rectangle : Geometry
    {        
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            OX = (x1 + x2) / 2;
            OY = (y1 + y2) / 2;
            Width = Math.Abs(x2 - x1);
            Height = Math.Abs(y2 - y1);
        }

        public Rectangle(int x1, int y1, int x2, int y2, int penWidth)
            : this(x1, y1, x2, y2)
        {
            PenWidth = penWidth;
        }

        public Rectangle(int x1, int y1, int x2, int y2, int penWidth, Color penColor)
            : this(x1, y1, x2, y2, penWidth)
        {
            PenColor = penColor;
        }

        public Rectangle(int x1, int y1, int x2, int y2, int penWidth, Color penColor,
            Color fillColor)
            : this(x1, y1, x2, y2, penWidth, penColor)
        {
            FillColor = fillColor;
        }

        internal override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            var pen = new Pen(PenColor, PenWidth);
            graphics.DrawRectangle(pen,
                OX - (Width / 2), OY - (Height / 2), Width, Height);
        }
    }
}
