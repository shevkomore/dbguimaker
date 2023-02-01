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

namespace dbguimaker
{
    public partial class DBViewForm : Form
    {
        public ChromiumWebBrowser ChromiumView { get; set; }
        public DBViewForm(DatabaseConnection database, DatabaseGUIData data)
        {
            InitializeComponent();
            //Initializing ChromiumView
            //ChromiumView = new ChromiumWebBrowser(path);
            //ChromiumView.MenuHandler = ChromiumHideMenu.Instance;
            //mainPanel.Controls.Add(ChromiumView);
            //ChromiumView.Dock = DockStyle.Fill;
            this.flowLayoutPanel1.Controls.Add( data.views[0].Generate(database));
        }

        private void DBViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainMenu.Show();
        }
    }
}
