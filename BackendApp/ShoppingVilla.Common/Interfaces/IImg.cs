using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Common.Interfaces
{
    public interface IImg
    {
        byte[] getByteArrayFromBase64String(string Bash64String);
        byte[] getThumbBytes(byte[] ImgByates);
        byte[] getTileBytes(byte[] ImgByates);
        string SaveImg(byte[] ImgBytes, string FilePath, string FileName, string OriginalFileName);
        string SaveThumbImg(byte[] ImgBytes, string FilePath, string FileName, string OriginalFileName);
        string SaveTileImg(byte[] ImgBytes, string FilePath, string FileName, string OriginalFileName);
    }
}
