using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notepad.Model;

namespace Notepad.ViewModel
{
    class NotepadViewModel
    {
        private Document _doc = new Document();
        public NotepadViewModel()
        {
            Doc.FilePath = "Testtext";
        }

        public Document Doc { get => _doc ; set => _doc = value; }

        public void SaveFile(string content)
        {
            if (Doc.FilePath != null && !string.IsNullOrWhiteSpace(Doc.FilePath))
            {
                try
                {
                    System.IO.File.WriteAllText(Doc.FilePath, content);
                }
                catch (UnauthorizedAccessException uae)
                {
                    throw;
                }
            }
        }
    }
}
