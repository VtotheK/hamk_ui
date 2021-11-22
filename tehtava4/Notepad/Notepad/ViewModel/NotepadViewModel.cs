using System.Windows.Input;
using Notepad.View;
namespace Notepad.ViewModel
{
    class NotepadViewModel
    {
        private RelayCommand _formatMenuShow;

        private FileMenuViewModel _fileMenu;
        private FormatViewModel _formatMenu = new FormatViewModel();
        private MainWindow _mainWindow;
        public NotepadViewModel(MainWindow mw)
        {
            _mainWindow = mw;
            _fileMenu = new FileMenuViewModel(this);
            FormatMenuShow = new RelayCommand(cFormatMenuShow);
        }
        public NotepadViewModel()
        {
        }
        public FileMenuViewModel FileMenu { get => _fileMenu; set => _fileMenu = value; }
        public FormatViewModel FormatMenu { get => _formatMenu; set => _formatMenu = value; }
        private MainWindow MainWindow { get => _mainWindow; }
        public RelayCommand FormatMenuShow { get => _formatMenuShow; set => _formatMenuShow = value; }

        public string NotepadTextFieldContentGet()
        {
            return MainWindow.Notepad_textbox.Text;
        }

        public void cFormatMenuShow()
        {
            FormatWindow fw = new FormatWindow(FormatMenu);
            fw.Show();
        }
    }
}
