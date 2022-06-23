using System;
using System.Threading;
using System.IO;
using System.Security.Cryptography;

namespace AbaddonBuilder.ChangeMD5
{
    internal class MD5HASH
    {
        public static void changeMD5(string[] fileNames)
        {
            Random random = new Random();
            Thread.Sleep(1000);

            for (int i = 0; i < fileNames.Length; i++)
            {

                int num = random.Next(2, 7);
                byte[] extraByte = new byte[num];
                for (int j = 0; j < num; j++)
                {
                    extraByte[j] = (byte)0;
                }
                long fileSize = new FileInfo(fileNames[i]).Length;
                if (fileSize == 0L){}
                else
                {
                    using (FileStream fileStream = new FileStream(fileNames[i], FileMode.Append))
                        fileStream.Write(extraByte, 0, extraByte.Length);
                    int bufferSize = fileSize > 1048576L ? 1048576 : 4096;
                    string md5hash = "";
                    using (MD5 md = MD5.Create())
                        using (FileStream fileStream2 = new FileStream(fileNames[i], FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize))
                            md5hash = BitConverter.ToString(md.ComputeHash(fileStream2)).Replace("-", "");
                }
            }
        }
    }
}
