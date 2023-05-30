using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.data
{
    public interface ITable
    {
        IList<TableColumn> Columns
        {
            get;
        }
        IList<TableColumn> RequiredColumns
        {
            get;
        }
        IEnumerable<KeyValuePair<TableColumn, object>> Next();
        
    }
}
