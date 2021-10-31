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
        private NotepadTextFile notepadTextFile;
        public NotepadViewModel()
        {

        }

        public void SaveFile(string content)
        {
            if (notepadTextFile.FilePath != null && !String.IsNullOrWhiteSpace(notepadTextFile.FilePath))
            {
                try
                {
                    File.WriteAllText(notepadTextFile.FilePath, content);
                }
                catch (UnauthorizedAccessException uae)
                {
                    throw;
                }
            }
        }
    }
}
