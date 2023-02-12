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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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

        public List<string> ConstantOptions = new List<string>();
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

        private void tablesListBox_SelectedIndexChanged(object sender, EventArgs args)
        {
            if (tablesListBox.SelectedIndex == -1) return;
            tablesListBox.Enabled = false;

            foreach (TableColumn c in db.GetTableInfo(tablesListBox.SelectedItem.ToString()))
            {
                Input e = new Input(c);
                InputsLayoutPanel.Controls.Add(e.EditorView);
                createdElements.Add(e);
                ConstantOptions.Add(c.Name);
                e.EditorView.MouseClick += EditorElement_MouseClick;
            }

            data.views = new List<DatabaseGUI.View>();
            data.views.Add( new DatabaseGUI.View(tablesListBox.SelectedItem.ToString()));
            currentView = data.views[0];
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
                if (element is Operation & !(element is Input) & !panel1.Controls.Contains(c))
                {
                    panel1.Controls.Add(c);
                    c.Draggable(true);
                    c.GetDragSettings().AvoidOverlap = false;
                    c.MouseClick += EditorElement_MouseClick;
                    foreach (EditorElementInput input in c.InputControls)
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
                    if (c.Element is Input) return;
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
            HashSet<EditorElement> els = new HashSet<EditorElement>();
            TraverseTree(currentView, ref els);
            using (var output = File.OpenWrite(FilePath))
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


        private void panel1_Paint(object sender, PaintEventArgs args)
        {
            graphics.Clear(BackColor);

            foreach (EditorElement o in createdElements)
            {
                for (int i = 0; i < o.Inputs.Length; ++i)
                {
                    if (o.Inputs[i] == null || o.Inputs[i] == DatabaseGUI.Constant.Default) continue;
                    graphics.DrawLine(pen,
                        GetCenterLocation(o.EditorView.InputControls[i], panel1),
                        GetCenterLocation(o.Inputs[i].EditorView, panel1)
                        );
                }
            }
            if (operationMode == InterfaceOperationMode.Reconnection)
            {
                graphics.DrawLine(pen, GetCenterLocation(pendingConnection, panel1),
                    MousePosition - new Size(panel1.Location) - new Size(Location));
            }
        }
        private void addConstantToolStripButton_Click(object sender, EventArgs args)
        {
            var d = ConstantDialog.Create(ConstantOptions.ToArray());
            if (d.Success)
            {
                EditorElement e = new Constant(d.Text);
                panel1.Controls.Add(e.EditorView);
                createdElements.Add(e);
                e.EditorView.Left = panel1.Size.Width / 2;
                e.EditorView.Top = panel1.Size.Height / 2;
                e.EditorView.Draggable(true);
                e.EditorView.MouseClick += EditorElement_MouseClick;
                e.EditorView.DoubleClick += EditorView_DoubleClick;
            }
        }
        private void addComparisonToolStripButton_Click(object sender, EventArgs args)
        {
            var d = ComparisonDialog.Create();
            if (d.Success)
            {
                EditorElement e = new Comparison(null, null, d.Result);
                panel1.Controls.Add(e.EditorView);
                createdElements.Add(e);
                e.EditorView.Left = panel1.Size.Width / 2;
                e.EditorView.Top = panel1.Size.Height / 2;
                e.EditorView.Draggable(true);
                e.EditorView.MouseClick += EditorElement_MouseClick;
                e.EditorView.DoubleClick += EditorView_DoubleClick;
                foreach (EditorElementInput input in e.EditorView.InputControls)
                    input.MouseClick += EditorElementInput_MouseClick;
            }
        }

        private void EditorView_DoubleClick(object sender, EventArgs e)
        {
            if (sender is EditorElementContainer)
            {
                EditorElementContainer ee = sender as EditorElementContainer;
                if (ee.Element is Constant)
                {
                    var c = (Constant)ee.Element;
                    var d = ConstantDialog.Create(ConstantOptions.ToArray());
                    if (d.Success)
                        c.value = d.Text;
                    return;
                }
                if(ee.Element is Comparison)
                {
                    Comparison c = (Comparison)ee.Element;
                    var d = ComparisonDialog.Create();
                    if (d.Success)
                        c.operationType = d.Result;
                    return;
                }
            }
        }

        private void addLabelToolStripButton_Click(object sender, EventArgs e)
        {
            DatabaseGUI.Label l = new DatabaseGUI.Label();
            viewsLayoutPanel.Controls.Add(l.EditorView);
            createdElements.Add(l);
            currentView.elements.Add(l);
            l.EditorView.MouseClick += EditorElement_MouseClick;
            foreach (EditorElementInput input in l.EditorView.InputControls)
                input.MouseClick += EditorElementInput_MouseClick;
        }
        private void addFieldToolStripButton_Click(object sender, EventArgs e)
        {
            DatabaseGUI.TextArea a = new TextArea();
            viewsLayoutPanel.Controls.Add(a.EditorView);
            createdElements.Add(a);
            currentView.elements.Add(a);
            a.EditorView.MouseClick += EditorElement_MouseClick;
            foreach (EditorElementInput input in a.EditorView.InputControls)
                input.MouseClick += EditorElementInput_MouseClick;
        }
        private void addTextboxToolStripButton_Click(object sender, EventArgs e)
        {
            DatabaseGUI.CheckBox c = new DatabaseGUI.CheckBox();
            viewsLayoutPanel.Controls.Add(c.EditorView);
            createdElements.Add(c);
            currentView.elements.Add(c);
            c.EditorView.MouseClick += EditorElement_MouseClick;
            foreach (EditorElementInput input in c.EditorView.InputControls)
                input.MouseClick += EditorElementInput_MouseClick;
        }












        private static Point GetCenter(Control control)
            => control.Location + new Size(control.Size.Width / 2, control.Size.Height / 2);
        private static Point GetCenterLocation(Control control, Control target_parent)
        {
            Size o_pos = new Size(0,0);
            Control parent = control.Parent;
            while (parent != target_parent)
            {
                if (parent == control.TopLevelControl && target_parent != control.TopLevelControl)
                    throw new Exception("Given target_parent is not parent to given control");
                o_pos = new Size(parent.Location + o_pos);
                parent = parent.Parent;
            }
            return GetCenter(control) + o_pos;
        }

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

        private void InputsLayoutPanel_Scroll(object sender, ScrollEventArgs e)
        {
            panel1_Paint(sender, null);
        }
    }

}
