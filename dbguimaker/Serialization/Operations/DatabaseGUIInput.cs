using System.Collections.Generic;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUIInput
    {
        public DatabaseGUIInput() { }
        public DatabaseGUIInput(TableColumn data)
        {
            this.column = data;
        }
        public override bool IsCompatibleWith(List<TableColumn> table_data)
            => table_data.Contains(column);
        public override object Get(Dictionary<TableColumn, object> row)
        {
            object value = null;
            row.TryGetValue(column, out value);
            return value;
        }
        public override IEnumerable<TableColumn> GetRequiredColumns()
        {
            var r = new HashSet<TableColumn>();
            r.Add(column);
            return r;
        }
    }
}
