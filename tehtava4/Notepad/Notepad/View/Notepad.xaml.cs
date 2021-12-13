using Notepad.ViewModel;
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
            Type c = typeof(System.Windows.Media.Color);
            PropertyInfo[] props = c.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);

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
    }
}