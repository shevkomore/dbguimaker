using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class CheckBox
    {
        public CheckBox() { }
        public CheckBox(Operation label, Operation data)
        {
            this.label = label;
            this.data = data;
        }
    }
}