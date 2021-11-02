using System;

namespace Notepad.ViewModel
{
    class NotepadViewModel
    {
        private FileMenuViewModel _fileMenu;
        private EditViewModel _editMenu;
        private FormatMenuViewModel _formatMenu = new FormatMenuViewModel();
        private MainWindow _mainWindow;
        public NotepadViewModel(MainWindow mw)
        {
            _mainWindow = mw;
            _fileMenu = new FileMenuViewModel(this);
            _editMenu = new EditViewModel(mw.Notepad_textbox);
        }
        public NotepadViewModel()
        {
        }
        public FileMenuViewModel FileMenu { get => _fileMenu; set => _fileMenu = value; }
        public FormatMenuViewModel FormatMenu { get => _formatMenu; set => _formatMenu = value; }
        private MainWindow MainWindow { get => _mainWindow;}
        public EditViewModel EditMenu { get => _editMenu; set => _editMenu = value; }

        public string NotepadTextFieldContentGet()
        {
            Console.WriteLine(MainWindow.Notepad_textbox.Text);
            return MainWindow.Notepad_textbox.Text;
        }
    }
}
