using ShoppingVilla.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ShoppingVilla.Common.HelpersClasses
{
    public class Img: IImg
    {
        public byte[] getByteArrayFromBase64String(string bash64String)
        {
            string indexString = "base64,";
            int indexBase64 = bash64String.IndexOf(indexString);
            indexBase64 += indexString.Length;
            string stringtToReplace = bash64String.Substring(0, indexBase64);
            return Convert.FromBase64String(bash64String.Replace(stringtToReplace, ""));

        }

        public byte[] getThumbBytes(byte[] ImgByates)
        {
            byte[] currentByteImageArray = ImgByates;
            MemoryStream inputMemoryStream = new MemoryStream(ImgByates);
            Image fullsizeImage = Image.FromStream(inputMemoryStream);

            if (currentByteImageArray.Length > 1000)
            {
                Bitmap fullSizeBitmap = new Bitmap(fullsizeImage, new Size(100, 100));
                MemoryStream resultStream = new MemoryStream();

                fullSizeBitmap.Save(resultStream, fullsizeImage.RawFormat);
                currentByteImageArray = resultStream.ToArray();
                resultStream.Dispose();
                resultStream.Close();
            }

            return currentByteImageArray;
        }

        public byte[] getTileBytes(byte[] ImgByates)
        {
            byte[] currentByteImageArray = ImgByates;
            MemoryStream inputMemoryStream = new MemoryStream(ImgByates);
            Image fullsizeImage = Image.FromStream(inputMemoryStream);

            if (currentByteImageArray.Length > 1000)
            {
                Bitmap fullSizeBitmap = new Bitmap(fullsizeImage, new Size(250, 250));
                MemoryStream resultStream = new MemoryStream();

                fullSizeBitmap.Save(resultStream, fullsizeImage.RawFormat);
                currentByteImageArray = resultStream.ToArray();
                resultStream.Dispose();
                resultStream.Close();
            }

            return currentByteImageArray;
        }
        public string SaveImg(byte[] ImgBytes, string FilePath, string FileName, string OriginalFileName)
        {
            string newFileName = FileName.Replace(" ", "_") + Path.GetExtension(OriginalFileName);
            string path = "Resources/Images/" + FilePath + "/" + newFileName;
            File.WriteAllBytes(CreateFolder(path), ImgBytes);

            return path;
        }
        public string SaveThumbImg(byte[] ImgBytes, string FilePath, string FileName, string OriginalFileName)
        {
            string newFileName = FileName.Replace(" ", "_") + Path.GetExtension(OriginalFileName);
            string thumbPath = "Resources/Images/" + FilePath + "/Thumbs/" + newFileName;
            File.WriteAllBytes(CreateFolder(thumbPath), getThumbBytes(ImgBytes));

            return thumbPath;
        }

        public string SaveTileImg(byte[] ImgBytes, string FilePath, string FileName, string OriginalFileName)
        {
            string newFileName = FileName.Replace(" ", "_") + Path.GetExtension(OriginalFileName);
            string tilePath = "Resources/Images/" + FilePath + "/Tiles/" + newFileName;
            File.WriteAllBytes(CreateFolder(tilePath), getTileBytes(ImgBytes));

            return tilePath;
        }
        private string CreateFolder(string filePath)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            file.Directory.Create();
            return path;
        }
    }
}
