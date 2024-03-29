﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace dbguimaker
{
    /**
     * <summary>
     * Container for a database with some shorthands fow working with it
     * </summary>
     */
    public partial class DatabaseConnection
    {
        SQLiteConnection database;
        public SQLiteConnection Database { get { return database; } }
        SQLiteCommand selectColumnNames;
        SQLiteCommand selectTableNames;
        SQLiteCommand selectTable;
        public DatabaseConnection(SQLiteConnection database)
        {
            this.database = database;
            this.selectTableNames = new SQLiteCommand("SELECT name FROM sqlite_schema WHERE type='table' AND name NOT LIKE 'sqlite_%'", database);
            this.selectTableNames.CommandType = CommandType.Text;
            this.selectColumnNames = new SQLiteCommand("SELECT * FROM PRAGMA_TABLE_INFO('@tablename')", database);
            this.selectColumnNames.CommandType = CommandType.Text;
            this.selectTable = new SQLiteCommand("SELECT * FROM @tablename", database);
        }
        public DatabaseConnection(string database_path) : this(new SQLiteConnection("Data Source=" + database_path))
        {
            database.Open();
        }
        /// <summary>
        /// Executes the command and returns the first result.
        /// </summary>
        /// <param name="command">the command that will be executed</param>
        /// <returns>the first row of results from the command</returns>
        public object ExecuteOnce(string command) => new SQLiteCommand(command, database).ExecuteScalar();
        /// <summary>
        /// Returns the view with names of all tables in the database
        /// </summary>
        /// <returns>A view, the only column of which (called "name") contains all the names of tables inside the database</returns>
        public SQLiteDataReader GetTableNames() => selectTableNames.ExecuteReader();
        /// <summary>
        /// Creates a list of table columns
        /// </summary>
        /// <param name="table_name">the name of the table requested</param>
        /// <returns>A list of TableColumns with data from PRAGMA_TABLE_INFO(table_name)</returns>
        public List<TableColumn> GetTableInfo(string table_name)
        {
            selectColumnNames.CommandText = "SELECT * FROM PRAGMA_TABLE_INFO('" + table_name + "')";
            List<TableColumn> result = new List<TableColumn>();
            IterateReader(selectColumnNames.ExecuteReader,
                e => result.Add(new TableColumn(e))
                );
            return result;
        }
        public SQLiteDataReader Execute(string command)
            => new SQLiteCommand(command, database).ExecuteReader();
        /// <summary>
        /// Gets a view of the table
        /// </summary>
        /// <param name="table_name">the name of the table requested</param>
        /// <returns>A view of the table requested</returns>
        public SQLiteDataReader GetTable(string table_name)
        {
            selectTable.CommandText = "SELECT * FROM " + table_name;
            return selectTable.ExecuteReader();
        }
        /// <summary>
        /// A simple loop through all elements of a table
        /// </summary>
        /// <param name="create_reader">The method that returns a table (will be called via using)</param>
        /// <param name="iteration">The code that is executed each row</param>
        public static void IterateReader(Func<SQLiteDataReader> create_reader, Action<SQLiteDataReader> iteration)
        {
            using (SQLiteDataReader r = create_reader())
                while (r.Read())
                    iteration(r);
        }
    }
}
