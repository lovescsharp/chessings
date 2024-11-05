using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessings
{
    public partial class Form1 : Form
    {
        Pen p = new Pen(Color.Black, 2);
        static Point center = new Point();
        static List<Point> s = new List<Point>();
        Timer t = new Timer();
        public Form1()
        {
            InitializeComponent();
            center = new Point(Width / 2, Height / 2);
            s.Add(new Point(center.X - 50, center.Y - 50));
            s.Add(new Point(s[0].X + 100, s[0].Y));
            s.Add(new Point(s[0].X, s[0].Y + 100));
            s.Add(new Point(s[0].X + 100, s[0].Y + 100));
            t.Interval = 200;
            t.Tick += new EventHandler(tick);
            t.Start();
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
                //rotating by pi/6
                //int X = (int)((s[i].X - center.X) * 1.7321 / 2 - (s[i].Y - center.Y) / 2); int Y = (int)((s[i].X - center.X) / 2 + (s[i].Y - center.Y) * 1.7321 / 2);

                //rotating by pi/2 (makes no difference but still)
                //int X = -(s[i].Y - center.Y); int Y = s[i].X - center.X;

                //rotating by pi/4
                int X = (int)((s[i].X - center.X) * 1.414 / 2 - (s[i].Y - center.Y) * 1.414 / 2);
                int Y = (int)((s[i].X - center.X) * 1.414 / 2 + (s[i].Y - center.Y) * 1.414 / 2);


                s[i] = new Point(X + center.X, Y + center.Y);
            }
            Invalidate();
        }
    }
}
