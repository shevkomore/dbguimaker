using ProtoBuf;
using System.Collections.Generic;

namespace dbguimaker.DatabaseGUI
{
    /*
     * General classes
     */
    [ProtoContract]
    public partial class Data
    {
        [ProtoMember(1)]
        public string databasePath;
        [ProtoMember(2)]
        public List<View> views;
    }
    [ProtoContract]
    public partial class View
    {
        [ProtoMember(1)]
        public string tableName;
        [ProtoMember(2)]
        public List<ViewComponent> elements;
    }
    [ProtoContract]
    [ProtoInclude(1, typeof(TextArea))]
    [ProtoInclude(2, typeof(Label))]
    [ProtoInclude(3, typeof(CheckBox))]
    public partial class ViewComponent
    { }
    [ProtoContract]
    [ProtoInclude(1, typeof(Constant))]
    [ProtoInclude(2, typeof(Input))]
    [ProtoInclude(3, typeof(Comparison))]
    [ProtoInclude(4, typeof(Sum))]
    [ProtoInclude(5, typeof(Condition))]
    public partial class IOperation
    { }
    /*
     * ViewComponents
     */
    [ProtoContract]
    public partial class TextArea : ViewComponent
    {
        [ProtoMember(1)]
        public IOperation label;
        [ProtoMember(2)]
        public IOperation data;
    }
    [ProtoContract]
    public partial class Label : ViewComponent
    {
        [ProtoMember(1)]
        public IOperation text;
    }
    [ProtoContract]
    public partial class CheckBox : ViewComponent
    {
        [ProtoMember(1)]
        public IOperation label;
        [ProtoMember(2)]
        public IOperation data;
    }
    /*
     * Operations:
     */
    /*
     * Generating
     */
    [ProtoContract]
    public partial class Input : IOperation
    {
        [ProtoMember(1)]
        public TableColumn column;
    }
    [ProtoContract]
    public partial class Constant : IOperation
    {
        [ProtoMember(1)]
        public string value;
    }
    /*
     * Transforming
     */
    [ProtoContract]
    public partial class Comparison : IOperation
    {
        [ProtoMember(1)]
        public OperationType operationType;
        [ProtoMember(2)]
        public IOperation firstOperand;
        [ProtoMember(3)]
        public IOperation secondOperand;
    }
    [ProtoContract]
    public partial class Sum : IOperation
    {
        [ProtoMember(1)]
        public IOperation firstOperand;
        [ProtoMember(2)]
        public IOperation secondOperand;
    }
    [ProtoContract]
    public partial class Condition : IOperation
    {
        [ProtoMember(1)]
        public IOperation Check;
        [ProtoMember(2)]
        public IOperation ifTrue;
        [ProtoMember(3)]
        public IOperation ifFalse;
    }
}
