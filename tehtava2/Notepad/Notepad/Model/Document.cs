using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Notepad.Model
{
    class Document : ObservableObject 
    {
        private string _filePath;
        private bool _edited;
        private string _content;

        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                OnPropertyChanged(ref _filePath, value);
            }
        }
        public bool Edited 
        {
            get { return _edited; }
            set
            {
                OnPropertyChanged(ref _edited, value);
            }
        }

        public string Content {
            get { return _content; }
            set
            {
                OnPropertyChanged(ref _content, value);
            }
        }
    }
}
