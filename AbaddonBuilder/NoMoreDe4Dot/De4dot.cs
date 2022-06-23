using dnlib.DotNet;

namespace AbaddonBuilder.NoMoreDe4Dot
{
    internal class De4dot
    {
        public static void Execute(ModuleDefMD mdmd)
        {
            foreach (ModuleDef module in mdmd.Assembly.Modules)
            {
                InterfaceImplUser int1 = new InterfaceImplUser(module.GlobalType);
                for (int i = 0; i < 1; i++)
                {
                    TypeDefUser typeDef1 = new TypeDefUser(string.Empty, $"Form{i}", module.CorLibTypes.GetTypeRef("System", "Attribute"));
                    InterfaceImplUser int2 = new InterfaceImplUser(typeDef1);

                    module.Types.Add(typeDef1);

                    typeDef1.Interfaces.Add(int2);
                    typeDef1.Interfaces.Add(int1);
                }
            }
        }
    }
}
