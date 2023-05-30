using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Operations.Mementos
{
    internal class ConditionMemento : IOperationMemento
    {
        public IOperationMemento Cond, IfTrue, IfFalse;
        public ConditionMemento(IOperationMemento cond, IOperationMemento ifTrue, IOperationMemento ifFalse)
        {
            Cond = cond;
            IfTrue = ifTrue;
            IfFalse = ifFalse;
        }

        public IOperation Restore()
        {
            return new Conition(Cond.Restore(), IfTrue.Restore(), IfFalse.Restore());
        }
    }
}
