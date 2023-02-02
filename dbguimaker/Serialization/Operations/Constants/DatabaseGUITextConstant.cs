using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.Serialization
{
    public partial class DatabaseGUITextConstant
    {
        public DatabaseGUITextConstant() { }
        public DatabaseGUITextConstant(string value)
        {
            this.value = value;
        }
        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data) => true;
        public override string Get(SQLiteDataReader data) => value;
    }
}
