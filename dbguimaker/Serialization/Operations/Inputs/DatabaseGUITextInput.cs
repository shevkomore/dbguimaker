using System.Collections.Generic;
using System.Data.SQLite;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUITextInput
    {
        public DatabaseGUITextInput() { }
        public DatabaseGUITextInput(DatabaseConnection.TableColumn data)
        {
            this.column = data;
        }
        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data)
            => table_data.Contains(column);
        public override string Get(SQLiteDataReader reader)
            => reader.GetValue(reader.GetOrdinal(column.Name)).ToString();
    }
}