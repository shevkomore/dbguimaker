using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.data
{
    internal class SQLiteDataReaderToTableAdapter : ITable
    {
        SQLiteDataReader reader;
        List<TableColumn> columns = new List<TableColumn>();

        public SQLiteDataReaderToTableAdapter(SQLiteDataReader r)
        {
            reader = r;
            var cols_mixed = r.GetColumnSchema().Select(
                o => new TableColumn(o.ColumnName, o.DataTypeName, !(o.AllowDBNull ?? false)))
                .ToList();
            for (int i = 0; i < cols_mixed.Count; ++i)
            {
                columns.Add(cols_mixed.Find(o => o.Name == r.GetName(i)));
            }
        }
        public IList<TableColumn> Columns
        {
            get 
            {
                return columns.AsReadOnly();
            }
        }

        public IList<TableColumn> RequiredColumns
        {
            get
            {
                return columns.FindAll(o => o.NotNull);
            }
        }

        public IEnumerable<KeyValuePair<TableColumn, object>> next()
        {
            var res = new List<KeyValuePair<TableColumn, object>>();
            if (reader.Read())
            {
                for (int i = 0; i < columns.Count; ++i)
                    res[i] = new KeyValuePair<TableColumn, object>(columns[i], reader.GetValue(i));
            }
            return res;
        }
    }
}
