﻿using System.Collections.Generic;

namespace dbguimaker.DatabaseGUI
{
    /// <summary>
    /// An object that references a specific database element to be shown by <see cref="ViewComponent"/>
    /// </summary>
    public abstract partial class Operation
    {
        public abstract bool IsCompatibleWith(List<TableColumn> table_data);
        public abstract object Get(Dictionary<TableColumn, object> row);
        public abstract IEnumerable<TableColumn> GetRequiredColumns();

        public bool GetBool(Dictionary<TableColumn, object> row)     => TableColumn.CastToBool(Get(row));
        public string GetString(Dictionary<TableColumn, object> row) => TableColumn.CastToString(Get(row));
        public int GetInt(Dictionary<TableColumn, object> row)       => TableColumn.CastToInt(Get(row));
    }
}