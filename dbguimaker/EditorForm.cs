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

namespace dbguimaker
{
    public partial class EditorForm : Form
    {
        public static SQLiteConnection db;
        public string name;
        public EditorForm(string path, string name)
        {
            this.name = name;
            db = new SQLiteConnection("Data Source="+path);
            db.Open();

            InitializeComponent();
            label1.Text = "SQLite version " + new SQLiteCommand("SELECT SQLITE_VERSION()", db).ExecuteScalar();
        }
        public SQLiteDataReader Get(string command) => new SQLiteCommand(command, db).ExecuteReader();

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.currentEditor = null;
            Program.mainMenu.Show();
        }
    }
    

}
