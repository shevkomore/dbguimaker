using dbguimaker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI
{
    public class TableDecorator: ITable
    {
        ITable table;
        public TableDecorator(ITable table) {
            this.table = table;
        }

        public virtual IList<TableColumn> Columns 
        {
            get { return table.Columns; }
        }

        public virtual IList<TableColumn> RequiredColumns
        {
            get { return table.RequiredColumns; }
        }

        public IEnumerable<KeyValuePair<TableColumn, object>> Next()
        {
            return this.table.next();
        }
    }
}
