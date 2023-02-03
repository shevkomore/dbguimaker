using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUILabel
    {
        public DatabaseGUILabel() { }
        public DatabaseGUILabel(DatabaseGUIOperation text) {
            this.text = text;
        }

        public override bool IsCompatibleWith(List<TableColumn> table_data) => text.IsCompatibleWith(table_data);
        public override Control Generate(Dictionary<TableColumn, object> row)
        {
            Label label = new Label();
            label.Text = text.GetString(row);
            return label;
        }

        public override IEnumerable<TableColumn> GetRequiredColumns()
        {
            HashSet<TableColumn> columns = new HashSet<TableColumn>();
            columns.UnionWith(text.GetRequiredColumns());
            return columns;
        }
    }
}