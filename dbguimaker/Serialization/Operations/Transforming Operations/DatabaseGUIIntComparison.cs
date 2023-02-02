using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUIIntComparison
    {
        public enum OperationType : int
        {
            Equals = 0,
            GreaterThan = 1,
            LessThan = -1
        }
        public DatabaseGUIIntComparison() { }
        public DatabaseGUIIntComparison(DatabaseGUIIntOperation input1, DatabaseGUIIntOperation input2, OperationType type)
        {
            this.firstOperand = input1;
            this.secondOperand = input2;
            this.operationType = type;
        }
        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data)
        {
            return firstOperand.IsCompatibleWith(table_data) && secondOperand.IsCompatibleWith(table_data);
        }
        public override bool Get(SQLiteDataReader reader)
        {
            int result = firstOperand.Get(reader).CompareTo(secondOperand.Get(reader));
            return Math.Sign(result) == (int)operationType;
        }
    }
}
