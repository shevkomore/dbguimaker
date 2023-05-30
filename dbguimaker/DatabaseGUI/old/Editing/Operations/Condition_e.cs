using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class Condition
    {
        public override IOperation[] Inputs => new IOperation[3] { this.Check, this.ifTrue, this.ifFalse };
        public override void SetInput(int index, IOperation operation)
        {
            switch (index)
            {
                case 0:
                    this.Check = operation;
                    return;
                case 1:
                    this.ifTrue = operation;
                    return;
                case 2:
                    this.ifFalse = operation;
                    return;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public override string[] InputTexts => new string[3] { "Condition", "A", "B" };
        protected override Control GenerateEditorRepresentation()
        {
            Control repr = new Button();

            repr.Text = "If(Condition):\n\tA;\nelse:\n\tB;";
            repr.Font = Data.DefaultRepresentationFont;
            repr.Enabled = false;

            return repr;
        }
    }
}
