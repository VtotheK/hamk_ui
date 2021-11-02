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
        private RelayCommand _saveFileAs;
        private NotepadViewModel _notepadViewModel;
        public FileMenuViewModel()
        {
            CreateCommands();
        }
        public FileMenuViewModel(NotepadViewModel nv)
        {
            _notepadViewModel = nv;
            CreateCommands();
        }
        private void CreateCommands()
        {
            SaveFile = new RelayCommand(cSaveFile);
            NewFile = new RelayCommand(cNewFile);
            OpenFile = new RelayCommand(cOpenFile);
            CloseNotepad = new RelayCommand(cCloseNotepad);
            PrintFile = new RelayCommand(cPrintFile);
            PrintFile = new RelayCommand(cSaveFileAs);
        }
        public Document Doc { get => _doc; set => _doc = value; }
        public RelayCommand SaveFile { get => _saveFile; set => _saveFile = value; }
        public RelayCommand NewFile { get => _newFile; set => _newFile = value; }
        public RelayCommand PrintFile { get => _printFile; set => _printFile = value; }
        public RelayCommand CloseNotepad { get => _closeNotepad; set => _closeNotepad = value; }
        public RelayCommand OpenFile { get => _openFile; set => _openFile = value; }
        public RelayCommand SaveFileAs { get => _saveFileAs; set => _saveFileAs = value; }
        private NotepadViewModel NotepadViewModel { get => _notepadViewModel; }

        public void cSaveFile()
        {
            if (Doc.FilePath != null && !string.IsNullOrWhiteSpace(Doc.FilePath))
            {
                File.WriteAllText(Doc.FilePath, NotepadViewModel.NotepadTextFieldContentGet());
            }
            else 
            {
                cSaveFileAs();
            }
        }
        
        public void cSaveFileAs()
        {
            var diag = new SaveFileDialog();
            diag.Filter = "Text files (.txt)|*.txt|All files (*.*)|*.*";
            diag.DefaultExt = ".txt";
            if(diag.ShowDialog() == DialogResult.OK)
            {
                string path = diag.FileName;
                Doc.Content = NotepadViewModel.NotepadTextFieldContentGet();
                Doc.FilePath = path;
                Doc.FileName = Path.GetFileName(path);
                File.WriteAllText(path, Doc.Content);
            }
        }
        public void cOpenFile()
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.DefaultExt = ".txt";
            diag.Filter = "Text files (.txt)|*.txt|All files (*.*)|*.*";
            if (diag.ShowDialog() == DialogResult.OK)
            {
                if (IsDocumentEdited())
                {
                    if (System.Windows.MessageBox.Show("Are you sure you want to open a new file? All unsaved work will be lost.", "Message",
                    MessageBoxButton.YesNo) == MessageBoxResult.No)
                    {
                        return;
                    }
                }
                Doc.FilePath = diag.FileName;
                Doc.FileName = Path.GetFileName(diag.FileName);
                PopulateTextBox(Doc);
            }
        }

        public void cNewFile()
        {
            if (IsDocumentEdited())
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
            if (doc.FilePath != null && !String.IsNullOrWhiteSpace(doc.FilePath))
            {
                doc.Content = File.ReadAllText(doc.FilePath);
            }
        }

        private bool IsDocumentEdited()
        {
            Console.WriteLine(NotepadViewModel.NotepadTextFieldContentGet() != Doc.Content);
            return NotepadViewModel.NotepadTextFieldContentGet() != Doc.Content; 
        }
        private bool IsDocumentOpen()
        {
            return Doc.FilePath != null && !string.IsNullOrWhiteSpace(Doc.FilePath); 
        }
    }
}
