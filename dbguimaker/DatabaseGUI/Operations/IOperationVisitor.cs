using dbguimaker.DatabaseGUI.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI
{
    public interface IOperationVisitor<out ReturnType>
    {
        ReturnType VisitConstant(Constant o);
        ReturnType VisitInput(Input o);
        ReturnType VisitComparison(Comparison o);
        ReturnType VisitCondition(Condition o);
        ReturnType VisitSum(Sum o);
    }
}
