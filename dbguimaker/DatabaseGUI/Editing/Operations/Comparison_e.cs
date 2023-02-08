
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class Comparison
    {
        public override Operation[] Inputs => new Operation[2] {this.firstOperand, this.secondOperand};

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

            return repr;
        }
    }
}
