using CefSharp.WinForms;
using System;
using System.Windows.Forms;
using dbguimaker.Serialization;

namespace dbguimaker
{
    public partial class DBViewForm : Form
    {
        protected DatabaseGUIData data;
        public ChromiumWebBrowser ChromiumView { get; set; }
        public DBViewForm(DatabaseConnection database, DatabaseGUIData data)
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
