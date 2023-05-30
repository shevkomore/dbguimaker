using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI
{
    interface IOperationFactory
    {
        IOperation create();
    }
}
