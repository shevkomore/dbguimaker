using ProtoBuf;
using System.Collections.Generic;
using System.IO;

namespace dbguimaker.DatabaseGUI
{
    /// <summary>
    /// An object that references a specific database element to be shown by <see cref="ViewComponent"/>
    /// </summary>
    public abstract partial class IOperation
    {
        public IOperation() { }
        public static IOperation Deserialize(byte[] message)
        {
            IOperation operation;
            using (var stream = new MemoryStream(message))
            {
                operation = Serializer.Deserialize<IOperation>(stream);
            }
            if (operation == null) return Constant.Default;
            return operation;
        }
        public virtual void FinalizeDeserialization()
        {
            for(int i = 0; i < Inputs.Length; ++i)
            {
                if (Inputs[i] == null) SetInput(i, Constant.Default);
                Inputs[i].FinalizeDeserialization();
            }
        }
    }
}