using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace dbguimaker
{
    public partial class EditorForm : Form
    {
        public List<Button> buttons = new List<Button>();
        public List<object> createdElements = new List<object> ();
        public static SQLiteConnection db;
        public string name;
        SQLiteCommand selectNames;
        SQLiteCommand selectTableNames;

        public EditorForm(string path, string name)
        {
            this.name = name;
            db = new SQLiteConnection("Data Source="+path);
            db.Open();

            InitializeComponent();
            label1.Text = "SQLite version " + GetS("SELECT SQLITE_VERSION()");
            InitializeDBCommands();

            IterateReader(selectTableNames.ExecuteReader,
                e => tablesListBox.Items.Add(e.GetString(e.GetOrdinal("name")))
                );

            tablesListBox.SelectedIndex = 0;
        }

        private void InitializeDBCommands()
        {
            selectTableNames = new SQLiteCommand("SELECT name FROM sqlite_schema WHERE type='table' AND name NOT LIKE 'sqlite_%'", db);
            selectTableNames.CommandType = CommandType.Text;
            selectNames = new SQLiteCommand("SELECT name FROM PRAGMA_TABLE_INFO('@tablename')", db);
            selectNames.CommandType = CommandType.Text;
        }
        public object GetS(string command) => new SQLiteCommand(command, db).ExecuteScalar();
        public static void IterateReader(Func<SQLiteDataReader> create_reader, Action<SQLiteDataReader> iteration)
        {
            using (SQLiteDataReader r = create_reader())
                while (r.Read())
                    iteration(r);
        }
        public SQLiteDataReader GetTable(object table_name)
        {
            label1.Text = GetS("SELECT name FROM PRAGMA_TABLE_INFO('"+table_name+"')").ToString();
            selectNames.CommandText = "SELECT name FROM PRAGMA_TABLE_INFO('" + table_name + "')";
            return selectNames.ExecuteReader();
        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.currentEditor = null;
            Program.mainMenu.Show();
        }

        private void tablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            columnsListBox.Items.Clear();
            IterateReader(() => GetTable(tablesListBox.SelectedItem), 
                r => columnsListBox.Items.Add(r.GetString(r.GetOrdinal("name")))
                );
        }

        private void columnsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (createdElements.Contains(columnsListBox.SelectedItem)) return;
            createdElements.Add(columnsListBox.SelectedItem);
            Button b = new Button();
            b.Text = columnsListBox.SelectedItem.ToString();
            Point b_pos = MousePosition;
            b_pos.Offset(-150, 0);
            b.Location = b_pos;
            b.Size = new Size(100, 50);
            ControlExtension.Draggable(b, true);
            panel1.Controls.Add(b);
        }
    }
    

}
