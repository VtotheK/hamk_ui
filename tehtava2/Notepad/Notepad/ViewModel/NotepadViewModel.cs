using System;

namespace Notepad.ViewModel
{
    class NotepadViewModel
    {
        private FileMenuViewModel _fileMenu;
        private FormatMenuViewModel _formatMenu = new FormatMenuViewModel();
        private MainWindow _mainWindow;
        public NotepadViewModel(MainWindow mw)
        {
            _mainWindow = mw;
            _fileMenu = new FileMenuViewModel(this);
        }
        public NotepadViewModel()
        {
        }
        public FileMenuViewModel FileMenu { get => _fileMenu; set => _fileMenu = value; }
        public FormatMenuViewModel FormatMenu { get => _formatMenu; set => _formatMenu = value; }
        private MainWindow MainWindow { get => _mainWindow;}

        public string NotepadTextFieldContentGet()
        {
            Console.WriteLine(MainWindow.Notepad_textbox.Text);
            return MainWindow.Notepad_textbox.Text;
        }
    }
}
