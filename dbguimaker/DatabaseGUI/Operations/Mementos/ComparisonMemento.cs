using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Operations.Mementos
{
    public class ComparisonMemento: IOperationMemento
    {
        public IOperationMemento Left, Right;
        public Comparison.OperationType Type;
        public ComparisonMemento(IOperationMemento left, IOperationMemento right, Comparison.OperationType type)
        {
            Left = left;
            Right = right;
            Type = type;
        }

        public IOperation Restore()
        {
            return new Comparison(Left.Restore(), Right.Restore(), Type);
        }
    }
}
