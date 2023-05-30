using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class TextArea
    {
        public override bool IsCompatibleWith(List<TableColumn> table_data)
            => (data ?? Constant.Default).IsCompatibleWith(table_data) && (label ?? Constant.Default).IsCompatibleWith(table_data);
        public override Control Generate(Dictionary<TableColumn, object> row)
        {
            TableLayoutPanel layout = new TableLayoutPanel();
            layout.AutoSize = true;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle());
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.AutoSize = true;
            label.Font = Data.DefaultViewFont;
            label.Text = (this.label ?? Constant.Default).GetString(row);
            layout.Controls.Add(label);
            TextBox textBox = new TextBox();
            textBox.Text = (data ?? Constant.Default).GetString(row);
            textBox.AutoSize = true;
            textBox.Font = Data.DefaultViewFont;
            textBox.Width = TextRenderer.MeasureText(textBox.Text, textBox.Font).Width;
            textBox.ReadOnly = true;
            layout.Controls.Add(textBox);
            return layout;
        }
        public override IEnumerable<TableColumn> GetRequiredColumns()
        {
            HashSet<TableColumn> columns = new HashSet<TableColumn>();
            columns.UnionWith((label ?? Constant.Default).GetRequiredColumns());
            columns.UnionWith((data ?? Constant.Default).GetRequiredColumns());
            return columns;
        }
    }
}