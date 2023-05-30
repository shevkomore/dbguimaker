using dbguimaker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI
{
    public interface IOperation
    {
        object Apply(Dictionary<TableColumn, object> row);
        T Accept<T>(IOperationVisitor<T> visitor);
    }
}
