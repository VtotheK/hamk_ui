﻿using System;
using System.Reflection;
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
        private string _filePath = null;
        private string _content = "";
        private string _fileName = null;

        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                OnPropertyChanged(ref _filePath, value);
            }
        }

        public string Content {
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
    }
}
