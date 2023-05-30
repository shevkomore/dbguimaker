
using System;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class Comparison
    {
        public override IOperation[] Inputs => new IOperation[2] {this.firstOperand, this.secondOperand};
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
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public override string[] InputTexts => new string[2] {"A", "B"};

        protected override Control GenerateEditorRepresentation()
        {
            Control repr = new Button();
            switch (operationType)
            {
                case OperationType.Equals:
                    repr.Text = "A = B";
                    break;
                case OperationType.GreaterThan:
                    repr.Text = "A > B";
                    break;
                case OperationType.LessThan:
                    repr.Text = "A < B";
                    break;
                default:
                    repr.Text = "A ??? B";
                    break;
            }
            repr.Font = Data.DefaultRepresentationFont;
            repr.Enabled = false;

            return repr;
        }
    }
}
