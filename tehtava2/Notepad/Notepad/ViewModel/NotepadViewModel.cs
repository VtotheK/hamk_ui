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
        private FileMenuViewModel _fileMenu = new FileMenuViewModel();
        public NotepadViewModel()
        {
        }
        public FileMenuViewModel FileMenu { get => _fileMenu; set => _fileMenu = value; }
    }
}
