using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Notepad.Headers;
using Notepad.Model;

namespace Notepad.Utils
{
    static class FileUtils 
    {
        public static void WriteDocumentToFile(Document doc)
        {
            string SigBase64 = "";
            using (System.IO.MemoryStream ms = new MemoryStream())
            {
                doc.ImageNotes.Save(ms, false);
                byte[] byteImage = ms.ToArray();
                ms.Position = 0;
                Encoding encoding = Encoding.UTF8;
                byte[] textArray = encoding.GetBytes(doc.Content);
                SigBase64 = Convert.ToBase64String(byteImage); // Get Base64
                FileHeader header = new FileHeader(SigBase64.Length, doc.Content.Length);
                var formatter = new BinaryFormatter();
                ms.Position = 0;
                formatter.Serialize(ms, header);
                ms.Position = 0;
                using (FileStream fs = File.Open(doc.FilePath, FileMode.Create))
                {
                    fs.Write(BitConverter.GetBytes(FileHeader.HeaderMagic), 0, Marshal.SizeOf(typeof(int)));
                    fs.Write(BitConverter.GetBytes(header.StrokeCollectionSize), 0, Marshal.SizeOf(typeof(int)));
                    fs.Write(BitConverter.GetBytes(header.TextSize), 0, Marshal.SizeOf(typeof(int)));
                    fs.Write(byteImage, 0, byteImage.Length);
                    fs.Write(textArray, 0, textArray.Length);
                }
            }
        }

        public static Document ReadDocumentFromFile(string path)
        {
            byte[] fileArr = File.ReadAllBytes(path);
            using (MemoryStream ms = new MemoryStream(fileArr))
            {
                FileHeader header = ExtractHeader(ms);
                if(header.Header != FileHeader.HeaderMagic)
                {
                    Console.WriteLine("Invalid file");
                }
            }
            return null;
        }

        private static FileHeader ExtractHeader(MemoryStream ms)
        {
            byte[] headerMagic = new byte[sizeof(int)];
            byte[] strokeCollectionSize= new byte[sizeof(int)];
            byte[] textFileSize = new byte[sizeof(int)];
            FileHeader header = new FileHeader();
            header.Header = ms.Read(headerMagic, 0, Marshal.SizeOf(typeof(int)));
            header.StrokeCollectionSize = ms.Read(strokeCollectionSize, 0, Marshal.SizeOf(typeof(int)));
            header.TextSize = ms.Read(textFileSize, 0, Marshal.SizeOf(typeof(int)));
            return header;
        }
    }
}
