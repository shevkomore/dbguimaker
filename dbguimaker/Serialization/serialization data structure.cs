using ProtoBuf;
using System.Collections.Generic;

namespace dbguimaker.Serialization
{
    /*
     * General classes
     */
    [ProtoContract]
    public partial class DatabaseGUIData
    {
        [ProtoMember(1)]
        public string databasePath;
        [ProtoMember(2)]
        public List<DatabaseGUIView> views;
    }
    [ProtoContract]
    public partial class DatabaseGUIView
    {
        [ProtoMember(1)]
        public string tableName;
        [ProtoMember(2)]
        public List<DatabaseGUIViewElement> elements;
    }
    [ProtoContract]
    [ProtoInclude(1, typeof(DatabaseGUITextArea))]
    [ProtoInclude(2, typeof(DatabaseGUILabel))]
    [ProtoInclude(3, typeof(DatabaseGUICheckBox))]
    public partial class DatabaseGUIViewElement
    { }
    [ProtoContract]
    [ProtoInclude(1, typeof(DatabaseGUIConstant))]
    [ProtoInclude(2, typeof(DatabaseGUIInput))]
    [ProtoInclude(3, typeof(DatabaseGUIComparison))]
    public partial class DatabaseGUIOperation
    {
    }
    /*
     * ViewElements
     */
    [ProtoContract]
    public partial class DatabaseGUITextArea : DatabaseGUIViewElement
    {
        [ProtoMember(1)]
        public DatabaseGUIOperation label;
        [ProtoMember(2)]
        public DatabaseGUIOperation data;
    }
    [ProtoContract]
    public partial class DatabaseGUILabel : DatabaseGUIViewElement
    {
        [ProtoMember(1)]
        public DatabaseGUIOperation text;
    }
    [ProtoContract]
    public partial class DatabaseGUICheckBox : DatabaseGUIViewElement
    {
        [ProtoMember(1)]
        public DatabaseGUIOperation label;
        [ProtoMember(2)]
        public DatabaseGUIOperation data;
    }
    /*
     * Operations:
     */
    /*
     * Transforming Operations
     */
    [ProtoContract]
    public partial class DatabaseGUIComparison : DatabaseGUIOperation
    {
        [ProtoMember(1)]
        public OperationType operationType;
        [ProtoMember(2)]
        public DatabaseGUIOperation firstOperand;
        [ProtoMember(3)]
        public DatabaseGUIOperation secondOperand;
    }
    /*
     * Inputs (receive data from database)
     */
    [ProtoContract]
    public partial class DatabaseGUIInput : DatabaseGUIOperation
    {
        [ProtoMember(1)]
        public TableColumn column;
    }
    /*
     * Constants
     */
    [ProtoContract]
    public partial class DatabaseGUIConstant : DatabaseGUIOperation
    {
        [ProtoMember(1)]
        public string value;
    }
}
