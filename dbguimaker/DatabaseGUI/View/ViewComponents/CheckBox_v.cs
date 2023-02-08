using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class CheckBox
    {
        public override bool IsCompatibleWith(List<TableColumn> table_data) 
            => data.IsCompatibleWith(table_data) && label.IsCompatibleWith(table_data);
        public override Control Generate(Dictionary<TableColumn, object> reader)
        {
            System.Windows.Forms.CheckBox checkbox = new System.Windows.Forms.CheckBox();
            checkbox.Text = TableColumn.CastToString(label.Get(reader));
            checkbox.Font = Data.DefaultViewFont;
            checkbox.Checked = TableColumn.CastToBool(data.Get(reader));
            checkbox.Enabled = false;
            return checkbox;
        }

        public override IEnumerable<TableColumn> GetRequiredColumns()
        {
            HashSet<TableColumn> data = new HashSet<TableColumn>();
            data.UnionWith(this.label.GetRequiredColumns());
            data.UnionWith(this.data.GetRequiredColumns());
            return data;
        }
    }
}