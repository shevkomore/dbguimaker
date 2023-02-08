using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProtoBuf;
using System.IO;
using dbguimaker.Serialization;

namespace dbguimaker
{
    public partial class EditorForm : Form
    {
        public List<Button> buttons = new List<Button>();
        public List<object> createdElements = new List<object> ();
        public DatabaseConnection db;
        public string FilePath;
        /*TEMP*/
        public DatabaseGUI.Data data;
        public EditorForm(string database_path, string file_path)
        {
            this.FilePath = file_path;

            InitializeComponent();

            this.db = new DatabaseConnection(database_path);
            label1.Text = "SQLite version " + db.ExecuteOnce("SELECT SQLITE_VERSION()");

            DatabaseConnection.IterateReader(db.GetTableNames,
                e => tablesListBox.Items.Add(e.GetString(e.GetOrdinal("name")))
                );

            //TEMP
            data = new DatabaseGUI.Data(DatabaseGUI.Data.CreateRelativePath(file_path, database_path));
            //END OF TEMP
            tablesListBox.SelectedIndex = 0;

        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.currentEditor = null;
            Program.mainMenu.Show();
            if (Path.GetExtension(FilePath) != ".dbgui") FilePath = FilePath + ".dbgui";
            //TEMP
            /*using (var file = File.Create(FilePath))
            {
                Serializer.Serialize(file, data);
            }*/
        }

        private void tablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            columnsListBox.Items.Clear();
            foreach(TableColumn c in db.GetTableInfo(tablesListBox.SelectedItem.ToString()))
                columnsListBox.Items.Add(c);
            //TEMP
            if(tablesListBox.SelectedIndex != -1)
                data.views.Add(new DatabaseGUI.View(tablesListBox.SelectedItem.ToString()));
        }

        private void columnsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (createdElements.Contains(columnsListBox.SelectedItem)) return;
            createdElements.Add(columnsListBox.SelectedItem);
            Button b = new Button();
            b.Text = ((TableColumn)columnsListBox.SelectedItem).Name;
            Point b_pos = MousePosition;
            b_pos.Offset(150, 0);
            b.Location = b_pos;
            b.Size = new Size(100, 50);
            //ControlExtension.Draggable(b, true);
            panel1.Controls.Add(b);
            //TEMP
            if((columnsListBox.SelectedItem as TableColumn).RawType == "INTEGER")
            {
                /*data.views[0].elements.Add(
                    new DatabaseGUICheckBox("Is next one one?",
                        new DatabaseGUIIntComparison(
                            new DatabaseGUIIntInput((DatabaseConnection.TableColumn)columnsListBox.SelectedItem),
                            new DatabaseGUIIntConstant(1),
                            DatabaseGUIIntComparison.OperationType.Equals
                            )
                        )
                    );*/
            }
            /*data.views[0].elements.Add(new DatabaseGUITextArea(
                columnsListBox.SelectedItem.ToString(), 
                new DatabaseGUITextInput((DatabaseConnection.TableColumn)columnsListBox.SelectedItem)));*/
        }

        private void toolStripRefreshButton_Click(object sender, EventArgs e)
        {
            if (data.views.Count < 1) return;
            DatabaseGUI.View view = data.views[0];
            foreach(DatabaseGUI.ViewComponent element in view.elements)
            {

            }
        }
    }

}
