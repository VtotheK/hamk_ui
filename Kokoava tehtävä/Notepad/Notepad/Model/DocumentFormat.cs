using System.Windows.Media;

namespace Notepad.Model
{
    public class DocumentFormat : ObservableObject
    {
        private int _fontSize;
        private SolidColorBrush _fontColor;

        public DocumentFormat(int fontSize, SolidColorBrush fontColor)
        {
            _fontSize = fontSize;
            _fontColor = fontColor;
        }
        public DocumentFormat()
        {
            _fontSize = 22;
            _fontColor = Brushes.Black;
        }

        public int FontSize
        {
            get { return _fontSize; }
            set
            {
                OnPropertyChanged(ref _fontSize, value);
            }
        }
        public SolidColorBrush FontColor
        {
            get { return _fontColor; }
            set
            {
                OnPropertyChanged(ref _fontColor, value);
            }
        }
    }
}
