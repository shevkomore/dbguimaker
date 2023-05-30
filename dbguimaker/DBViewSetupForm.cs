using ProtoBuf;
using System;
using System.IO;
using System.Windows.Forms;
using dbguimaker.DatabaseGUI;

namespace dbguimaker
{
    public partial class DBViewSetupForm : Form
    {
        Data currentData;
        string defaultDatabasePath;
        public DBViewSetupForm()
        {
            InitializeComponent();
            if (Data.OpenDataFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenData(Data.OpenDataFileDialog.FileName);
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
                currentData = Serializer.Deserialize<Data>(str);
                dataPathTextBox.Text = data_file;
                dataPathDialogButton.Enabled = false;
                // for now, only file selection can be used to create a path
                databasePathTextBox.ReadOnly = true;
                dataPathTextBox.ReadOnly = true;
                // ^that might be changed later.
                defaultDatabasePath = Data.FollowRelativePath(data_file, currentData.databasePath);
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
            if(Data.OpenDataFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenData(Data.OpenDataFileDialog.FileName);
            }
        }

        private void databasePathDialogButton_Click(object sender, EventArgs e)
        {
            if(Data.OpenDataFileDialog.ShowDialog() == DialogResult.OK)
            {
                databasePathTextBox.Text = Data.OpenDataFileDialog.FileName;
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
            if (currentData.databasePath == null)
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
            currentData.FinalizeDeserialization();
            new DBViewForm(database, currentData).Show();
            this.Close();
        }
    }
}
