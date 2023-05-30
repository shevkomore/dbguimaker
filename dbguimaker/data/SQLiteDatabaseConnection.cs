using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace dbguimaker.data

{
    /**
     * <summary>
     * Container for a database with some shorthands fow working with it
     * </summary>
     */
    public partial class SQLiteDatabaseConnection: ISQLConnection
    {
        protected System.Data.SQLite.SQLiteConnection database;
        public System.Data.SQLite.SQLiteConnection Database { get { return database; } }
        protected SQLiteCommand selectColumnNames;
        protected SQLiteCommand selectTableNames;
        protected SQLiteCommand selectTable;
        public SQLiteDatabaseConnection(SQLiteConnection database)
        {
            this.database = database;
            this.selectTableNames = new SQLiteCommand("SELECT name FROM sqlite_schema WHERE type='table' AND name NOT LIKE 'sqlite_%'", database);
            this.selectTableNames.CommandType = CommandType.Text;
            this.selectColumnNames = new SQLiteCommand("SELECT * FROM PRAGMA_TABLE_INFO('@tablename')", database);
            this.selectColumnNames.CommandType = CommandType.Text;
            this.selectTable = new SQLiteCommand("SELECT * FROM @tablename", database);
        }
        public SQLiteDatabaseConnection(string database_path) : this(new SQLiteConnection("Data Source=" + database_path))
        {
            database.Open();
        }

        public object ExecuteOnce(string command) => new SQLiteCommand(command, database).ExecuteScalar();
        public DbDataReader GetTableNames() => selectTableNames.ExecuteReader();
        public DbDataReader Execute(string command)
            => new SQLiteCommand(command, database).ExecuteReader();
        public DbDataReader GetTable(string table_name)
        {
            selectTable.CommandText = "SELECT * FROM " + table_name;
            return selectTable.ExecuteReader();
        }

        public DbDataReader GetTableInfo(string table_name)
        {
            selectColumnNames.CommandText = "SELECT * FROM PRAGMA_TABLE_INFO('" + table_name + "')";
            return selectColumnNames.ExecuteReader();
        }
    }
}
