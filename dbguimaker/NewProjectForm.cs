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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace dbguimaker
{
    public partial class NewProjectForm : Form
    {
        public static string defaultName = "view";
        public static string extension = ".dbgui";
        public NewProjectForm()
        {
            InitializeComponent();
        }
        private string GetNewFileName(string database_path)
        {
            string directory = Path.GetDirectoryName(database_path) + Path.DirectorySeparatorChar;
            int index = 1;
            while (File.Exists(directory + defaultName + index + extension))++index;
            return directory + defaultName + index + extension;
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
                NameTextBox.Text = GetNewFileName(dialog.FileName);
            }
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(DatabaseTextBox.Text))
            {
                Program.currentEditor = new EditorForm(
                    DatabaseTextBox.Text, 
                    NameTextBox.Text);
                Program.currentEditor.Show();
                this.Close();
            }

        }

        private void viewFileDialogButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save view to...";
            dialog.DefaultExt = ".dbgui";
            dialog.FileName = "view";
            dialog.AddExtension = true;
            dialog.CheckPathExists = true;
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                NameTextBox.Text = dialog.FileName;
            }
        }
    }
}
