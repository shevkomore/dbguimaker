using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace dbguimaker
{
    /// <summary>
    /// Describes an object that contains all data for creating a database view
    /// </summary>
    public partial class DatabaseGUIData
    {
        public DatabaseGUIData() { }
        public DatabaseGUIData(string database_name)
        {
            this.databasePath = database_name;
            this.views = new List<DatabaseGUIView>();
        }

        public static string CreateRelativePath(string start, string target)
        {
            start = Path.GetDirectoryName(Path.GetFullPath(start))+Path.DirectorySeparatorChar;
            target = Path.GetFullPath(target);
            string path = "";
            /*
             * Removing all unnecessary (matching) path elements from both strings
             * 
             * for example,
             * "C:/Users/l/Desktop/f"
             * "C:/Users/l/Documents"
             * 
             * should return
             * "Desktop/f"
             * "Documents"
             */
            int compared = start.IndexOf(Path.DirectorySeparatorChar)+1;
            while (compared != 0 & target.StartsWith(start.Substring(0, compared)))
            {
                start = start.Remove(0, compared);
                target = target.Remove(0, compared);
                compared = start.IndexOf(Path.DirectorySeparatorChar)+1;
            }
            /*
             * Return back once per directory left in start
             * 
             * "Documents/folder"
             * should return
             * "../.."
             */
            compared = start.IndexOf(Path.DirectorySeparatorChar)+1;
            while (compared != 0)
            {
                start = start.Remove(0, compared);
                path += ".."+Path.DirectorySeparatorChar;
                compared = start.IndexOf(Path.DirectorySeparatorChar)+1;
            }
            return path + target;
        }
        public static string FollowRelativePath(string start, string relative_path)
        => Path.GetFullPath(Path.Combine(Path.GetDirectoryName(start), relative_path));
        public bool IsCompatibleWith(DatabaseConnection database)
        {
            foreach (DatabaseGUIView e in this.views)
                if (!e.IsCompatibleWith(database.GetTableInfo(e.tableName))) return false;

            return true;
        }

    }
    /// <summary>
    /// Describes a view of one table
    /// </summary>
    public partial class DatabaseGUIView
    {
        public DatabaseGUIView() { }
        public DatabaseGUIView(string table_name)
        {
            this.tableName = table_name;
            this.elements = new List<DatabaseGUIViewElement>();
        }
        public bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data)
        {
            foreach (DatabaseGUIViewElement e in this.elements)
                if (!e.IsCompatibleWith(table_data)) return false;

            return true;
        }
        public Control Generate(DatabaseConnection database)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            DatabaseConnection.IterateReader(() => database.GetTable(tableName),
                r =>
                {
                    foreach (DatabaseGUIViewElement e in this.elements)
                        flowLayoutPanel.Controls.Add( e.Generate(r));
                });

            return flowLayoutPanel;
        }
    }
    /// <summary>
    /// A GUI element that contains some information for current table row
    /// </summary>
    public partial class DatabaseGUIViewElement
    {
        public DatabaseGUIViewElement() { }
        public DatabaseGUIViewElement(string text, DatabaseGUIInput data)
        {
            this.text = text;
            this.data = data;
        }
        public bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data) => data.IsCompatibleWith(table_data);
        public Control Generate(SQLiteDataReader reader)
        {
            Label label = new Label();
            label.Text = this.text + data.Get(reader);
            return label;
        }
    }
    //TODO SUMMARY DESCRIBES INTERMEDIARY STATE OF CLASS! CHANGE LATER!
    /// <summary>
    /// An object that references a specific database element to be shown by <see cref="DatabaseGUIViewElement"/>
    /// </summary>
    public partial class DatabaseGUIInput
    {
        public DatabaseGUIInput() { }
        public DatabaseGUIInput(DatabaseConnection.TableColumn column)
        {
            this.column = column;
        }
        public bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data)
        {
            return table_data.Contains(column);
        }
        public object Get(SQLiteDataReader reader) => reader.GetValue(reader.GetOrdinal(column.Name));
    }
}