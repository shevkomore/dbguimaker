using System;
using System.Collections.Generic;

namespace dbguimaker.DatabaseGUI
{
    public partial class Comparison
    {
        public enum OperationType : int
        {
            Equals = 0,
            GreaterThan = 1,
            LessThan = -1
        }
        public Comparison() { }
        public Comparison(IOperation input1, IOperation input2, OperationType type)
        {
            this.firstOperand = input1;
            this.secondOperand = input2;
            this.operationType = type;
        }
    }
}
