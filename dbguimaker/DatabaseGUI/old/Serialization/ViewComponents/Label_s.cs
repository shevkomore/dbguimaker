using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class Label
    {
        public Label() { }
        public Label(IOperation text)
        {
            this.text = text;
        }
        public override void FinalizeDeserialization()
        {
            if (text == null) text = Constant.Default;
            text.FinalizeDeserialization();
        }
    }
}