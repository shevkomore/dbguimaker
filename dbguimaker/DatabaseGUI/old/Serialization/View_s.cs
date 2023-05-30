using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    /// <summary>
    /// Describes a view of one table
    /// </summary>
    public partial class View
    {
        public View() { }
        public View(string table_name)
        {
            this.tableName = table_name;
            this.elements = new List<ViewComponent>();
        }
        public void FinalizeDeserialization()
        {
            foreach (ViewComponent component in this.elements)
                component.FinalizeDeserialization();
        }
    }
}