﻿using System;
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
        public DatabaseGUIData a;
        public EditorForm(string database_path, string file_path)
        {
            this.FilePath = file_path;

            InitializeComponent();

            this.db = new DatabaseConnection(database_path);
            label1.Text = "SQLite version " + db.Execute("SELECT SQLITE_VERSION()");

            DatabaseConnection.IterateReader(db.GetTableNames,
                e => tablesListBox.Items.Add(e.GetString(e.GetOrdinal("name")))
                );

            //TEMP
            a = new DatabaseGUIData(DatabaseGUIData.CreateRelativePath(file_path, database_path));
            //END OF TEMP
            tablesListBox.SelectedIndex = 0;

        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.currentEditor = null;
            Program.mainMenu.Show();
            if (Path.GetExtension(FilePath) != ".dbgui") FilePath = FilePath + ".dbgui";
            //TEMP
            using (var file = File.Create(FilePath))
            {
                Serializer.Serialize(file, a);
            }
        }

        private void tablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            columnsListBox.Items.Clear();
            foreach(DatabaseConnection.TableColumn c in db.GetTableInfo(tablesListBox.SelectedItem.ToString()))
                columnsListBox.Items.Add(c);
            //TEMP
            if(tablesListBox.SelectedIndex != -1)
                a.views.Add(new DatabaseGUIView(tablesListBox.SelectedItem.ToString()));
        }

        private void columnsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (createdElements.Contains(columnsListBox.SelectedItem)) return;
            createdElements.Add(columnsListBox.SelectedItem);
            Button b = new Button();
            b.Text = ((DatabaseConnection.TableColumn)columnsListBox.SelectedItem).Name;
            Point b_pos = MousePosition;
            b_pos.Offset(150, 0);
            b.Location = b_pos;
            b.Size = new Size(100, 50);
            ControlExtension.Draggable(b, true);
            panel1.Controls.Add(b);
            //TEMP
            if((columnsListBox.SelectedItem as DatabaseConnection.TableColumn).Type == "INTEGER")
            {
                a.views[0].elements.Add(
                    new DatabaseGUICheckBox("Is next one one?",
                        new DatabaseGUIIntComparison(
                            new DatabaseGUIIntInput((DatabaseConnection.TableColumn)columnsListBox.SelectedItem),
                            new DatabaseGUIIntConstant(1),
                            DatabaseGUIIntComparison.OperationType.Equals
                            )
                        )
                    );
            }
            a.views[0].elements.Add(new DatabaseGUITextArea(
                columnsListBox.SelectedItem.ToString(), 
                new DatabaseGUITextInput((DatabaseConnection.TableColumn)columnsListBox.SelectedItem)));
        }
    }

}
