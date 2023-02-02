using System.Collections.Generic;

namespace dbguimaker.Serialization
{
    /// <summary>
    /// An object that references a specific database element to be shown by <see cref="DatabaseGUIViewElement"/>
    /// </summary>
    public abstract partial class DatabaseGUIOperation
    {
        public DatabaseGUIOperation() { }
        public abstract bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data);
    }
}