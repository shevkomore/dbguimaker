using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker
{
    public partial class NewProjectForm : Form
    {

        public NewProjectForm()
        {
            InitializeComponent();
        }

        private void NewProjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Program.currentEditor == null)
                Program.mainMenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "SQLite Database files|*.db";
            dialog.Title = "Select a file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DatabaseTextBox.Text = dialog.FileName;
            }
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(DatabaseTextBox.Text))
            {
                Program.currentEditor = new EditorForm(DatabaseTextBox.Text, NameTextBox.Text);
                Program.currentEditor.Show();
                this.Close();
            }

        }
    }
}
