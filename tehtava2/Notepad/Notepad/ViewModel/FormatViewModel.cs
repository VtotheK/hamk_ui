using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Notepad.Model;


namespace Notepad.ViewModel
{
    public class FormatViewModel  
    {
        private DocumentFormat _docForm;
        private RelayCommand _saveFormat;

        public FormatViewModel()
        {
            _docForm = new DocumentFormat();
            SaveFormat = new RelayCommand(cSaveForm);
        }

        public RelayCommand SaveFormat { get => _saveFormat; set => _saveFormat = value; }
        public DocumentFormat DocForm { get => _docForm; set => _docForm = value; }

        public void cSaveForm()
        {

        }
    }
}
