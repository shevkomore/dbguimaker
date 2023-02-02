using CefSharp;
using CefSharp.WinForms;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
