using System.Collections.Generic;
using System.Linq;

namespace dbguimaker.DatabaseGUI
{
    /// <summary>
    /// An object that references a specific database element to be shown by <see cref="ViewComponent"/>
    /// </summary>
    public abstract partial class IOperation
    {
        public abstract object Get(Dictionary<TableColumn, object> row);

        public virtual bool IsCompatibleWith(List<TableColumn> table_data)
            => Inputs.All(x => (x ?? Constant.Default).IsCompatibleWith(table_data));
        public virtual IEnumerable<TableColumn> GetRequiredColumns()
        {
            List<TableColumn> columns = new List<TableColumn>();
            Inputs.ToList().ForEach(e => columns.AddRange((e ?? Constant.Default).GetRequiredColumns()));
            return columns;
        }

        public virtual bool GetBool(Dictionary<TableColumn, object> row)     => TableColumn.CastToBool(Get(row));
        public virtual string GetString(Dictionary<TableColumn, object> row) => TableColumn.CastToString(Get(row));
        public virtual int GetInt(Dictionary<TableColumn, object> row)       => TableColumn.CastToInt(Get(row));
    }
}