using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.data
{
    internal class BasicTable: ITable
    {
        List<TableColumn> columns;
        public IList<TableColumn> Columns
        {
            get { return columns.AsReadOnly(); }
        }
        public IList<TableColumn> RequiredColumns
        {
            get
            {
                return columns.FindAll(o => o.NotNull);
            }
        }
        List<IEnumerable<KeyValuePair<TableColumn, object>>> rows;
        int lastIndex;
        public IEnumerable<KeyValuePair<TableColumn, object>> next()
        {
            ++lastIndex;
            if (lastIndex == rows.Count)
                return new List<KeyValuePair<TableColumn, object>>();
            return rows[lastIndex].ToImmutableList();
        }

    }
}
