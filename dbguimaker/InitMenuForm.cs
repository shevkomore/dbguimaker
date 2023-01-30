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
    public partial class InitMenuForm : Form
    {
        public InitMenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "index.html|index.html";
            dialog.InitialDirectory = Environment.CurrentDirectory + "/ViewTemplates/ListView/html";
            dialog.Title = "Select a file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.Hide();
                Program.viewForms.Add(new DBViewForm(dialog.FileName));
                Program.viewForms[0].Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new NewProjectForm().Show();
        }
    }
}
