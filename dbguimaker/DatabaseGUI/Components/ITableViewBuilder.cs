using dbguimaker.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Components
{
    public interface ITableViewBuilder
    {
        IDictionary<string, TableColumn> Fields { get; }
        System.Windows.Forms.Control Build(IEnumerable<KeyValuePair<TableColumn, object>> row);
    }
}
