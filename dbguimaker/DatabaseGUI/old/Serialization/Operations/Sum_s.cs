using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI
{
    public partial class Sum
    {
        public Sum() { }
        public Sum(IOperation left, IOperation right)
        {
            this.firstOperand = left;
            this.secondOperand = right;
        }

        
    }
}
