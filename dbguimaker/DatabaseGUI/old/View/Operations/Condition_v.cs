using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI
{
    public partial class Condition
    {
        public override object Get(Dictionary<TableColumn, object> row)
        {
            if (Check.GetBool(row))
                return ifTrue.Get(row);
            return ifFalse.Get(row);
        }
    }
}
