using Notepad.ViewModel;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Notepad.View
{
    /// <summary>
    /// Interaction logic for FormatWindow.xaml
    /// </summary>
    public partial class FormatWindow : Window
    {
        FormatViewModel vm;
        public FormatWindow(FormatViewModel viewModel)
        {
            InitializeComponent();
            vm = viewModel;
            DataContext = viewModel;
        }

        private void FontSizeNonMVVM(object sender, RoutedEventArgs e)
        {
            var item = FontSizeListBox.SelectedItem as ListBoxItem;
            vm.DocForm.FontSize = Convert.ToInt32(item.Content.ToString());
        }

        private void FontColorNonMVVM(object sender, RoutedEventArgs e)
        {
            var checkedValue = RadioPanel.Children.OfType<RadioButton>()
                 .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);
            SolidColorBrush brush;
            switch (checkedValue.Content.ToString())
            {
                case "Red":
                    brush = Brushes.Red;
                    break;
                case "Blue":
                    brush = Brushes.Blue;
                    break;
                case "Black":
                    brush = Brushes.Black;
                    break;
                case "Green":
                    brush = Brushes.Green;
                    break;
                default:
                    brush = Brushes.Black;
                    break;
            }
            vm.DocForm.FontColor = brush;
        }

        private void CloseWindowFromButton(object sender, RoutedEventArgs e)
        {
            this.Closed -= CloseWindow;
            this.Close();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            vm.cRevertChanges();
        }
    }
}
