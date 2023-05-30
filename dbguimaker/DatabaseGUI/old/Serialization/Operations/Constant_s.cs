using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace dbguimaker.DatabaseGUI
{
    public partial class Constant
    {
        public static Constant Default = new Constant("");
        public Constant() { }
        public Constant(object value)
        {
            this.value = TableColumn.CastToString(value);
        }

    }
}
