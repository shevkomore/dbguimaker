using System.Windows.Forms;
using System.Drawing;

namespace dbguimaker.DatabaseGUI
{
    public abstract class EditorElement
    {
        private static Font LabelFont = new Font(FontFamily.GenericSansSerif, 9);
        protected TableLayoutPanel editorView;
        /// <summary>
        /// An array representing all the <see cref="Operation"/> inputs this component can have.
        /// This list is used to create input fields for <see cref="EditorView"/>
        /// </summary>
        public abstract Operation[] Inputs { get; }
        /// <summary>
        /// An array containing texts that will be shown by <see cref="EditorView"/> 
        /// as names of <see cref="Inputs"/> with the same array index.
        /// (which implies that the size of this array must be the same as the size of <see cref="Inputs"/> array)
        /// </summary>
        public abstract string[] InputTexts { get; }
        private Control[] inputControls;
        public Control[] InputControls
        {
            get
            {
                if (inputControls == null) return new Control[0];
                return inputControls;
            }
        }
        /// <summary>
        /// The <see cref="Control"/> that represents this element in editor.
        /// Upon first call (or after <see cref="DeleteEditorView"/>)
        /// generates a new Control to use.
        /// </summary>
        /// <remarks>
        /// The created <see cref="Control"/> consists of:
        /// <list type="number">
        /// <item>A representation of the component, as defined by <see cref="GenerateEditorRepresentation"/></item>
        /// <item>A list of <see cref="Control"/>s which represent the <see cref="Inputs"/>.</item>
        /// </list>
        /// Those inputs use names given by according <see cref="InputTexts"/> component.
        /// </remarks>
        public TableLayoutPanel EditorView {
            get
            {
                if (editorView == null)
                {
                    editorView = new TableLayoutPanel();
                    editorView.AutoSize = true;
                    editorView.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    if (Inputs.Length == 0)
                    {
                        editorView.ColumnCount = 1;
                        editorView.RowCount = 1;
                        inputControls = new Control[0];
                    }
                    else
                    {
                        editorView.ColumnCount = 2;
                        editorView.RowCount = Inputs.Length;
                        inputControls = new Control[Inputs.Length];
                        //editorView.RowStyles[0].SizeType = SizeType.AutoSize;
                        for (int i = 0; i < Inputs.Length; i++)
                        {
                            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                            inputControls[i] = label;
                            label.Font = LabelFont;
                            label.Text = InputTexts[i];
                            editorView.Controls.Add(label);
                            editorView.SetColumn(label, 0);
                            editorView.SetRow(label, i);
                        }
                    }
                    foreach(RowStyle style in editorView.RowStyles)
                        style.SizeType = SizeType.AutoSize;
                    foreach (ColumnStyle style in editorView.ColumnStyles)
                        style.SizeType = SizeType.AutoSize;
                    Control representation = GenerateEditorRepresentation();
                    representation.Enabled = false;
                    editorView.Controls.Add(representation);
                    representation.Dock = DockStyle.Fill;
                    //editorView.SetColumn(representation, 1);
                    editorView.SetRowSpan(representation, editorView.RowCount);
                }
                return editorView;
            }
        }
        /// <summary>
        /// Creates a new representation of this element in editor.
        /// Called by <see cref="EditorView"/>
        /// </summary>
        /// <returns>a new Control that represents this element in editor.</returns>
        protected abstract Control GenerateEditorRepresentation();
        /// <summary>
        /// Deletes last <see cref="EditorView"/> created.
        /// WARNING! This method doesn't delete connections between operations!
        /// </summary>
        public void DeleteEditorView()
        {
            if (editorView == null) return;
            editorView.Parent.Controls.Remove(editorView);
            editorView.Dispose();
            editorView = null;
        }
    }
}
