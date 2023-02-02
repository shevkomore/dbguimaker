using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUILabel
    {
        public DatabaseGUILabel() { }
        public DatabaseGUILabel(string formatableText, DatabaseGUITextInput data)
        {
            this.formatableText = formatableText;
            this.data = data;
        }

        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data) => data.IsCompatibleWith(table_data);
        public override Control Generate(SQLiteDataReader reader)
        {
            Label label = new Label();
            label.Text = String.Format(this.formatableText, data.Get(reader));
            return label;
        }
    }
}