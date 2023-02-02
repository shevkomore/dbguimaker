using System.Collections.Generic;

namespace dbguimaker
{
    /// <summary>
    /// An object that references a specific database element to be shown by <see cref="DatabaseGUIViewElement"/>
    /// </summary>
    public partial class DatabaseGUIInput
    {
        public DatabaseGUIInput() { }
        public DatabaseGUIInput(DatabaseConnection.TableColumn column)
        {
            this.column = column;
        }
        public bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data)
            => table_data.Contains(column);
    }
}