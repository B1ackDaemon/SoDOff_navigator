using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace SoDOff_navigator
{
    class HashingCompute
    {
        public static String GetMD5HashFromFile(String fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static String GetMD5HashFromStream(MemoryStream mem)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(mem);


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static String GetMD5HashFromBinary(BinaryReader buf)
        {
            byte[] tmp = buf.ReadBytes((int)buf.BaseStream.Length);
            MemoryStream mem = new MemoryStream();
            mem.Write(tmp, 0, tmp.Length);
            mem.Position = 0;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(mem);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static String GetSHA1HashFromFile(String fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open);
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] retVal = sha1.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}