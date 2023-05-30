using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI
{
    public partial class Condition
    {
        public Condition() { }
        public Condition(IOperation check, IOperation if_true, IOperation if_false)
        {
            this.Check = check;
            this.ifTrue = if_true;
            this.ifFalse = if_false;
        }
    }
}
