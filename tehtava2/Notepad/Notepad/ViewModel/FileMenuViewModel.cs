using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Notepad.Model;

namespace Notepad.ViewModel
{

    class FileMenuViewModel
    {
        private Document _doc = new Document();
        private RelayCommand _saveFile;
        private RelayCommand _openFile;

        public FileMenuViewModel() {
            SaveFile = new RelayCommand(cSaveFile);
            OpenFile = new RelayCommand(cOpenFile);
            Doc.FilePath = "YEAHHAHWE";
        }

        public Document Doc { get => _doc; set => _doc = value; }
        public RelayCommand SaveFile { get => _saveFile; set => _saveFile = value; }
        public RelayCommand OpenFile { get => _openFile; set => _openFile = value; }
        public void cSaveFile()
        {
            Doc.FilePath = "YSAYDASYD";
            if (Doc.FilePath != null && !string.IsNullOrWhiteSpace(Doc.FilePath))
            {
                /*
                try
                {
                    System.IO.File.WriteAllText(Doc.FilePath, Doc.Content);
                }
                catch (UnauthorizedAccessException uae)
                {
                    throw;
                }
                */
            }
        }
        public void cOpenFile()
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.DefaultExt = ".txt";
            diag.Filter = "Text files (.txt)|*.txt|All files (*.*)|*.*";
            diag.ShowDialog();
        }
    }
}
