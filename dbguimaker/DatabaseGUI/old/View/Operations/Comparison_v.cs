using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace dbguimaker.DatabaseGUI
{
    public partial class Comparison
    {
        public override object Get(Dictionary<TableColumn, object> row)
        {
            int value1 = TableColumn.CastToInt((firstOperand ?? Constant.Default).Get(row));
            int value2 = TableColumn.CastToInt((secondOperand ?? Constant.Default).Get(row));
            int result = value1.CompareTo(value2);
            return Math.Sign(result) == (int)operationType;
        }
    }
}
