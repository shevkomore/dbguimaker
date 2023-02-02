using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUITextArea
    {
        static int MaxWidth = 400;
        public DatabaseGUITextArea() { }
        public DatabaseGUITextArea(string text, DatabaseGUITextInput data)
        {
            this.text = text;
            this.data = data;
        }

        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data) => data.IsCompatibleWith(table_data);
        public override Control Generate(SQLiteDataReader reader)
        {
            TableLayoutPanel layout = new TableLayoutPanel();
            layout.AutoSize = true;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle());
            Label label = new Label();
            label.AutoSize = true;
            label.Font = DatabaseGUIData.defaultFont;
            label.Text = this.text;
            layout.Controls.Add(label);
            TextBox textBox = new TextBox();
            textBox.Text = data.Get(reader);
            textBox.AutoSize = true;
            textBox.Font = DatabaseGUIData.defaultFont;
            int width = TextRenderer.MeasureText(textBox.Text, textBox.Font).Width;
            textBox.Width = width + label.Width < MaxWidth ? width : MaxWidth;
            textBox.ReadOnly = true;
            layout.Controls.Add(textBox);
            return layout;
        }
    }
}