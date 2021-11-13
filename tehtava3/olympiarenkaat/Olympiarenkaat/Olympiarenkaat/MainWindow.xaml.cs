using System;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Olympiarenkaat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Ellipse> rings = new List<Ellipse>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateOlympicRings(object sender, RoutedEventArgs e)
        {
            if (rings.Count() > 0)
            {
                foreach (var ring in rings)
                {
                    OlympicCanvas.Children.Remove(ring);
                }
            }
            int ringHeight = 220;
            int ringWidth = 220;
            double x = (OlympicCanvas.ActualWidth / 2.0) - (1.6 * ringWidth);
            double y = OlympicCanvas.ActualHeight / 2 - (ringHeight / 1.2);
            SolidColorBrush[] ringcolors = {Brushes.Blue, Brushes.Yellow, Brushes.Black, Brushes.Green, Brushes.Red};
            for (int i = 0; i < ringcolors.Length; ++i)
            {
                Ellipse ring = new Ellipse();
                ring.Height = ringHeight;
                ring.Width = ringWidth;
                ring.Stroke= ringcolors[i];
                ring.StrokeThickness = 20;
                OlympicCanvas.Children.Add(ring);
                Canvas.SetLeft(ring, x);
                Canvas.SetTop(ring, y);
                rings.Add(ring);
                if (i % 2 == 0)
                {
                    x += ringWidth / 1.8;
                    y += ringHeight / 2.5;
                }
                else
                {
                    x += ringWidth / 1.8;
                    y -= ringHeight / 2.5;
                }
            }
        }

        private void ExplosionAnimation(object sender, RoutedEventArgs e)
        {
            if (rings.Count() <= 0)
            {
                return;
            }
            var rnd = new Random();
            for (int i = 0; i < rings.Count; ++i)
            {
                int randleft = rnd.Next(900,1500);
                int randtop = rnd.Next(900,1500);
                int dirX = rnd.Next(1,3);
                int dirY = rnd.Next(1,3);
                dirX = dirX > 1 ? -1 : 1;
                dirY = dirY > 1 ? -1 : 1;
                double left = Canvas.GetLeft(rings[i]);
                double top = Canvas.GetTop(rings[i]);
                DoubleAnimation xAn = new DoubleAnimation();
                DoubleAnimation yAn = new DoubleAnimation();
                xAn.From = left;
                xAn.To = (left + randleft) * dirX;
                yAn.From = top;
                yAn.To = (top + randtop) * dirY;
                xAn.Duration = new Duration(TimeSpan.Parse("0:0:5"));
                yAn.Duration = new Duration(TimeSpan.Parse("0:0:5"));
                rings[i].BeginAnimation(Canvas.LeftProperty,xAn);
                rings[i].BeginAnimation(Canvas.TopProperty,yAn);
            }
        }
    }
}
