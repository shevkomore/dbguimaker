using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUITextArea
    {
        static int MaxWidth = 400;
        public DatabaseGUITextArea() { }
        public DatabaseGUITextArea(DatabaseGUIOperation text, DatabaseGUIOperation data)
        {
            this.label = text;
            this.data = data;
        }

        public override bool IsCompatibleWith(List<TableColumn> table_data)
            => data.IsCompatibleWith(table_data) && label.IsCompatibleWith(table_data);
        public override Control Generate(Dictionary<TableColumn, object> row)
        {
            TableLayoutPanel layout = new TableLayoutPanel();
            layout.AutoSize = true;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle());
            Label label = new Label();
            label.AutoSize = true;
            label.Font = DatabaseGUIData.defaultFont;
            label.Text = this.label.GetString(row);
            layout.Controls.Add(label);
            TextBox textBox = new TextBox();
            textBox.Text = data.GetString(row);
            textBox.AutoSize = true;
            textBox.Font = DatabaseGUIData.defaultFont;
            int width = TextRenderer.MeasureText(textBox.Text, textBox.Font).Width;
            textBox.Width = width + label.Width < MaxWidth ? width : MaxWidth;
            textBox.ReadOnly = true;
            layout.Controls.Add(textBox);
            return layout;
        }
        public override IEnumerable<TableColumn> GetRequiredColumns()
        {
            HashSet<TableColumn> columns = new HashSet<TableColumn>();
            columns.UnionWith(label.GetRequiredColumns());
            columns.UnionWith(data.GetRequiredColumns());
            return columns;
        }
    }
}