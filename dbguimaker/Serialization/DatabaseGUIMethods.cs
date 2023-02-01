using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace dbguimaker
{
    /// <summary>
    /// Describes an object that contains all data for creating a database view
    /// </summary>
    public partial class DatabaseGUIData
    {
        internal static Font defaultFont = new Font(FontFamily.GenericSansSerif, 14);
        internal static OpenFileDialog OpenDataFileDialog = new OpenFileDialog();
        internal static OpenFileDialog OpenDatabaseFileDialog = new OpenFileDialog();
        internal static SaveFileDialog SaveViewFileDialog = new SaveFileDialog();
        static DatabaseGUIData()
        {
            //
            //  OpenDataFileDialog
            //
            OpenDataFileDialog.Filter =
                "Database View File|*.dbgui";
            OpenDataFileDialog.CheckFileExists = true;
            OpenDataFileDialog.Title = "Select a file";
            //
            //  OpenDatabaseFileDialog
            //
            OpenDatabaseFileDialog.Filter =
               "Database File|*.db";
            OpenDatabaseFileDialog.CheckFileExists = true;
            OpenDatabaseFileDialog.Title = "Select a database";
            //
            //  SaveViewFileDialog
            //
            SaveViewFileDialog.Title = "Save view to...";
            SaveViewFileDialog.DefaultExt = ".dbgui";
            SaveViewFileDialog.FileName = "view";
            SaveViewFileDialog.AddExtension = true;
            SaveViewFileDialog.CheckPathExists = true;
        }
        public DatabaseGUIData() { }
        public DatabaseGUIData(string database_name)
        {
            this.databasePath = database_name;
            this.views = new List<DatabaseGUIView>();
        }

        public static string CreateRelativePath(string start, string target)
        {
            //I think there's a cleaner way to do this, so for now I've explained what I'm doing.
            start = Path.GetDirectoryName(Path.GetFullPath(start))+Path.DirectorySeparatorChar;
            target = Path.GetFullPath(target);
            /*
             * Remove all unnecessary (matching) path elements from both strings
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
             * for example,
             * "Documents/folder"
             * 
             * should return
             * "../.."
             */
            string path = "";
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
            => elements.TrueForAll(e => e.IsCompatibleWith(table_data));
        public Control Generate(DatabaseConnection database)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DatabaseConnection.IterateReader(
                () => database.GetTable(tableName),
                r => elements.ForEach(
                    e => flowLayoutPanel.Controls.Add(e.Generate(r))
                    )
                );
            return flowLayoutPanel;
        }
    }
    /// <summary>
    /// A GUI element that contains some information for current table row
    /// </summary>
    public abstract partial class DatabaseGUIViewElement
    {
        public abstract bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data);
        public abstract Control Generate(SQLiteDataReader reader);
    }
    public partial class DatabaseGUILabel
    {
        public DatabaseGUILabel() { }
        public DatabaseGUILabel(string formatableText, DatabaseGUITextInput data)
        {
            this.formatableText = formatableText;
            this.data = data;
        }

        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data) => data.IsCompatibleWith(table_data);
        public override Control Generate(SQLiteDataReader reader)
        {
            Label label = new Label();
            label.Text = String.Format(this.formatableText, data.Get(reader));
            return label;
        }
    }
    public partial class DatabaseGUITextArea
    {
        public DatabaseGUITextArea() { }
        public DatabaseGUITextArea(string text, DatabaseGUITextInput data)
        {
            this.text = text;
            this.data = data;
        }

        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data) => data.IsCompatibleWith(table_data);
        public override Control Generate(SQLiteDataReader reader)
        {
            TableLayoutPanel layout = new TableLayoutPanel();
            layout.AutoSize = true;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle());
            Label label = new Label();
            label.AutoSize = true;
            label.Font = DatabaseGUIData.defaultFont;
            label.Text = this.text;
            layout.Controls.Add(label);
            TextBox textBox = new TextBox();
            textBox.Text = data.Get(reader);
            textBox.AutoSize = true;
            textBox.Font = DatabaseGUIData.defaultFont;
            textBox.ReadOnly = true;
            layout.Controls.Add(textBox);
            return layout;
        }
    }
    public partial class DatabaseGUICheckBox
    {
        public DatabaseGUICheckBox() { }
        public override bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data) => data.IsCompatibleWith(table_data);
        public override Control Generate(SQLiteDataReader reader)
        {
            CheckBox checkbox = new CheckBox();
            checkbox.Text = this.text;
            checkbox.Font = DatabaseGUIData.defaultFont;
            checkbox.Checked = data.Get(reader);
            checkbox.Enabled = false;
            return checkbox;
        }
    }
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
            => table_data.Contains(column);
    }
    public partial class DatabaseGUITextInput
    {
        public DatabaseGUITextInput() { }
        public DatabaseGUITextInput(DatabaseConnection.TableColumn data) : base(data) { }
        public string Get(SQLiteDataReader reader)
            => reader.GetValue(reader.GetOrdinal(column.Name)).ToString();
    }
    public partial class DatabaseGUIBoolInput
    {
        public DatabaseGUIBoolInput() { }
        public DatabaseGUIBoolInput(DatabaseConnection.TableColumn data) : base(data) { }
        public bool Get(SQLiteDataReader reader)
            => reader.GetBoolean(reader.GetOrdinal(column.Name));
    }
}