using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Notepad.Headers;
using Notepad.Model;

namespace Notepad.Utils
{
    static class FileUtils 
    {
        public static void WriteDocumentToFile(Document doc)
        {
            //string SigBase64 = "";
            using (System.IO.MemoryStream ms = new MemoryStream())
            {
                doc.ImageNotes.Save(ms, false);
                byte[] byteImage = (byte[])ms.ToArray();
                ms.Position = 0;
                Encoding encoding = Encoding.UTF8;
                byte[] textArray = encoding.GetBytes(doc.Content);
                FileHeader header = new FileHeader(byteImage.Length, textArray.Length , FileHeader.HeaderMagic);
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
            Document doc = new Document();
            doc.FilePath = path;
            byte[] fileArr = File.ReadAllBytes(path);
            using (MemoryStream ms = new MemoryStream(fileArr))
            {
                FileHeader header = ExtractHeader(ms);
                if(header.Header != FileHeader.HeaderMagic)
                {
                    MessageBox.Show("Invalid file!", "Error", MessageBoxButton.OK);
                    return null;
                }
                PopulateDocument(doc, header, ms);
            }
            return doc;
        }

        private static void PopulateDocument(Document doc, FileHeader header, MemoryStream ms)
        {
            byte[] strokeCollection = new byte[header.StrokeCollectionSize];
            byte[] textFile = new byte[header.TextSize];
            ms.Read(strokeCollection, 0, header.StrokeCollectionSize);
            ms.Read(textFile, 0, header.TextSize);
            Encoding encoding = Encoding.UTF8;
            using (MemoryStream strokeStream = new MemoryStream(strokeCollection))
            {
                doc.ImageNotes = new System.Windows.Ink.StrokeCollection(strokeStream);
            }
            doc.Content = encoding.GetString(textFile);
        }

        private static FileHeader ExtractHeader(MemoryStream ms)
        {
            FileHeader header = new FileHeader();
            byte[] headerMagic = new byte[sizeof(int)];
            byte[] strokeCollectionSize= new byte[sizeof(int)];
            byte[] textFileSize = new byte[sizeof(int)];
            ms.Read(headerMagic, 0, Marshal.SizeOf(typeof(int)));
            ms.Read(strokeCollectionSize, 0, sizeof(int));
            ms.Read(textFileSize, 0, sizeof(int));

            header.Header = BitConverter.ToInt32(headerMagic,0);
            header.StrokeCollectionSize= BitConverter.ToInt32(strokeCollectionSize,0);
            header.TextSize = BitConverter.ToInt32(textFileSize,0);

            return header;
        }
    }
}
