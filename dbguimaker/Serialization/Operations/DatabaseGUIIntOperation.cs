using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.Serialization
{
    public abstract partial class DatabaseGUIIntOperation
    {
        public abstract int Get(SQLiteDataReader data);
    }
}
