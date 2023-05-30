using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.data
{
    internal class SQLiteToTableDatabaseConnectionAdapter : SQLiteDatabaseConnection, ITableDatabaseConnection
    {
        public SQLiteToTableDatabaseConnectionAdapter(string database_path) : base(database_path)
        {

        }
        ITable ITableDatabaseConnection.Execute(string command)
        {
            return new SQLiteDataReaderToTableAdapter(new SQLiteCommand(command, database).ExecuteReader());
        }

        ITable ITableDatabaseConnection.GetTable(string table_name)
        {
            selectTable.CommandText = "SELECT * FROM " + table_name;
            return new SQLiteDataReaderToTableAdapter(selectTable.ExecuteReader());
        }

        IList<TableColumn> ITableDatabaseConnection.GetTableInfo(string table_name)
        {
            selectTable.CommandText = "SELECT * FROM " + table_name;
            return new SQLiteDataReaderToTableAdapter(selectTable.ExecuteReader()).Columns;
        }

        ITable ITableDatabaseConnection.GetTableNames()
        {
            return new SQLiteDataReaderToTableAdapter(selectTableNames.ExecuteReader());
        }
    }
}
