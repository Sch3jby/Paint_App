using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cv3
{
    public partial class Form1 : Form
    {
        // Circle c1, c2;
        /*
        List<Circle> circles = new List<Circle>();
        List<Rectangle> rectangles = new List<Rectangle>();
        */
        List<Geometry> items = new List<Geometry>();

        List<Point> points = new List<Point>();

        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Clear();
            comboBox1.Items.Add(nameof(Circle));
            comboBox1.Items.Add(nameof(Rectangle));
            comboBox1.Items.Add(nameof(Polygon));
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /*
            if(c1 != null)
                c1.Draw(e.Graphics);
            c2?.Draw(e.Graphics);
            */

            /*
            for (int i = 0; i < circles.Count; i++)
            {
                circles[i].Draw(e.Graphics);
            }

            for (int i = 0; i < rectangles.Count; i++)
            {
                rectangles[i].Draw(e.Graphics);
            }
            */

            for (int i = 0; i < items.Count; i++)
            {
                /*
                if(items[i] is Circle)
                    (items[i] as Circle).Draw(e.Graphics);
                if (items[i] is Rectangle)
                    (items[i] as Rectangle).Draw(e.Graphics);
                */
                items[i].Draw(e.Graphics);
            }
            /*
            Point[] points = new Point[5];
            points[0] = new Point(100, 150);

            points = new Point[]
            {
                new Point(100, 150),
                new Point(120, 170)
            };

            var list = new List<Point>();
            list.Add(new Point(100, 200));
            list.Add(new Point(200, 220));
            list.Add(new Point(150, 300));

            var pen = new Pen(Color.Red, 2);
            e.Graphics.DrawPolygon(pen, list.ToArray());
            */
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /*
            c1 = new Circle(100, 80, 25);
            c2 = new Circle(150, 220, 50);
            */
            /*
            circles.Add(new Circle(100, 80, 25));
            circles.Add(new Circle(150, 220, 50));

            rectangles.Add(new Rectangle(200, 150, 300, 160));
            rectangles.Add(new Rectangle(300, 220, 600, 300));
            */
            items.Add(new Circle(100, 80, 25));
            items.Add(new Circle(150, 220, 50));

            items.Add(new Rectangle(200, 150, 300, 160));
            items.Add(new Rectangle(300, 220, 600, 300));

            //items.Add(new Geometry());

            items.Add(new Polygon(new Point[]
            {
                new Point(100, 150),
                new Point(120, 170),
                new Point(300, 200),
                new Point(70, 180)
            }));

            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                points.Add(e.Location);

            if(points.Count == 2 && (string)comboBox1.SelectedItem == nameof(Circle))
            {
                var radius = Math.Sqrt(Math.Pow(points[0].X - points[1].X, 2)
                    + Math.Pow(points[0].Y - points[1].Y, 2));
                items.Add(new Circle(points[0].X, points[0].Y, (int)radius,
                    (int)numericUpDown1.Value, panel1.BackColor));
                points.Clear();
                Invalidate();
            }
            if (points.Count == 2 && (string)comboBox1.SelectedItem == nameof(Rectangle))
            {               
                items.Add(new Rectangle(points[0].X, points[0].Y, points[1].X, points[1].Y,
                    (int)numericUpDown1.Value, panel1.BackColor));
                points.Clear();
                Invalidate();
            }
            if(points.Count > 2 
                && (string)comboBox1.SelectedItem == nameof(Polygon)
                && e.Button == MouseButtons.Right)
            {
                items.Add(new Polygon(points.ToArray(), (int)numericUpDown1.Value, 
                    panel1.BackColor));
                points.Clear();
                Invalidate();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            points.Clear();
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }
        }
    }
}
