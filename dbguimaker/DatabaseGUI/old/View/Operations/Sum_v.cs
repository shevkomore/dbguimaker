using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI
{
    public partial class Sum
    {
        public override object Get(Dictionary<TableColumn, object> row)
        {
            string l = firstOperand.GetString(row);
            string r = secondOperand.GetString(row);
            try
            {
                return decimal.Parse(l) + decimal.Parse(r);
            }
            catch
            {
                return l + r;
            }
        }
    }
}
