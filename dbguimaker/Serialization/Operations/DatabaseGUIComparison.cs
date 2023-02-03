using System;
using System.Collections.Generic;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUIComparison
    {
        public enum OperationType : int
        {
            Equals = 0,
            GreaterThan = 1,
            LessThan = -1
        }
        public DatabaseGUIComparison() { }
        public DatabaseGUIComparison(DatabaseGUIOperation input1, DatabaseGUIOperation input2, OperationType type)
        {
            this.firstOperand = input1;
            this.secondOperand = input2;
            this.operationType = type;
        }
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
