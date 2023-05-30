using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class CheckBox
    {
        public CheckBox() { }
        public CheckBox(IOperation label, IOperation data)
        {
            this.label = label;
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