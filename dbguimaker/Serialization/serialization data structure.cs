using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker
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
        public DatabaseGUITextInput data;
    }
    [ProtoContract]
    public partial class DatabaseGUILabel : DatabaseGUIViewElement
    {
        [ProtoMember(1)]
        public string formatableText;
        [ProtoMember(2)]
        public DatabaseGUITextInput data;
    }
    [ProtoContract]
    public partial class DatabaseGUICheckBox : DatabaseGUIViewElement
    {
        [ProtoMember(1)]
        public string text;
        [ProtoMember(2)]
        public DatabaseGUIBoolInput data;
    }
    [ProtoContract]
    [ProtoInclude(2, typeof(DatabaseGUITextInput))]
    [ProtoInclude(3, typeof(DatabaseGUIBoolInput))]
    public partial class DatabaseGUIInput
    {
        [ProtoMember(1)]
        public DatabaseConnection.TableColumn column;
    }
    [ProtoContract]
    public partial class DatabaseGUITextInput : DatabaseGUIInput
    { }
    [ProtoContract]
    public partial class DatabaseGUIBoolInput : DatabaseGUIInput
    { }
}
