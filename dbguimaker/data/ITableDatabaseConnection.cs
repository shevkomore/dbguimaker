using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.data
{
    internal interface ITableDatabaseConnection
    {
        ITable GetTableNames();
        IList<TableColumn> GetTableInfo(string table_name);
        ITable Execute(string command);
        ITable GetTable(string table_name);
    }
}
