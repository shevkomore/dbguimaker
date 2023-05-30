using dbguimaker.data;
using dbguimaker.DatabaseGUI.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI.Components
{
    internal class CheckBoxBuilder : ITableViewBuilder
    {
        public IDictionary<string, TableColumn> Fields
        {
            get
            {
                var res = new Dictionary<string, TableColumn>();
                res["Text"] = new TableColumn("", "", true);
                res["Checked"] = new TableColumn("", "", true);
                return res;
            }
        }

        public Control Build(IEnumerable<KeyValuePair<TableColumn, object>> row)
        {
            System.Windows.Forms.CheckBox checkbox = new System.Windows.Forms.CheckBox();
            checkbox.AutoSize = true;
            checkbox.Text = row.First(o => o.Key.Equals(Fields["Text"])).ToString(); ;
            checkbox.Font = ControlGenerationSettings.Instance.DefaultFont;
            checkbox.Checked = TableColumn.CastToBool(row.First(o => o.Key.Equals(Fields["Checked"])));
            checkbox.Enabled = false;
            return checkbox;
        }
    }
}
