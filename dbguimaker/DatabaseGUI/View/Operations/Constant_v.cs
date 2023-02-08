using System.Collections.Generic;

namespace dbguimaker.DatabaseGUI
{
    public partial class Constant
    {
        public override bool IsCompatibleWith(List<TableColumn> table_data) => true;
        public override object Get(Dictionary<TableColumn, object> row) => value;
        public override IEnumerable<TableColumn> GetRequiredColumns()
        {
            return new HashSet<TableColumn>();
        }
    }
}
