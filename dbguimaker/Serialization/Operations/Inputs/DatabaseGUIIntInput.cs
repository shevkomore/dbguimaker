using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUIIntInput
    {
        public DatabaseGUIIntInput() { }
        public DatabaseGUIIntInput(DatabaseConnection.TableColumn data)
        {
            this.column = data;
        }
        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data)
            => table_data.Contains(column);
        public override int Get(SQLiteDataReader reader)
            => reader.GetInt32(reader.GetOrdinal(column.Name));
    }
}
