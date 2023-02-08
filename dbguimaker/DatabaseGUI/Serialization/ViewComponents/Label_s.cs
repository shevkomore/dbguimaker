using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class Label
    {
        public Label() { }
        public Label(Operation text)
        {
            this.text = text;
        }
    }
}