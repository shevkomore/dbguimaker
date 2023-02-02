using System.Data.SQLite;
using System.Linq;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace dbguimaker
{
    public partial class DatabaseGUIBoolInput
    {
        public DatabaseGUIBoolInput() { }
        public DatabaseGUIBoolInput(DatabaseConnection.TableColumn data) : base(data) { }
        public bool Get(SQLiteDataReader reader)
            => reader.GetBoolean(reader.GetOrdinal(column.Name));
    }
}