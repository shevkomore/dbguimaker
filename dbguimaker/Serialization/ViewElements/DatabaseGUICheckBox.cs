using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUICheckBox
    {
        public DatabaseGUICheckBox() { }
        public DatabaseGUICheckBox(DatabaseGUIOperation label, DatabaseGUIOperation data)
        {
            this.label = label;
            this.data = data;
        }
        public override bool IsCompatibleWith(List<TableColumn> table_data) => data.IsCompatibleWith(table_data);
        public override Control Generate(Dictionary<TableColumn, object> reader)
        {
            CheckBox checkbox = new CheckBox();
            checkbox.Text = TableColumn.CastToString(label.Get(reader));
            checkbox.Font = DatabaseGUIData.defaultFont;
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