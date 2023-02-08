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
        public string tableRequest;
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
    public partial class Operation
    { }
    /*
     * ViewComponents
     */
    [ProtoContract]
    public partial class TextArea : ViewComponent
    {
        [ProtoMember(1)]
        public Operation label;
        [ProtoMember(2)]
        public Operation data;
    }
    [ProtoContract]
    public partial class Label : ViewComponent
    {
        [ProtoMember(1)]
        public Operation text;
    }
    [ProtoContract]
    public partial class CheckBox : ViewComponent
    {
        [ProtoMember(1)]
        public Operation label;
        [ProtoMember(2)]
        public Operation data;
    }
    /*
     * Operations:
     */
    /*
     * Generating
     */
    [ProtoContract]
    public partial class Input : Operation
    {
        [ProtoMember(1)]
        public TableColumn column;
    }
    [ProtoContract]
    public partial class Constant : Operation
    {
        [ProtoMember(1)]
        public string value;
    }
    /*
     * Transforming
     */
    [ProtoContract]
    public partial class Comparison : Operation
    {
        [ProtoMember(1)]
        public OperationType operationType;
        [ProtoMember(2)]
        public Operation firstOperand;
        [ProtoMember(3)]
        public Operation secondOperand;
    }
}
