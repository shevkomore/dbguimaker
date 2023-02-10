using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using dbguimaker.DatabaseGUI;
using ProtoBuf;
using System.Drawing.Drawing2D;
using System.Xml.Linq;
using dbguimaker.DatabaseGUI.Editing;
using System.Linq;

namespace dbguimaker
{
    public partial class EditorForm : Form
    {
        private Graphics graphics;
        private Pen pen = new Pen(Color.DarkRed, 2);
        private InterfaceOperationMode operationMode = InterfaceOperationMode.Default;

        enum InterfaceOperationMode
        {
            Default,
            Deletion,
            Reconnection
        }


        public HashSet<EditorElement> createdElements = new HashSet<EditorElement> ();
        private EditorElementInput pendingConnection;
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
            panel1.Paint += panel1_Paint;
            panel1.MouseMove += Panel1_MouseMove;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (operationMode == InterfaceOperationMode.Reconnection) panel1_Paint(sender, null);
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
            if (operationMode != InterfaceOperationMode.Default || data.views.Count < 1) return;
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
                EditorElementContainer c = element.EditorView;
                if (element is ViewComponent & !viewsLayoutPanel.Controls.Contains(c))
                {
                    viewsLayoutPanel.Controls.Add(c);
                    foreach (EditorElementInput input in c.InputControls)
                        if (input != null)
                            input.MouseClick += EditorElementInput_MouseClick;
                    TraverseTree(element, ref createdElements);
                }
                if (element is Operation & !panel1.Controls.Contains(c))
                {
                    panel1.Controls.Add(c);
                    c.Draggable(true);
                    c.GetDragSettings().AvoidOverlap = false;
                    c.MouseClick += EditorElement_MouseClick;
                    foreach(EditorElementInput input in c.InputControls)
                        if(input != null)
                            input.MouseClick += EditorElementInput_MouseClick;
                    
                    c.Top = i; c.Left = i;
                    i += 30;
                }
            }
        }

        private void EditorElementInput_MouseClick(object sender, MouseEventArgs args)
        {
            if(operationMode == InterfaceOperationMode.Default)
            {
                pendingConnection = sender as EditorElementInput;
                foreach (EditorElement e in createdElements)
                    e.DeleteInput(pendingConnection.Input);
                operationMode = InterfaceOperationMode.Reconnection;
            }
        }

        private void EditorElement_MouseClick(object sender, MouseEventArgs args)
        {
            if(sender is EditorElementContainer )
            {
                EditorElementContainer c = sender as EditorElementContainer;
                if(operationMode == InterfaceOperationMode.Deletion)
                {
                    createdElements.Remove(c.Element);
                    foreach (EditorElement e in createdElements)
                        e.DeleteInput((Operation)c.Element);
                    c.Element.DeleteEditorView();
                    operationMode = InterfaceOperationMode.Default;
                    return;
                }
                if(operationMode == InterfaceOperationMode.Reconnection)
                {
                    pendingConnection.ConnectTo(c);
                    operationMode = InterfaceOperationMode.Default;
                    panel1_Paint(sender, null);
                    return;
                }
            }
        }

        private void toolStripSaveButton_Click(object sender, EventArgs e)
        {
            if (operationMode == InterfaceOperationMode.Reconnection) return;
            using(var output = File.OpenWrite(FilePath))
            {
                Serializer.Serialize(output, data);
            }
        }

        private void ToolStripDeleteButton_Click(object sender, EventArgs e)
        {
            if(operationMode == InterfaceOperationMode.Deletion)
            {
                operationMode = InterfaceOperationMode.Default;
                return;
            } 
            operationMode = InterfaceOperationMode.Deletion;
        }

        private void toolStripAddButton_Click(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs args)
        {
            graphics.Clear(BackColor);

            foreach (EditorElement o in createdElements)
            {
                Size o_pos = new Size(o.EditorView.Location);
                if (o is ViewComponent)
                    o_pos = new Size(o.EditorView.Parent.Location + o_pos);
                for (int i = 0; i < o.Inputs.Length; ++i)
                {
                    if (o.Inputs[i] == null || o.Inputs[i] == DatabaseGUI.Constant.Default) continue;
                    graphics.DrawLine(pen,
                        GetCenter(o.EditorView.InputControls[i]) + o_pos,
                        GetCenter(o.Inputs[i].EditorView));
                }
            }
            if (operationMode == InterfaceOperationMode.Reconnection)
            {
                Size o_pos = new Size(pendingConnection.Element.EditorView.Location);
                if (pendingConnection.Element is ViewComponent)
                    o_pos = new Size(pendingConnection.Element.EditorView.Parent.Location + o_pos);
                graphics.DrawLine(pen, GetCenter(pendingConnection) + o_pos,
                    MousePosition - new Size(panel1.Location) - new Size(Location));
            }
        }











        private static Point GetCenter(Control control)
            => control.Location + new Size(control.Size.Width / 2, control.Size.Height / 2);

        void TraverseTree(DatabaseGUI.View view, ref HashSet<EditorElement> operations)
        {
            foreach (EditorElement element in view.elements)
            {
                operations.Add(element);
                TraverseTree(element, ref operations);
            }
        }
        void TraverseTree(DatabaseGUI.EditorElement element, ref HashSet<EditorElement> operations)
        {
            foreach (Operation o in element.Inputs)
            {
                if(o == null) continue;
                operations.Add(o);
                TraverseTree(o, ref operations);
            }
        }
    }

}
