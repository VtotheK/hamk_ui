using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notepad.Model;
using Notepad;
using System.Windows;

namespace Notepad.ViewModel
{

    class FileMenuViewModel
    {
        private Document _doc = new Document();
        private RelayCommand _saveFile;
        private RelayCommand _openFile;
        private RelayCommand _newFile;
        private RelayCommand _printFile;
        private RelayCommand _closeNotepad;
        private NotepadViewModel _notepadViewModel;
        public FileMenuViewModel() {
            CreateCommand();
        }
        public FileMenuViewModel(NotepadViewModel nv){
            _notepadViewModel = nv;
            CreateCommand();
        }
        private void CreateCommand()
        {
            SaveFile = new RelayCommand(cSaveFile);
            NewFile = new RelayCommand(cNewFile);
            OpenFile = new RelayCommand(cOpenFile);
            CloseNotepad = new RelayCommand(cCloseNotepad);
            PrintFile = new RelayCommand(cPrintFile);
        }
        public Document Doc { get => _doc; set => _doc = value; }
        public RelayCommand SaveFile { get => _saveFile; set => _saveFile = value; }
        public RelayCommand NewFile { get => _newFile; set => _newFile = value; }
        public RelayCommand PrintFile { get => _printFile; set => _printFile = value; }
        public RelayCommand CloseNotepad { get => _closeNotepad; set => _closeNotepad = value; }
        public RelayCommand OpenFile { get => _openFile; set => _openFile = value; }
        private NotepadViewModel NotepadViewModel { get => _notepadViewModel;}

        public void cSaveFile()
        {
            if (Doc.FilePath != null && !string.IsNullOrWhiteSpace(Doc.FilePath))
            {
                File.WriteAllText(Doc.FilePath, NotepadViewModel.NotepadTextFieldContentGet());
            }
        }
        public void cOpenFile()
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.DefaultExt = ".txt";
            diag.Filter = "Text files (.txt)|*.txt|All files (*.*)|*.*";
            if(diag.ShowDialog() == DialogResult.OK)
            {
                Doc.FilePath = diag.FileName;
                Doc.FileName = Path.GetFileName(diag.FileName);
                PopulateTextBox(Doc);
            }
        }

        public void cNewFile()
        {
            if (Doc.Edited)
            {
                if (System.Windows.MessageBox.Show("Are you sure you want to open a new file? All unsaved work will be lost.", "Message",
                MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    return;
                }

            }
            Doc.FilePath = String.Empty;
            Doc.FileName = String.Empty;
            Doc.Content = String.Empty;
            Doc.Edited = false;      
        }
        
        private void cCloseNotepad()
        {
            throw new NotImplementedException();
        }
        private void cPrintFile()
        {
            throw new NotImplementedException();
        }
        
        private void PopulateTextBox(Document doc)
        {
            if (doc.FilePath != null && !string.IsNullOrWhiteSpace(doc.FilePath))
            {
                doc.Content = File.ReadAllText(doc.FilePath);
            }
        }
    }
}
