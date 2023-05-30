using dbguimaker.DatabaseGUI.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Factories
{
    internal class ConstantFactory : IOperationFactory
    {
        public IOperation create()
        {
            return new Constant("");
        }
    }
}
