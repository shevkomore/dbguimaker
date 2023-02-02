using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.Serialization
{
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
    public partial class DatabaseGUITextArea : DatabaseGUIViewElement
    {
        [ProtoMember(1)]
        public string text;
        [ProtoMember(2)]
        public DatabaseGUITextOperation data;
    }
    [ProtoContract]
    public partial class DatabaseGUILabel : DatabaseGUIViewElement
    {
        [ProtoMember(1)]
        public string formatableText;
        [ProtoMember(2)]
        public DatabaseGUITextOperation data;
    }
    [ProtoContract]
    public partial class DatabaseGUICheckBox : DatabaseGUIViewElement
    {
        [ProtoMember(1)]
        public string text;
        [ProtoMember(2)]
        public DatabaseGUIBoolOperation data;
    }
    [ProtoContract]
    [ProtoInclude(1, typeof(DatabaseGUITextOperation))]
    [ProtoInclude(2, typeof(DatabaseGUIBoolOperation))]
    [ProtoInclude(3, typeof(DatabaseGUIIntOperation))]
    public partial class DatabaseGUIOperation
    { }
    [ProtoContract]
    [ProtoInclude(1, typeof(DatabaseGUITextInput))]
    [ProtoInclude(2, typeof(DatabaseGUITextConstant))]
    public partial class DatabaseGUITextOperation : DatabaseGUIOperation
    { }
    [ProtoContract]
    [ProtoInclude(1, typeof(DatabaseGUIBoolInput))]
    [ProtoInclude(2, typeof(DatabaseGUIBoolConstant))]
    [ProtoInclude(3, typeof(DatabaseGUIIntComparison))]
    public partial class DatabaseGUIBoolOperation : DatabaseGUIOperation
    { }
    [ProtoContract]
    [ProtoInclude(1, typeof(DatabaseGUIIntInput))]
    [ProtoInclude(2, typeof(DatabaseGUIIntConstant))]
    public partial class DatabaseGUIIntOperation : DatabaseGUIOperation
    { }
    [ProtoContract]
    public partial class DatabaseGUIIntComparison : DatabaseGUIBoolOperation
    {
        [ProtoMember(1)]
        public OperationType operationType;
        [ProtoMember(2)]
        public DatabaseGUIIntOperation firstOperand;
        [ProtoMember(3)]
        public DatabaseGUIIntOperation secondOperand;
    }
    [ProtoContract]
    public partial class DatabaseGUITextInput : DatabaseGUITextOperation
    {
        [ProtoMember(1)]
        public DatabaseConnection.TableColumn column;
    }
    [ProtoContract]
    public partial class DatabaseGUIBoolInput : DatabaseGUIBoolOperation
    {
        [ProtoMember(1)]
        public DatabaseConnection.TableColumn column;
    }
    [ProtoContract]
    public partial class DatabaseGUIIntInput : DatabaseGUIIntOperation
    {
        [ProtoMember(1)]
        public DatabaseConnection.TableColumn column;
    }
    [ProtoContract]
    public partial class DatabaseGUITextConstant : DatabaseGUITextOperation
    {
        [ProtoMember(1)]
        public string value;
    }
    [ProtoContract]
    public partial class DatabaseGUIIntConstant : DatabaseGUIIntOperation
    {
        [ProtoMember(1)]
        public int value;
    }
    [ProtoContract]
    public partial class DatabaseGUIBoolConstant : DatabaseGUIBoolOperation
    {
        [ProtoMember(1)]
        public bool value;
    }
}
