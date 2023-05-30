using dbguimaker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Operations
{
    public class Condition: IOperation
    {
        public IOperation Check { get; set; }
        public IOperation IfTrue { get; set; }
        public IOperation IfFalse { get; set; }
        public Condition(IOperation check, IOperation ifTrue, IOperation ifFalse)
        {
            this.Check = check;
            this.IfTrue = ifTrue;
            this.IfFalse = ifFalse;
        }

        public object Apply(Dictionary<TableColumn, object> row)
        {
            if (TableColumn.CastToBool(Check.Apply(row)))
                return IfTrue.Apply(row);
            return IfFalse.Apply(row);
        }

        T IOperation.Accept<T>(IOperationVisitor<T> visitor)
        {
           return visitor.VisitCondition(this);
        }
    }
}
