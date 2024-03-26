using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv3
{
    public abstract class Geometry
    {
        public int OX { get; protected set; }
        public int OY { get; protected set; }
        public int PenWidth { get; set; } = 1;
        public Color PenColor { get; set; } = Color.Black;
        public Color FillColor { get; set; }

        internal virtual void Draw(Graphics graphics)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DrawOrigin(graphics);
        }  
        
        private void DrawOrigin(Graphics g)
        {
            var pen = new Pen(PenColor, 1);
            g.DrawLine(pen, OX - 10, OY, OX + 10, OY);
            g.DrawLine(pen, OX, OY - 10, OX, OY + 10);
        }
    }
}
