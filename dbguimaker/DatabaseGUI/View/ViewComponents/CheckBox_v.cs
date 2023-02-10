using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class CheckBox
    {
        public override bool IsCompatibleWith(List<TableColumn> table_data) 
            => (data ?? Constant.Default).IsCompatibleWith(table_data) && (label ?? Constant.Default).IsCompatibleWith(table_data);
        public override Control Generate(Dictionary<TableColumn, object> reader)
        {
            System.Windows.Forms.CheckBox checkbox = new System.Windows.Forms.CheckBox();
            checkbox.AutoSize = true;
            checkbox.Text = TableColumn.CastToString((label ?? Constant.Default).Get(reader));
            checkbox.Font = Data.DefaultViewFont;
            checkbox.Checked = TableColumn.CastToBool((data ?? Constant.Default).Get(reader));
            checkbox.Enabled = false;
            return checkbox;
        }

        public override IEnumerable<TableColumn> GetRequiredColumns()
        {
            HashSet<TableColumn> data = new HashSet<TableColumn>();
            data.UnionWith((this.label ?? Constant.Default).GetRequiredColumns());
            data.UnionWith((this.data ?? Constant.Default).GetRequiredColumns());
            return data;
        }
    }
}