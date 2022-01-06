using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Headers
{
    [Serializable]
    struct FileHeader
    {
        public const int HeaderMagic = 0xF1F2F3;
        public int StrokeCollectionSize;
        public int TextSize;
        public int Header;

        public FileHeader(int strokeCollectionSize, int textSize, int header)
        {
            StrokeCollectionSize = strokeCollectionSize;
            TextSize = textSize;
            Header = header;
        }
    }
}
