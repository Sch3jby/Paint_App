using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv3
{
    public class Circle : Geometry
    {
        public int Radius { get; private set; }

        public Circle(int oX, int oY, int radius)
      //      : this(oX, oY, radius, 1, Color.Black, Color.Black)            
        {
            OX = oX;
            OY = oY;
            Radius = radius;
        }

        public Circle(int oX, int oY, int radius, int penWidth)
            : this(oX, oY, radius)
        {
            PenWidth = penWidth;
        }

        public Circle(int oX, int oY, int radius, int penWidth, Color penColor)
            : this(oX, oY, radius, penWidth)
        {
            PenColor = penColor;
        }

        public Circle(int oX, int oY, int radius, int penWidth, Color penColor,
            Color fillColor)
            : this(oX, oY, radius, penWidth, penColor)
        {
            FillColor = fillColor;
        }

        internal override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            var pen = new Pen(PenColor, PenWidth);
            graphics.DrawEllipse(pen,
                OX - Radius, OY - Radius, 2 * Radius, 2 * Radius);
        }
    }
}
