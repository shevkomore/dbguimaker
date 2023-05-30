using dbguimaker.data;
using dbguimaker.DatabaseGUI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI
{
    public class DatabaseGUI
    {
        public OperationTable Operations { get; set; }
        public List<ITableViewBuilder> Views { get; set; } = new List<ITableViewBuilder>();
        public TableColumn GetOperationResultColumn(int operation_index)
        {
            return Operations.ResultingColumns[operation_index];
        }
    }
}
