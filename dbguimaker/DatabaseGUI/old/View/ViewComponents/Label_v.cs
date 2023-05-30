using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class Label
    {
        public override bool IsCompatibleWith(List<TableColumn> table_data) 
            => (text ?? Constant.Default).IsCompatibleWith(table_data);
        public override Control Generate(Dictionary<TableColumn, object> row)
        {
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = (text ?? Constant.Default).GetString(row);
            label.Font = Data.DefaultViewFont;
            return label;
        }

        public override IEnumerable<TableColumn> GetRequiredColumns()
        {
            HashSet<TableColumn> columns = new HashSet<TableColumn>();
            columns.UnionWith((text ?? Constant.Default).GetRequiredColumns());
            return columns;
        }
    }
}