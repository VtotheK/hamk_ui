using System;
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
            int ringHeight = 100;
            int ringWidth = 100;
            double x = (OlympicCanvas.ActualWidth / 2.0) - (2.2 * ringWidth);
            double y = OlympicCanvas.ActualHeight / 2 - (1.5 * ringHeight);
            SolidColorBrush[] ringcolors = {Brushes.Blue, Brushes.Yellow, Brushes.Black, Brushes.Green, Brushes.Red};
            for (int i = 0; i < ringcolors.Length; ++i)
            {
                Ellipse ring = new Ellipse();
                ring.Height = ringHeight;
                ring.Width = ringWidth;
                ring.Fill = ringcolors[i];
                OlympicCanvas.Children.Add(ring);
                Canvas.SetLeft(ring, x);
                Canvas.SetTop(ring, y);
                rings.Add(ring);
                if (i % 2 != 0)
                {
                    x += ringWidth;
                    y += ringHeight;
                }
                else
                {
                    x += ringWidth;
                    y -= ringHeight;
                }
            }
        }
    }
}
