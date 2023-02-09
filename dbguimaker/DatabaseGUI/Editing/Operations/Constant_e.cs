
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class Constant
    {
        public override Operation[] Inputs => new Operation[0];

        public override string[] InputTexts => new string[0];

        protected override Control GenerateEditorRepresentation()
        {
            Button repr = new Button();

            repr.AutoSize = true;
            repr.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            repr.Text = "\""+value+"\"";
            repr.Font = Data.DefaultRepresentationFont;
            repr.Enabled = false;

            return repr;
        }
    }
}
