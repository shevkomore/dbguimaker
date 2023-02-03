using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUIConstant
    {
        public DatabaseGUIConstant() { }
        public DatabaseGUIConstant(object value)
        {
            this.value = TableColumn.CastToString(value);
        }
        public override bool IsCompatibleWith(List<TableColumn> table_data) => true;
        public override object Get(Dictionary<TableColumn, object> row) => value;
        public override IEnumerable<TableColumn> GetRequiredColumns()
        {
            return new HashSet<TableColumn>();
        }
    }
}
