using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI.Editing
{
    public class EditorElementContainer : TableLayoutPanel
    {
        private static Font LabelFont = new Font(FontFamily.GenericSansSerif, 9);

        public EditorElement Element;
        private EditorElementInput[] inputControls;
        public EditorElementInput[] InputControls
        {
            get
            {
                if (inputControls == null) return new EditorElementInput[0];
                return inputControls;
            }
        }
        public EditorElementContainer(EditorElement element) : base()
        {
            Element = element;
            inputControls = new EditorElementInput[Element.Inputs.Length];
            if (inputControls.Length == 0)
            {
                ColumnCount = 1;
                RowCount = 1;
            }
            else
            {
                ColumnCount = 2;
                RowCount = inputControls.Length;
                //editorView.RowStyles[0].SizeType = SizeType.AutoSize;
                for (int i = 0; i < inputControls.Length; i++)
                {
                    EditorElementInput b = new EditorElementInput(Element, i);
                    inputControls[i] = b;
                    b.AutoSize = true;
                    b.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    b.Font = LabelFont;
                    b.Text = Element.InputTexts[i];
                    Controls.Add(b);
                    SetColumn(b, 0);
                    SetRow(b, i);
                }
            }
        } 
    }
    public class EditorElementInput : Button
    {
        public EditorElement Element;
        public int index;
        public IOperation Input { get
            {
                return Element.Inputs[index];
            } }
        public EditorElementInput(EditorElement element, int index) : base()
        {
            Element = element;
            this.index = index;
        }
        public void ConnectTo(EditorElementContainer c)
        {
            Element.SetInput(index, (IOperation)c.Element);
        }
    }
}
