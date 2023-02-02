using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUICheckBox
    {
        public DatabaseGUICheckBox() { }
        public DatabaseGUICheckBox(string text, DatabaseGUIBoolOperation data)
        {
            this.text = text;
            this.data = data;
        }
        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data) => data.IsCompatibleWith(table_data);
        public override Control Generate(SQLiteDataReader reader)
        {
            CheckBox checkbox = new CheckBox();
            checkbox.Text = this.text;
            checkbox.Font = DatabaseGUIData.defaultFont;
            checkbox.Checked = data.Get(reader);
            checkbox.Enabled = false;
            return checkbox;
        }
    }
}