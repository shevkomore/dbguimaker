using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Operations.Mementos
{
    public class SumMemento : IOperationMemento
    {
        public IOperationMemento First, Second;
        public SumMemento(IOperationMemento first, IOperationMemento second)
        {
            First = first;
            Second = second;
        }

        public IOperation Restore()
        {
            return new Sum(First.Restore(), Second.Restore());
        }
    }
}
