using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;
using Notepad.ViewModel;
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

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
