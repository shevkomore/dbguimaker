using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    /// <summary>
    /// Describes an object that contains all data for creating a database view
    /// </summary>
    public partial class Data
    {
        public Data() { }
        public Data(string database_name)
        {
            this.databasePath = database_name;
            this.views = new List<View>();
        }
    }
}