using System;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Model
{
    public class DocumentFormat : ObservableObject
    {
        private int _fontSize;
        private SolidColorBrush _fontColor;

        public int FontSize
        {
            get { return _fontSize; }
            set
            {
                Console.WriteLine(value);
                OnPropertyChanged(ref _fontSize, value);
            }
        }
        public SolidColorBrush FontColor  
        {
            get { return _fontColor; }
            set
            {
                Console.WriteLine(value);
                OnPropertyChanged(ref _fontColor, value);
            }
        }
    }
}
