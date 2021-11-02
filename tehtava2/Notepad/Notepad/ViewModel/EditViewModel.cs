using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.ViewModel
{
    class EditViewModel
    {
        private RelayCommand _copy;
        private RelayCommand _paste;
        private TextBox _notepadTextField;
        public EditViewModel(TextBox field)
        {
            _notepadTextField = field;
            Copy = new RelayCommand(cCopy);
            Paste = new RelayCommand(cPaste);
        }

        public RelayCommand Copy { get => _copy; set => _copy = value; }
        public RelayCommand Paste { get => _paste; set => _paste = value; }
        public TextBox NotepadTextField { get => _notepadTextField; }

        public void cCopy()
        {
            Clipboard.SetText(NotepadTextField.Text);
        }
        public void cPaste()
        {
            NotepadTextField.Text += Clipboard.GetText();

        }
    }
}
