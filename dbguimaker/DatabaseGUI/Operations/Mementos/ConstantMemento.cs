using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Operations.Mementos
{
    public class ConstantMemento: IOperationMemento
    {
        public string Data;
        public ConstantMemento(string data)
        {
            Data = data;
        }

        public IOperation Restore()
        {
            return new Constant(Data);
        }
    }
}
