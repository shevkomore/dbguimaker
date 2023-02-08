using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using dbguimaker.DatabaseGUI;
using ProtoBuf;

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
            if (tablesListBox.SelectedIndex == -1) return;
            tablesListBox.Enabled = false;
            columnsListBox.Items.Clear();
            foreach(TableColumn c in db.GetTableInfo(tablesListBox.SelectedItem.ToString()))
                columnsListBox.Items.Add(c);
            data.views = new List<DatabaseGUI.View>();
            data.views.Add( new DatabaseGUI.View(tablesListBox.SelectedItem.ToString()));
        }

        private void columnsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (createdElements.Contains(columnsListBox.SelectedItem)) return;
            createdElements.Add(columnsListBox.SelectedItem);
            //TEMP
            if((columnsListBox.SelectedItem as TableColumn).RawType == "INTEGER")
            {
                data.views[0].elements.Add(
                    new DatabaseGUI.CheckBox(
                        new DatabaseGUI.Constant("Is next one one?"),
                        new DatabaseGUI.Comparison(
                            new DatabaseGUI.Input((TableColumn)columnsListBox.SelectedItem),
                            new DatabaseGUI.Constant(1),
                            DatabaseGUI.Comparison.OperationType.Equals
                            )
                        )
                    );
            }
            data.views[0].elements.Add(new DatabaseGUI.TextArea(
                new DatabaseGUI.Constant(columnsListBox.SelectedItem.ToString()),
                new DatabaseGUI.Input((TableColumn)columnsListBox.SelectedItem)));
            toolStripRefreshButton_Click(null, null);
        }

        private void toolStripRefreshButton_Click(object sender, EventArgs e)
        {
            if (data.views.Count < 1) return;
            DatabaseGUI.View view = data.views[0];
            HashSet<Operation> components = new HashSet<Operation>();
            foreach(DatabaseGUI.ViewComponent element in view.elements)
            {
                Control c = element.EditorView;
                if (!viewsLayoutPanel.Controls.Contains(c))
                {
                    viewsLayoutPanel.Controls.Add(c);
                    TraverseTree(element, ref components);
                }
            }
            int i = 10;
            foreach(Operation operation in components)
            {
                Control c = operation.EditorView;
                if (!panel1.Controls.Contains(c))
                {
                    panel1.Controls.Add(c);
                    c.Draggable(true);
                    c.Top = i; c.Left = i;
                    i += 20;
                }
            }
        }
        void TraverseTree(DatabaseGUI.EditorElement element, ref HashSet<Operation> operations)
        {
            foreach(Operation o in element.Inputs)
            {
                operations.Add(o);
                TraverseTree(o, ref operations);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            using(var output = File.OpenWrite(FilePath))
            {
                Serializer.Serialize(output, data);
            }
        }
    }

}
