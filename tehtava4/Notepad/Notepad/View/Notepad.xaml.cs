using Notepad.ViewModel;
using System.Windows;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NotepadViewModel vm;
        public MainWindow()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("se-SE");
            InitializeComponent();
            vm = new NotepadViewModel(this);
            DataContext = vm;
        }
    }
}