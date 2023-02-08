using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class TextArea
    {
        public TextArea() { }
        public TextArea(Operation text, Operation data)
        {
            this.label = text;
            this.data = data;
        }
    }
}