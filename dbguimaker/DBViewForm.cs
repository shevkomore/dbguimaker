using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker
{
    public partial class DBViewForm : Form
    {
        public ChromiumWebBrowser ChromiumView { get; set; }
        public DBViewForm(string path)
        {
            InitializeComponent();
            //Initializing ChromiumView
            ChromiumView = new ChromiumWebBrowser(path);
            ChromiumView.MenuHandler = ChromiumHideMenu.Instance;
            mainPanel.Controls.Add(ChromiumView);
            ChromiumView.Dock = DockStyle.Fill;
        }

        private void DBViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainMenu.Show();
        }
    }
}
