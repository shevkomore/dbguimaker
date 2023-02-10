using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace dbguimaker.DatabaseGUI
{
    public partial class Comparison
    {
        public override bool IsCompatibleWith(List<TableColumn> table_data)
        {
            return (firstOperand ?? Constant.Default).IsCompatibleWith(table_data)
                && (secondOperand ?? Constant.Default).IsCompatibleWith(table_data);
        }
        public override object Get(Dictionary<TableColumn, object> row)
        {
            int value1 = TableColumn.CastToInt((firstOperand ?? Constant.Default).Get(row));
            int value2 = TableColumn.CastToInt((secondOperand ?? Constant.Default).Get(row));
            int result = value1.CompareTo(value2);
            return Math.Sign(result) == (int)operationType;
        }
        public override IEnumerable<TableColumn> GetRequiredColumns()
        {
            HashSet<TableColumn> result = new HashSet<TableColumn>();
            result.UnionWith((firstOperand ?? Constant.Default).GetRequiredColumns());
            result.UnionWith((secondOperand ?? Constant.Default).GetRequiredColumns());
            return result;
        }
    }
}
