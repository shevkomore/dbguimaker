using System.Data.SQLite;

namespace dbguimaker
{
    public partial class DatabaseGUITextInput
    {
        public DatabaseGUITextInput() { }
        public DatabaseGUITextInput(DatabaseConnection.TableColumn data) : base(data) { }
        public string Get(SQLiteDataReader reader)
            => reader.GetValue(reader.GetOrdinal(column.Name)).ToString();
    }
}