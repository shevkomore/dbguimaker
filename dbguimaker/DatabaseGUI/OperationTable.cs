using dbguimaker.data;
using dbguimaker.DatabaseGUI.Operations;
using dbguimaker.DatabaseGUI.Operations.Mementos;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.DatabaseGUI
{
    public class OperationTable : TableDecorator
    {
        public List<IOperation> RootOperations { get; set; }
        public List<TableColumn> ResultingColumns
        {
            get
            {
                var res = new List<TableColumn>();
                for (int i = 0; i < RootOperations.Count; i++)
                    res.Add(new TableColumn(i.ToString(), "BLOB", true));
                return res;
            }
        }
        public OperationTable(ITable table): base(table)
        {
            RootOperations = new List<IOperation>();
        }
        public override IList<TableColumn> Columns
        {
            get 
            {
                List<TableColumn> columns = new List<TableColumn>();
                RootOperations.ForEach(o => o.Accept(new TreeTraverser(ref columns)));
                return columns;
            }
        }

        public bool IsCompatibleWith(ITable table)
        {
            return Columns.All(table.Columns.Contains);
        }

        public new IEnumerable<KeyValuePair<TableColumn, object>> Next()
        {
            var received = base.Next();
            var res = new List<KeyValuePair<TableColumn, object>>();
            for (int i = 0; i < RootOperations.Count; ++i)
            {
                res.Add(new KeyValuePair<TableColumn, object>(
                new TableColumn(i.ToString(), "BLOB", true),
                    RootOperations[i].Apply(received.ToDictionary(o => o.Key, o => o.Value)))
                    );
            }
            return res;
        }

        class TreeTraverser : IOperationVisitor<object>
        {
            public List<TableColumn> CollectedColumns { get; set; }
            public TreeTraverser(ref List<TableColumn> collectedColumns)
            {
                this.CollectedColumns = collectedColumns;
            }
            public object VisitComparison(Comparison o)
            {
                o.LeftOperand.Accept(this);
                o.RightOperand.Accept(this);
                return null;
            }

            public object VisitCondition(Condition o)
            {
                o.Check.Accept(this);
                o.IfTrue.Accept(this);
                o.IfFalse.Accept(this);
                return null;
            }

            public object VisitConstant(Constant o)
            {

            }

            public object VisitSum(Sum o)
            {
                o.Operand1.Accept(this);
                o.Operand2.Accept(this);
                return null;
            }

            public object VisitInput(Input o)
            {
                if(!CollectedColumns.Contains(o.RequiredColumn))
                    CollectedColumns.Add(o.RequiredColumn);
                return null;
            }
        }

        class OperationMementoGenerator : IOperationVisitor<IOperationMemento>
        {
            public IOperationMemento VisitComparison(Comparison o)
            {
                return new ComparisonMemento(o.LeftOperand.Accept(this), o.RightOperand.Accept(this), o.Operation);
            }

            public IOperationMemento VisitCondition(Condition o)
            {
                return new ConditionMemento(o.Check.Accept(this), o.IfTrue.Accept(this), o.IfFalse.Accept(this));
            }

            public IOperationMemento VisitConstant(Constant o)
            {
                return new ConstantMemento(TableColumn.CastToString(o.Value));
            }

            public IOperationMemento VisitInput(Input o)
            {
                return new InputMemento(o.RequiredColumn);
            }

            public IOperationMemento VisitSum(Sum o)
            {
                return new SumMemento(o.Operand1.Accept(this), o.Operand2.Accept(this));
            }
        }
        public Copy Save()
        {
            var copy = new Copy();
            var gen = new OperationMementoGenerator();
            RootOperations.ForEach(o => copy.RootOperations.Add(o.Accept(gen)));
            return copy;
        }
        public void Load(Copy data)
        {
            RootOperations.Clear();
            data.RootOperations.ForEach(o => RootOperations.Add(o.Restore()));
        }
        public class Copy
        {
            public List<IOperationMemento> RootOperations;
        }
    }
}
