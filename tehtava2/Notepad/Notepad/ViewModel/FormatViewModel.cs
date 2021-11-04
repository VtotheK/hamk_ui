using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notepad.Model;


namespace Notepad.ViewModel
{
    public class FormatViewModel  
    {
        private DocumentFormat _documentFormat;
        private RelayCommand _saveFormat;

        public FormatViewModel()
        {
            _documentFormat = new DocumentFormat();
            SaveFormat = new RelayCommand(cSaveForm);
        }

        public RelayCommand SaveFormat { get => _saveFormat; set => _saveFormat = value; }

        public void cSaveForm()
        {
            Console.WriteLine("here");
        }
    }
}
