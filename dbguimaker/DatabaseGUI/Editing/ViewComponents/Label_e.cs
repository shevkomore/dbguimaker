
using System;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class Label
    {
        public override Operation[] Inputs => new Operation[1] { this.text };
        public override void SetInput(int index, Operation operation)
        {
            switch (index)
            {
                case 0:
                    text = operation;
                    return;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public override string[] InputTexts => new string[1] { "Text" };

        protected override Control GenerateEditorRepresentation()
        {
            System.Windows.Forms.Label repr = new System.Windows.Forms.Label();
            repr.AutoSize = true;
            repr.Font = Data.DefaultRepresentationFont;
            repr.Text = "\"Text\"";
            return repr;
        }
    }
}