using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.Serialization
{
    public abstract partial class DatabaseGUIBoolOperation
    {
        public abstract bool Get(SQLiteDataReader data);
    }
}
