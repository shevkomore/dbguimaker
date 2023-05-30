using dbguimaker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dbguimaker.DatabaseGUI.Operations.Comparison;

namespace dbguimaker.DatabaseGUI.Operations
{
    public class Comparison: IOperation
    {
        public enum OperationType : int
        {
            Equals = 0,
            GreaterThan = 1,
            LessThan = -1
        }

        public IOperation LeftOperand { get; set; }

        public IOperation RightOperand { get; set; }

        public OperationType Operation { get; set; }

        public Comparison(IOperation leftOperand, IOperation rightOperand, OperationType type)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Operation = type;
        }
        public object Apply(Dictionary<TableColumn, object> row)
        {
            int value1 = TableColumn.CastToInt((LeftOperand ?? Constant.Default).Apply(row));
            int value2 = TableColumn.CastToInt((RightOperand ?? Constant.Default).Apply(row));
            int result = value1.CompareTo(value2);
            return Math.Sign(result) == (int)Operation;
        }

        T IOperation.Accept<T>(IOperationVisitor<T> visitor)
        {
            return visitor.VisitComparison(this);
        }

    }
}
