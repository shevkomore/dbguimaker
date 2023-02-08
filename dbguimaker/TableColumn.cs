using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace dbguimaker
{
        [ProtoBuf.ProtoContract]
        public class TableColumn
        {
            [ProtoBuf.ProtoMember(1)]
            string name;
            public string Name { get { return name; } }
            [ProtoBuf.ProtoMember(2)]
            string type;
            public string RawType { get { return type; } }
            public Type Type { get
                {
                    switch (type)
                    {
                        case "INTEGER":
                            return typeof(int);
                        case "REAL":
                            return typeof(double);
                        case "TEXT":
                            return typeof(string);
                        case "BLOB":
                            return typeof(object);
                        default:
                            //if(type.StartsWith("NVARCHAR"))
                                return typeof(string);
                            //throw new FormatException("Cannot convert SQLite type \"" + type + "\" to c# type");
                    }
                } }
            [ProtoBuf.ProtoMember(3)]
            bool notNull;
            public bool NotNull { get { return notNull; } }
            public TableColumn() { }
            public TableColumn(string name, string type, bool not_null = false)
            {
                this.name = name;
                this.type = type;
                this.notNull = not_null;
            }
            public TableColumn(SQLiteDataReader r)
            {
                this.name = r.GetString(1);
                this.type = r.GetString(2);
                this.notNull = r.GetBoolean(3);
            }

            public static string CastToString(object data)
            {
                if (data == null) return "null";
                return data.ToString();
            }
            public static int CastToInt(object data)
            {
                if(data == null) return 0;
                if(data is string)
                {
                    try
                    {
                        return int.Parse((string)data);
                    } catch (FormatException)
                    {
                        return data.GetHashCode();
                    }
                }
                return data.GetHashCode();
            }
            public static bool CastToBool(object data)
            {
                if (data is bool) 
                    return (bool)data;
                if (data is int)
                    return (int)data > 0;
                if (data is string)
                    return ((string)data).Trim().Length > 0;
                return data != null;
            }
            /*
             * Object overrides
             */
            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is TableColumn)) return false;
                TableColumn other = obj as TableColumn;
                return other.Type == this.Type & other.Name == this.Name & other.NotNull == this.NotNull;
            }
            public override string ToString()
            {
                return name;
            }

            public override int GetHashCode()
            {
                int hashCode = 613504982;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RawType);
                hashCode = hashCode * -1521134295 + NotNull.GetHashCode();
                return hashCode;
            }
        }
}
