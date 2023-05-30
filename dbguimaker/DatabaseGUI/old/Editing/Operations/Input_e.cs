using System;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class Input
    {
        public override IOperation[] Inputs => new IOperation[0];
        public override void SetInput(int index, IOperation operation)
        {
            throw new IndexOutOfRangeException();
        }

        public override string[] InputTexts => new string[0];

        protected override Control GenerateEditorRepresentation()
        {
            Button repr = new Button();

            repr.AutoSize = true;
            repr.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            repr.Text = "Get value of "+column.Name;
            repr.Font = Data.DefaultRepresentationFont;
            repr.Enabled = false;

            return repr;
        }
    }
}
