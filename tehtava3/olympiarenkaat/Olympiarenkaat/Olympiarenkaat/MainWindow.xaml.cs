﻿using System;
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
    }
}
