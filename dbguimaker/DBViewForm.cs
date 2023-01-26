using CefSharp.WinForms;
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
    public partial class DBViewForm : Form
    {
        private static string LIST_VIEW_PATH = "/ViewTemplates/ListView/html/index.html";
        public ChromiumWebBrowser ChromiumView { get; set; }
        public DBViewForm()
        {
            InitializeComponent();
            //Initializing ChromiumView
            string path = Environment.CurrentDirectory + LIST_VIEW_PATH;
            ChromiumView = new ChromiumWebBrowser(path);
            ChromiumView.MenuHandler = ChromiumHideMenu.Instance;
            mainPanel.Controls.Add(ChromiumView);
            ChromiumView.Dock = DockStyle.Fill;
        }
    }
}
