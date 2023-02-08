using System;
using System.Collections.Generic;

namespace dbguimaker.DatabaseGUI
{
    public partial class Comparison
    {
        public override bool IsCompatibleWith(List<TableColumn> table_data)
        {
            return firstOperand.IsCompatibleWith(table_data) && secondOperand.IsCompatibleWith(table_data);
        }
        public override object Get(Dictionary<TableColumn, object> row)
        {
            int value1 = TableColumn.CastToInt(firstOperand.Get(row));
            int value2 = TableColumn.CastToInt(secondOperand.Get(row));
            int result = value1.CompareTo(value2);
            return Math.Sign(result) == (int)operationType;
        }
        public override IEnumerable<TableColumn> GetRequiredColumns()
        {
            HashSet<TableColumn> result = new HashSet<TableColumn>();
            result.UnionWith(firstOperand.GetRequiredColumns());
            result.UnionWith(secondOperand.GetRequiredColumns());
            return result;
        }
    }
}
