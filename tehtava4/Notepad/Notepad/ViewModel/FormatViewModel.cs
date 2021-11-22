using Notepad.Model;


namespace Notepad.ViewModel
{
    public class FormatViewModel
    {
        private DocumentFormat _docForm;
        private DocumentFormat _docFormCached;
        private RelayCommand _revertChanges;
        private RelayCommand _applyChanges;

        public FormatViewModel()
        {
            _docForm = new DocumentFormat();
            _docFormCached = new DocumentFormat();
            _revertChanges = new RelayCommand(cRevertChanges);
            _applyChanges = new RelayCommand(cApplyChanges);
        }

        public RelayCommand RevertChanges { get => _revertChanges; set => _revertChanges = value; }
        public DocumentFormat DocForm { get => _docForm; set => _docForm = value; }
        public DocumentFormat DocFormCached { get => _docFormCached; set => _docFormCached = value; }
        public RelayCommand ApplyChanges { get => _applyChanges; set => _applyChanges = value; }

        public void cRevertChanges()
        {
            DocForm.FontColor = DocFormCached.FontColor;
            DocForm.FontSize = DocFormCached.FontSize;
        }

        public void cApplyChanges()
        {
            DocFormCached.FontColor = DocForm.FontColor;
            DocFormCached.FontSize = DocForm.FontSize;
        }
    }
}
