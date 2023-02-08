using CefSharp.WinForms;
using System;
using System.Windows.Forms;
using dbguimaker.DatabaseGUI;

namespace dbguimaker
{
    public partial class DBViewForm : Form
    {
        protected Data data;
        public ChromiumWebBrowser ChromiumView { get; set; }
        public DBViewForm(DatabaseConnection database, Data data)
        {
            InitializeComponent();
            this.data = data;
            data.views[0].Setup(database, flowLayoutPanel1);
        }

        private void DBViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainMenu.Show();
        }

        private void DBViewForm_Load(object sender, EventArgs e)
        {

            data.views[0].Generate(20);
        }
    }
}
