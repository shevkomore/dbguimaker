using ProtoBuf;
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
    public partial class DBViewSetupForm : Form
    {
        DatabaseGUIData currentData;
        string defaultDatabasePath;
        static OpenFileDialog dataFileDialog = new OpenFileDialog();
        static OpenFileDialog databaseFileDialog = new OpenFileDialog();
        static DBViewSetupForm()
        {
            dataFileDialog.Filter =
               "Database View File|*.dbgui";
            dataFileDialog.CheckFileExists = true;
            dataFileDialog.Title = "Select a file";
            databaseFileDialog.Filter =
               "Database File|*.db";
            databaseFileDialog.CheckFileExists = true;
            databaseFileDialog.Title = "Select a database";
        }
        public DBViewSetupForm()
        {
            InitializeComponent();
            if (dataFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenData(dataFileDialog.FileName);
                useFixedPathCheckBox.Checked = true;
                TryUseDefaultDatabasePath();//might be duplicate call
            }
        }
        /// <summary>
        /// Deserializes the data from file
        /// </summary>
        /// <param name="data_file">the file where DatabaseGUIData is stored</param>
        protected void OpenData(string data_file)
        {
            using (var str = File.OpenRead(data_file))
            {
                currentData = Serializer.Deserialize<DatabaseGUIData>(str);
                dataPathTextBox.Text = data_file;
                dataPathDialogButton.Enabled = false;
                // for now, only file selection can be used to create a path
                databasePathTextBox.ReadOnly = true;
                dataPathTextBox.ReadOnly = true;
                // ^that might be changed later.
                defaultDatabasePath = DatabaseGUIData.FollowRelativePath(data_file, currentData.databasePath);
            }
        }
        /// <summary>
        /// A combination of enabling/disabling both database file selection button and text field
        /// </summary>
        /// <param name="enabled">Can the user use these controls?</param>
        public void SetAllowDatabasePathSelection(bool enabled)
        {
            databasePathDialogButton.Enabled = enabled;
            databasePathTextBox.ReadOnly = true;//= !enabled;
        }
        /// <summary>
        /// Tries to use the default database path (the one from a file) if viable, otherwise shows the user that they can't use it
        /// </summary>
        public void TryUseDefaultDatabasePath()
        {
            if (File.Exists(defaultDatabasePath))
            {
                SetAllowDatabasePathSelection(false);
                databasePathTextBox.Text = defaultDatabasePath;
            }
            else
            {
                errorProvider.SetError(databasePathTextBox, "Invalid default path. Plase provide the path to a database.");
                useFixedPathCheckBox.Checked = false;
            }
        }
        private void dataPathDialogButton_Click(object sender, EventArgs e)
        {
            if(dataFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenData(dataFileDialog.FileName);
            }
        }

        private void databasePathDialogButton_Click(object sender, EventArgs e)
        {
            if(databaseFileDialog.ShowDialog() == DialogResult.OK)
            {
                databasePathTextBox.Text = databaseFileDialog.FileName;
            }
        }

        private void useFixedPathCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useFixedPathCheckBox.Checked)
            {
                TryUseDefaultDatabasePath();
            } else
            {
                SetAllowDatabasePathSelection(true);
            }

        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(dataPathTextBox.Text))
            {
                errorProvider.SetError(dataPathTextBox, "Invalid file path.");
                return;
            }
            if (currentData.databasePath == null)//attempt at checking whether the data is valid
            {
                OpenData(dataPathTextBox.Text);
                if (currentData.databasePath == null)
                {
                    errorProvider.SetError(dataPathTextBox, "Invalid view data.");
                    return;
                }
            }
            if (!File.Exists(databasePathTextBox.Text))
            {
                errorProvider.SetError(databasePathTextBox, "Invalid database file path.");
                return;
            }
            DatabaseConnection database = new DatabaseConnection(databasePathTextBox.Text);
            if (!currentData.IsCompatibleWith(database))
            {
                errorProvider.SetError(databasePathTextBox, "The database is incompatible with the view. Try using a different database.");
                return;
            }
            new DBViewForm(database, currentData).Show();
            this.Close();
        }
    }
}
