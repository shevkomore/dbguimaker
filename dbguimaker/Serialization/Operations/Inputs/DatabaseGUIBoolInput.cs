using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUIBoolInput
    {
        public DatabaseGUIBoolInput() { }
        public DatabaseGUIBoolInput(DatabaseConnection.TableColumn data)
        {
            this.column = data;
        }
        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data)
            => table_data.Contains(column);
        public override bool Get(SQLiteDataReader reader)
            => reader.GetBoolean(reader.GetOrdinal(column.Name));
    }
}