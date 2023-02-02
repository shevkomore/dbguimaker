using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace dbguimaker.Serialization
{
    /// <summary>
    /// A GUI element that contains some information for current table row
    /// </summary>
    public abstract partial class DatabaseGUIViewElement
    {
        public abstract bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data);
        public abstract Control Generate(SQLiteDataReader reader);
    }
}