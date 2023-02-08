using System.Collections.Generic;

namespace dbguimaker.DatabaseGUI
{
    public partial class Input
    {
        public Input() { }
        public Input(TableColumn data)
        {
            this.column = data;
        }
    }
}
