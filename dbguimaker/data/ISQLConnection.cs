using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.data
{
    internal interface ISQLConnection
    {
        /// <summary>
        /// Executes the command and returns the first result.
        /// </summary>
        /// <param name="command">the command that will be executed</param>
        /// <returns>the first row of results from the command</returns>
        object ExecuteOnce(string command);
        /// <summary>
        /// Returns the view with names of all tables in the database
        /// </summary>
        /// <returns>A view, the only column of which (called "name") contains all the names of tables inside the database</returns>
        DbDataReader GetTableNames();
        //TODO MOVE FROM HERE
        /// <summary>
        /// Creates a list of table columns
        /// </summary>
        /// <param name="table_name">the name of the table requested</param>
        /// <returns>A list of TableColumns with data from PRAGMA_TABLE_INFO(table_name)</returns>
        DbDataReader GetTableInfo(string table_name);
        DbDataReader Execute(string command);
        /// <summary>
        /// Gets a view of the table
        /// </summary>
        /// <param name="table_name">the name of the table requested</param>
        /// <returns>A view of the table requested</returns>
        DbDataReader GetTable(string table_name);


    }
}
