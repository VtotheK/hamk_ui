using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Olympiarenkaat
{
    public class MyCanvas : Canvas
    {
        private SolidColorBrush[] ringcolors = { Brushes.Blue, Brushes.Yellow, Brushes.Black, Brushes.Green, Brushes.Red };
        double addY = 0;
        double addX = 0;
        int[] xDirs = {-1, 0, 0, 2, 1 };
        int[] yDirs = { 1, 1, 2, 2, 1 };

        public double AddX { get => addX; set { addX = value; InvalidateVisual(); } }
        public double AddY { get => addY; set { addY = value; InvalidateVisual(); } }

        protected override void OnRender(DrawingContext dc)
        {
            int ringHeight = 120;
            int ringWidth = 120;
            int thickness = 10;
            double x = (this.ActualWidth / 2.0) - (1.8 * ringWidth);
            double y = this.ActualHeight / 2;
            for (int i = 0; i < ringcolors.Length; i++)
            {
                Pen pen = new Pen();
                pen.Thickness = thickness;
                pen.Brush = ringcolors[i];
                if (i % 2 != 0)
                {
                    x += (ringWidth / 1.8) + (xDirs[i] * AddX);
                    y += (ringHeight / 2.5) + (yDirs[i] * AddY);
                }
                else
                {
                    x += (ringWidth / 1.8) + (xDirs[i] * AddX);
                    y -= (ringHeight / 2.5) + (yDirs[i] * AddY);
                }
                dc.DrawEllipse(null, pen, new Point(x , y), ringWidth/2, ringHeight/2);
            }
        }
    }
}
