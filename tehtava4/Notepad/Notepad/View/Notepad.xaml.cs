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

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double scrollY = 0;
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
            DataContext = vm;
        }

        private void Strokes_StrokesChanged(object sender, System.Windows.Ink.StrokeCollectionChangedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight, 96, 96, System.Windows.Media.PixelFormats.Default);
            rtb.Render(canvas);
            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            rtb.Render(canvas);
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (Bitmap bitmap = new Bitmap(ms))
                {
                    encoder.Save(ms);
                    if (vm.FileMenu.Doc.ImageNotes != null)
                        vm.FileMenu.Doc.ImageNotes.Dispose();
                    vm.FileMenu.Doc.ImageNotes = (Bitmap)bitmap.Clone();
                }
            }
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
            double textBoxHeight = textBox.ActualHeight;
            Notepad_inkcanvas.Height = textBoxHeight;
            Matrix moveMatrix = new Matrix(1, 0, 0, 1, 0, scrollY - scrollBar.VerticalOffset);
            canvas.Strokes.Transform(moveMatrix, false);
            scrollY = scrollBar.VerticalOffset;
        }
    }
}