using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace chessings
{
    public partial class Form1 : Form
    {
        Pen p = new Pen(Color.Black, 2);
        static Point center = new Point();
        static List<PointF> s = new List<PointF>();
        Timer t = new Timer();
        public Form1()
        {
            InitializeComponent();
            Size x = new Size(200, 200); //change size, you can make rectangles btw not only squares
            center = new Point(Width / 2, Height / 2);
            s.Add(new PointF (center.X - x.Width/2, center.Y - x.Height/2));
            s.Add(new PointF (s[0].X + x.Width, s[0].Y));
            s.Add(new PointF (s[0].X, s[0].Y + x.Height));
            s.Add(new PointF (s[0].X + x.Width, s[0].Y + x.Height));
            t.Interval = 10;
            t.Tick += new EventHandler(tick);
            t.Start();
            Resize += new EventHandler(OnResize);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine (p, s[0], s[1]);
            e.Graphics.DrawLine (p, s[2], s[3]);
            e.Graphics.DrawLine (p, s[0], s[2]);
            e.Graphics.DrawLine (p, s[1], s[3]);
        }

        private void tick(object sender, EventArgs e)
        {
            for (int i = 0; i < s.Count; i++)
            {
                float X = (float) ((s[i].X - center.X) * Math.Cos(Math.PI/120) - (s[i].Y - center.Y) * Math.Sin(Math.PI / 120)); 
                float Y = (float) ((s[i].X - center.X) * Math.Sin(Math.PI / 120) + (s[i].Y - center.Y) * Math.Cos(Math.PI/120));

                //rotating by pi/2 (makes no difference but still)
                //int X = -(s[i].Y - center.Y); int Y = s[i].X - center.X;

                s[i] = new PointF(X + center.X, Y + center.Y);
            }
            Invalidate();
        }
        protected void OnResize(object sender, EventArgs e)
        {
            center = new Point(Width / 2, Height / 2);
            Invalidate();
        }
    }
}
