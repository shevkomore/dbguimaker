using dbguimaker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Operations
{
    public class Input : IOperation
    {
        private TableColumn requiredColumn;
        public Input(TableColumn requiredColumn)
        {
            this.requiredColumn = requiredColumn;
        }
        public TableColumn RequiredColumn { 
            get { return requiredColumn; }
            set { requiredColumn = value; }
        }
        public object Apply(Dictionary<TableColumn, object> row)
        {
            return row[requiredColumn];
        }
        T IOperation.Accept<T>(IOperationVisitor<T> visitor)
        {
            return visitor.VisitInput(this);
        }
    }
}
