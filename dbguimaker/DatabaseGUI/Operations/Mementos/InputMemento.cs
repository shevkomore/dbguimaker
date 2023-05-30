using dbguimaker.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI.Operations.Mementos
{
    public class InputMemento:IOperationMemento
    {
        public TableColumn Input;
        public InputMemento(TableColumn input)
        {
            this.Input = input;
        }

        public IOperation Restore()
        {
            return new Input(Input);
        }
    }
}
