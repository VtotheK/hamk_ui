using Notepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Media;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double scrollY = 0;
        NotepadViewModel vm;
        public MainWindow()
        {
            string lang = Properties.Settings.Default.AppLang;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            InitializeComponent();
            vm = new NotepadViewModel(this);
            DataContext = vm;
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
            InkCanvas canvas = (InkCanvas)Notepad_inkcanvas;
            double textBoxHeight = textBox.ActualHeight;
            Notepad_inkcanvas.Height = textBoxHeight;
            Matrix moveMatrix = new Matrix(1, 0, 0, 1, 0, scrollY - scrollBar.VerticalOffset);
            canvas.Strokes.Transform(moveMatrix, false);
            scrollY = scrollBar.VerticalOffset;
        }
    }
}