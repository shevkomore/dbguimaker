using dbguimaker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI.Components
{
    public class LabelBuilder: ITableViewBuilder
    {
        public IDictionary<string, TableColumn> Fields 
        { 
            get
            {
                var res = new Dictionary<string, TableColumn>();
                res["Text"] = new TableColumn("", "", true);
                return res;
            }
        }

        public Control Build(IEnumerable<KeyValuePair<TableColumn, object>> row)
        {
            var res = new System.Windows.Forms.Label();
            res.Text = row.First(o => o.Key.Equals(Fields["Text"])).ToString();
            res.Font = ControlGenerationSettings.Instance.DefaultFont;
            return res;
        }
    }
}
