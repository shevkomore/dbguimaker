using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Operations.Mementos
{
    public interface IOperationMemento
    {
        IOperation Restore();
    }
}
