using dbguimaker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Operations
{
    public class Constant: IOperation
    {
        public static Constant Default = new Constant("");

        string value;

        public Constant(string value)
        {
            this.value = value;
        }
        public object Value { 
            get { return value; } 
            set { this.value = TableColumn.CastToString(value); } 
        }

        public T Accept<T>(IOperationVisitor<T> visitor)
        {
            return visitor.VisitConstant(this);
        }

        public object Apply(Dictionary<TableColumn, object> row)
        {
            return value;
        }
    }
}
