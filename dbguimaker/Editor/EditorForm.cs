using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using dbguimaker.DatabaseGUI;
using ProtoBuf;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace dbguimaker
{
    public partial class EditorForm : Form
    {
        private Graphics graphics;
        public HashSet<EditorElement> createdElements = new HashSet<EditorElement> ();
        public DatabaseConnection db;
        public string FilePath;
        /*TEMP*/
        public DatabaseGUI.Data data;
        public DatabaseGUI.View currentView;
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

            graphics = panel1.CreateGraphics();
        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.currentEditor = null;
            Program.mainMenu.Show();
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
            currentView = data.views[0];
        }

        private void columnsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            /*HashSet<EditorElement> els = new HashSet<EditorElement>();
            TraverseTree(currentView, ref els);*/
            TraverseTree(currentView, ref createdElements);
            int i = 10;
            foreach(EditorElement element in createdElements)
            {
                //removes all elements that are not connected to view
                /*if (!els.Contains(element))
                {
                    if (element is Operation)
                        panel1.Controls.Remove(element.EditorView);
                    else if (element is ViewComponent)
                        viewsLayoutPanel.Controls.Remove(element.EditorView);
                    element.DeleteEditorView();
                }*/
                Control c = element.EditorView;
                if (element is ViewComponent & !viewsLayoutPanel.Controls.Contains(c))
                {
                    viewsLayoutPanel.Controls.Add(c);
                    TraverseTree(element, ref createdElements);
                }
                if (element is Operation & !panel1.Controls.Contains(c))
                {
                    panel1.Controls.Add(c);
                    c.Draggable(true);
                    c.GetDragSettings().AvoidOverlap = false;
                    c.Top = i; c.Left = i;
                    i += 30;
                }
            }
        }
        void TraverseTree(DatabaseGUI.View view, ref HashSet<EditorElement> operations)
        {
            foreach(EditorElement element in view.elements)
            {
                operations.Add(element);
                TraverseTree(element, ref operations);
            }
        }
        void TraverseTree(DatabaseGUI.EditorElement element, ref HashSet<EditorElement> operations)
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
        public void DrawConnections(HashSet<Operation> operations)
        {
            /*Pen pen = new Pen(Color.DarkRed, 2);

            foreach(Operation o in operations)
            {
                for(int i = 0; i < o.Inputs.Length; ++i)
                {
                    if (o.Inputs[i] == null) continue;
                    graphics.DrawLine(pen,
                        o.InputControls[i].Location,
                        o.Inputs[i].EditorView.Location);
                }
            }*/
        }
        //TODO didn't work
        private void EditorForm_Paint(object sender, PaintEventArgs args)
        {
            Pen pen = new Pen(Color.DarkRed, 2);

            foreach (Operation o in createdElements)
            {
                for (int i = 0; i < o.Inputs.Length; ++i)
                {
                    if (o.Inputs[i] == null) continue;
                    graphics.DrawLine(pen,
                        o.InputControls[i].Location,
                        o.Inputs[i].EditorView.Location);
                }
            }
        }
    }

}
