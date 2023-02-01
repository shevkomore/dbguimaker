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
    public partial class DatabaseGUIViewElement
    {
        [ProtoMember(1)]
        public string text;
        [ProtoMember(2)]
        public DatabaseGUIInput data;
    }
    [ProtoContract]
    public partial class DatabaseGUIInput
    {
        [ProtoMember(1)]
        public DatabaseConnection.TableColumn column;
    }
}
