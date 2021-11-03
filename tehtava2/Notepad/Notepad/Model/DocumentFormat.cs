using System;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Model
{
    class DocumentFormat : ObservableObject
    {
        private int _fontSize;
        private Brush _fontColor;

        public int FontSize
        {
            get { return _fontSize; }
            set
            {
                OnPropertyChanged(ref _fontSize, value);
            }
        }
        public Brush FontColor  
        {
            get { return _fontColor; }
            set
            {
                OnPropertyChanged(ref _fontColor, value);
            }
        }
    }
}
