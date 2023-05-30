using dbguimaker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Operations
{
    public class Sum: IOperation
    {
        public IOperation Operand1 { get; set; }
        public IOperation Operand2 { get; set; }
        public Sum(IOperation operand1, IOperation operand2)
        {
            Operand1 = operand1;
            Operand2 = operand2;
        }

        public object Apply(Dictionary<TableColumn, object> row)
        {
            string l = TableColumn.CastToString(Operand1.Apply(row));
            string r = TableColumn.CastToString(Operand2.Apply(row));
            try
            {
                return decimal.Parse(l) + decimal.Parse(r);
            }
            catch
            {
                return l + r;
            }
        }

        T IOperation.Accept<T>(IOperationVisitor<T> visitor)
        {
            return visitor.VisitSum(this);
        }
    }
}
