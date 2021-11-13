using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Olympiarenkaat
{
    public class MyCanvas : Canvas 
    {
        List<Ellipse> rings = new List<Ellipse>();
        double x;
        double y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public List<Ellipse> Rings { get => rings; set => rings = value; }

        protected override void OnRender(DrawingContext dc)
        {
            foreach (var ring in Rings)
            {
                double width = ring.Width;
                double height = ring.Height;
                Brush brush = ring.Stroke;
                double thickness = ring.StrokeThickness;
                dc.DrawEllipse(brush, new Pen(brush, thickness), new Point(X, Y), width + new Random().Next(10,200), height);
            }
        }
    }
}
