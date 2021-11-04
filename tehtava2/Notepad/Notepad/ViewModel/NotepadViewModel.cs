using System;
using Notepad.View;
namespace Notepad.ViewModel
{
    class NotepadViewModel
    {
        private RelayCommand _formatMenuShow;

        private FileMenuViewModel _fileMenu;
        private EditViewModel _editMenu;
        private FormatViewModel _formatMenu = new FormatViewModel();
        private MainWindow _mainWindow;
        public NotepadViewModel(MainWindow mw)
        {
            _mainWindow = mw;
            _fileMenu = new FileMenuViewModel(this);
            _editMenu = new EditViewModel(mw.Notepad_textbox);
            FormatMenuShow = new RelayCommand(cFormatMenuShow);
        }
        public NotepadViewModel()
        {
        }
        public FileMenuViewModel FileMenu { get => _fileMenu; set => _fileMenu = value; }
        public FormatViewModel FormatMenu { get => _formatMenu; set => _formatMenu = value; }
        private MainWindow MainWindow { get => _mainWindow;}
        public EditViewModel EditMenu { get => _editMenu; set => _editMenu = value; }
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
