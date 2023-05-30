using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class TextArea
    {
        public TextArea() { }
        public TextArea(IOperation text, IOperation data)
        {
            this.label = text;
            this.data = data;
        }
        public override void FinalizeDeserialization()
        {
            if (label == null) label = Constant.Default;
            if (data == null) data = Constant.Default;
            label.FinalizeDeserialization();
            data.FinalizeDeserialization();
        }
    }
}