using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUIIntConstant
    {
        public DatabaseGUIIntConstant() { }
        public DatabaseGUIIntConstant(int value)
        {
            this.value = value;
        }
        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data) => true;
        public override int Get(SQLiteDataReader data) => value;
    }
}
