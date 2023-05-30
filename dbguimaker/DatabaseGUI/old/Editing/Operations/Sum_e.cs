using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class Sum
    {
        public override IOperation[] Inputs => new IOperation[2] { this.firstOperand, this.secondOperand };
        public override string[] InputTexts => new string[2] { "A", "B" };
        public override void SetInput(int index, IOperation operation)
        {
            switch (index)
            {
                case 0:
                    firstOperand = operation;
                    return;
                case 1:
                    secondOperand = operation;
                    return;
                default: throw new IndexOutOfRangeException();
            }
        }
        protected override Control GenerateEditorRepresentation()
        {
            Control repr = new Button();

            repr.Text = "A + B";
            repr.Font = Data.DefaultRepresentationFont;
            repr.Enabled = false;

            return repr;
        }
    }
}
