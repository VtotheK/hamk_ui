using System.Drawing;
using System.Windows.Controls;
using System.Windows.Ink;

namespace Notepad.Model
{
    class Document : ObservableObject
    {
        private string _filePath = null;
        private string _content = "";
        private string _fileName = null;
        private StrokeCollection _imageNotes = new StrokeCollection();
        public Document() { }
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                OnPropertyChanged(ref _filePath, value);
            }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                OnPropertyChanged(ref _content, value);
            }
        }
        public string FileName
        {
            get { return _fileName; }
            set
            {
                OnPropertyChanged(ref _fileName, value);
            }
        }

        public StrokeCollection ImageNotes 
        {
            get { return _imageNotes; }
            set
            {
                OnPropertyChanged(ref _imageNotes, value);
            }
        }
    }
}
