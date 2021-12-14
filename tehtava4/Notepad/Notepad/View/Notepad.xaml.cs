﻿using Notepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Media;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Reflection;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InkCanvas canvas; 
        NotepadViewModel vm;
        Dictionary<string, System.Windows.Media.Color> colors = new Dictionary<string, System.Windows.Media.Color>();
        public MainWindow()
        {
            string lang = Properties.Settings.Default.AppLang;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            InitializeComponent();
            vm = new NotepadViewModel(this);
            canvas = (InkCanvas)Notepad_inkcanvas;
            canvas.Strokes.StrokesChanged += Strokes_StrokesChanged;
            PopulateColorPanel();
            DataContext = vm;
        }

        private void PopulateColorPanel()
        {
            Type c = typeof(System.Windows.Media.Colors);
            PropertyInfo[] props = c.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo info in props)
            {
                InkCanvasColors.Items.Add(CreateColorStackPanel(info.Name));
            }
        }

        private StackPanel CreateColorStackPanel(string name)
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
            rect.Width = 20;
            rect.Height= 20;
            System.Windows.Media.ColorConverter converter = new System.Windows.Media.ColorConverter();
            System.Windows.Media.Color c = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(name);
            colors[name] = c;
            rect.Fill = new SolidColorBrush(c);
            rect.StrokeThickness = 2;
            TextBlock textBlock = new TextBlock();
            textBlock.Text = name;
            textBlock.Name = name;
            sp.Children.Add(rect);
            sp.Children.Add(textBlock);
            return sp;
        }

        private void Strokes_StrokesChanged(object sender, System.Windows.Ink.StrokeCollectionChangedEventArgs e)
        {
            vm.FileMenu.Doc.ImageNotes.Add(e.Added);
            vm.FileMenu.Doc.ImageNotes.Remove(e.Removed);
        }

        private void ChangeLanguageEn(object sender, RoutedEventArgs e)
        {
            string lang = Properties.Settings.Default.AppLang;
            if(lang != "en-EN") { 
                MessageBox.Show("Language will change after restart.", "Info", MessageBoxButton.OK);
                Properties.Settings.Default.AppLang = "en-EN";
                Properties.Settings.Default.Save();
            }
        }

        private void ChangeLanguageSwe(object sender, RoutedEventArgs e)
        {
            string lang = Properties.Settings.Default.AppLang;
            if(lang != "se-SE") { 
                MessageBox.Show("Language will change after restart.", "Info", MessageBoxButton.OK);
                Properties.Settings.Default.AppLang = "se-SE";
                Properties.Settings.Default.Save();
            }
        }

        private void ScrollViewer_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
        {
            TextBox textBox = (TextBox)Notepad_textbox;
            ScrollViewer scrollBar = (ScrollViewer)sender;
            canvas.Margin = new Thickness(0, -scrollBar.VerticalOffset,0,0);
        }

        private void Colors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sp = (StackPanel)InkCanvasColors.SelectedValue;
            var child = (TextBlock)sp.Children[1];
            System.Windows.Media.Color selectedColor = new System.Windows.Media.Color();
            if(colors.TryGetValue(child.Name,out selectedColor))
            {
                canvas.DefaultDrawingAttributes.Color = selectedColor;
            }
        }
    }
}