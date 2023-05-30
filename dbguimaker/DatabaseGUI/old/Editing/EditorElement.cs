using System.Windows.Forms;
using System.Drawing;
using dbguimaker.DatabaseGUI.Editing;
using System;
using System.Linq;

namespace dbguimaker.DatabaseGUI
{
    public abstract class EditorElement
    {
        protected EditorElementContainer editorView;
        /// <summary>
        /// An array representing all the <see cref="IOperation"/> inputs this component can have.
        /// This list is used to create input fields for <see cref="EditorView"/>
        /// </summary>
        public abstract IOperation[] Inputs { get; }
        public abstract void SetInput(int index, IOperation operation);
        /// <summary>
        /// An array containing texts that will be shown by <see cref="EditorView"/> 
        /// as names of <see cref="Inputs"/> with the same array index.
        /// (which implies that the size of this array must be the same as the size of <see cref="Inputs"/> array)
        /// </summary>
        public abstract string[] InputTexts { get; }
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
        public EditorElementContainer EditorView {
            get
            {
                if (editorView == null)
                {
                    
                    editorView = new EditorElementContainer(this);
                    editorView.AutoSize = true;
                    editorView.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    
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

        public void DeleteInput(IOperation element)
        {
            if(Inputs.ToList().IndexOf(element) >= 0)
               SetInput(Inputs.ToList().IndexOf(element), null);
        }
    }
}
