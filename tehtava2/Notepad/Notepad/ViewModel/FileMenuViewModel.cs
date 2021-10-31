using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notepad.Model;

namespace Notepad.ViewModel
{

    class FileMenuViewModel
    {
        private Document _doc = new Document();
        private RelayCommand _saveFile;

        public FileMenuViewModel() {
            SaveFile = new RelayCommand(Save);
            Doc.FilePath = "YEAHHAHWE";
        }

        public Document Doc { get => _doc; set => _doc = value; }
        public RelayCommand SaveFile { get => _saveFile; set => _saveFile = value; }

        public void Save()
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
    }
}
