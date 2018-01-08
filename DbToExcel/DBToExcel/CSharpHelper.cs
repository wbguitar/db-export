using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using S7.Net.Types;

namespace DBToExcel
{
    public class S7TypeConverter
    {
        class CSType
        {
            public string type { get; set; }
            public double bytes { get; set; }
            public string prefix { get; set; }
        }

        private static readonly Dictionary<string, Type> realTypes = new Dictionary<string, Type>()
        {
            {"bool", typeof(bool)},
            {"byte", typeof(byte)},
            {"short", typeof(short)},
            {"ushort", typeof(ushort)},
            {"int", typeof(int)},
            {"uint", typeof(uint)},
            {"double", typeof(double)},
            {"TimeSpan", typeof(TimeSpan)},
            {"DateTime", typeof(DateTime)}
        };

        private static readonly Dictionary<string, CSType> typeConverter = new Dictionary<string, CSType>()
        {
            {"BOOL", new CSType() {type = "bool", bytes = 1.0/.8, prefix = "DBX"}},
            {"CHAR", new CSType() {type = "byte", bytes = 1.0, prefix = "DBB"}},
            {"INT", new CSType() {type = "short", bytes = 2.0, prefix = "DBW"}},
            {"WORD", new CSType() {type = "ushort", bytes = 2.0, prefix = "DBW"}},
            {"DINT", new CSType() {type = "int", bytes = 4.0, prefix = "DBD"}},
            {"DWORD", new CSType() {type = "uint", bytes = 4.0, prefix = "DBD"}},
            {"REAL", new CSType() {type = "double", bytes = 4.0, prefix = "DBD"}},
            {"BYTE", new CSType() {type = "byte", bytes = 1.0, prefix = "DBB"}},
            {"TIME", new CSType() {type = "TimeSpan", bytes = 4.0, prefix = "DBD"}},
            {"TIME_OF_DAY", new CSType() {type = "TimeSpan", bytes = 4.0, prefix = "DBD"}},
            {"DATE_AND_TIME", new CSType() {type = "DateTime", bytes = 4.0, prefix = "DBD"}},
            {"DATE", new CSType() {type = "short", bytes = 2.0, prefix = "DBW"}},
            //{"", ""},
            //{"", ""},
            //{"", ""},
            //{"", ""},// = new
            //{"", ""},
            //{"", ""},
        };

        public string this[string s7type]
        {
            get { return GetCSType(s7type).type; }
        }

        public string Prefix(string s7type)
        {
            return GetCSType(s7type).prefix;
        }

        public double Bytes(string s7type)
        {
            return GetCSType(s7type).bytes;
        }

        private CSType GetCSType(string s7Type)
        {
            if (!typeConverter.ContainsKey(s7Type))
                throw new ArgumentException(string.Format("Type not found: {0}", s7Type));

            return typeConverter[s7Type];
        }

        public Type GetType(string cstype)
        {
            if (typeConverter.ContainsKey(cstype))
                cstype = typeConverter[cstype].type;
            return realTypes[cstype];
        }

        public string Address(string s7type, double bytes)
        {
            var cstype = typeConverter[s7type];
            var prefix = Prefix(s7type);
            //var bytesString = cstype.type == "bool" ? bytes.ToString() : ((int) bytes).ToString();
            var bytesString = ((int)bytes).ToString();
            if (cstype.type == "bool")
            {
                var intPart = (int) bytes;
                var decPart = bytes - intPart;

                decPart *= .8;
                bytesString = string.Format("{0}.{1}", intPart, (int)(decPart*10));// (intPart + decPart).ToString("N2");
            }

            return string.Format("{0} {1}", prefix, bytesString);
        }
    }

    public static class CSharpHelper
    {
        private const string TAB = "\t";
        private const string NAMESPACE = "S7Cyb";

        static S7TypeConverter typeConverter = new S7TypeConverter();

        static StringBuilder NamespaceWrap(string ns, StringBuilder sb, string tabs = "")
        {
            var sb1 = new StringBuilder();
            sb1.AppendFormat(@"namespace {0}
{{", ns);

            foreach (var line in sb.ToString().Split(new string [] { Environment.NewLine }, StringSplitOptions.None))
            {
                sb1.AppendFormat(@"{0}{1}
", tabs, line);
            }

            sb1.Append(@"
}");
            return sb1;
        }


        public static async Task<Dictionary<string, StringBuilder>> CreateCSharpAsync(IEnumerable<clsDb> items,
            Action<clsDb> onProgress = null)
        {
            //return Task < Dictionary<string, StringBuilder>>.Run(() => CreateCSharp(items, onProgress = null));
            return CreateCSharp(items, onProgress);
        }

        public static Dictionary<string, StringBuilder> CreateCSharp(IEnumerable<clsDb> items, Action<clsDb> onProgress = null)
        {
            //var items = lbxSelDbs.Items.Cast<clsDb>();
            if (items == null)
                return null;

            var dict = new Dictionary<string, StringBuilder>();

            var count = 0;
            foreach (var db in items)
            {
                try
                {
                    //Debug.WriteLine("DB{0} - {1} - {2}", db.Number, db.Symbol, db.SymbolComment);
                    var sb = new StringBuilder();

                    var className = db.Symbol.Replace(" ", "");
                    var comment = createComment(db, "");
                    sb.Append(comment);
                    sb.AppendFormat(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

[S7DB(DB = {1})]
public class {0}: DBBase // DB{1}
{{
", className, db.Number);
                    var tags = db.Tags.Cast<clsTag>();

                    var bytesCount = 0.0;
                    sb.Append(parseTags(tags, ref bytesCount));
                    sb.AppendFormat(@"
}}");

                    Debug.WriteLine(sb);
                    Debug.WriteLine("-------");

                    dict[string.Format("DB{0}_{1}", db.Number, className)] = NamespaceWrap(NAMESPACE, sb, TAB); //sb;

                    if (onProgress != null)
                        onProgress(db);
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }

            return dict;
        }

        static StringBuilder createComment(IComment tag, string tabs)
        {
            var sb = new StringBuilder();
            var comment = tag.Comment.Replace('\0', ' ');
            sb.AppendFormat("\r\n{0}/// <summary>\r\n", tabs);
            sb.AppendFormat(tabs + "/// {0}\r\n", comment);
            sb.AppendLine(tabs + "/// </summary>");
            return sb;
        }

        static StringBuilder parseTags(IEnumerable<clsTag> tags, ref double bytesCount, int nestCount = 1)
        {
            var tabs = Enumerable.Range(0, nestCount).Select(i => TAB).Aggregate("", (s1, s2) => s1 + s2);
            var sb = new StringBuilder();
            foreach (var tag in tags)
            {
                //Debug.WriteLine("TAB{0} {1} {{ get; set; }} // {2}", tag.DataType, tag.Name, tag.Comment);

                sb.Append(createComment(tag, tabs));

                //if (bytesCount != 0.0 && tag.DataType != "BOOL")
                //{
                //    Class.AdjustBytes(ref bytesCount);
                    
                //}
                

                if (tag.DataType.StartsWith("UDT") || tag.DataType.StartsWith("STRUCT"))
                {
                    Class.AdjustBytes(ref bytesCount);

                    //sb.Append(createComment(tag, tabs));
                    var className = "T_" + tag.Name;
                    sb.AppendFormat("{0}public class {1}", tabs, className);
                    var innerTags = parseTags(tag.Tags.Cast<clsTag>(), ref bytesCount, nestCount + 1);
                    sb.AppendLine(tabs + "{");
                    sb.Append(innerTags);
                    sb.AppendLine("\r\n" + tabs + "}");

                    sb.AppendFormat(@"
{0}public {1} {2} {{ get; set; }}", tabs, className, tag.Name);

                    Class.AdjustBytes(ref bytesCount);

                }
                else if (tag.DataType.StartsWith("ARRAY"))
                {
                    Class.AdjustBytes(ref bytesCount);

                    int count = 0;
                    string @type = "";

                    var m = Regex.Match(tag.DataType, @"ARRAY\s.\[(\d*) \.* (\d*) \] OF (\w*)");
                    if (m.Success)
                    {
                        var from = int.Parse(m.Groups[1].Value);
                        var to = int.Parse(m.Groups[2].Value);
                        count = to - from + 1;
                        @type = m.Groups[3].Value;
                    }
                    else
                    {
                        count = tag.Tags.Count;
                        @type = (tag.Tags[1] as clsTag).DataType;
                    }


                    sb.AppendFormat(@"
{0}protected {1} [] __{2} = new {1}[{3}];
{0}[S7Array(Count = {3})]
{0}[S7Tag( Address = ""{4}"" )]
{0}public {1} [] {2} {{ get {{ return __{2}; }} set {{ __{2} = value; }} }} // = new {1}[{3}];\r\n", tabs,
                        typeConverter[@type], tag.Name, count, typeConverter.Address(@type, bytesCount));

                    //bytesCount += count * typeConverter.Bytes(@type);

                    for (int i = 0; i < count; i++)
                    {
                        bytesCount = Class.GetIncreasedNumberOfBytes(bytesCount, typeConverter.GetType(@type));
                    }
                }
                else if (tag.DataType.StartsWith("STRING"))
                {
                    Class.AdjustBytes(ref bytesCount);

                    var m = Regex.Match(tag.DataType, @"STRING\s*\[\s*(\d*)\s*\]");
                    if (!m.Success)
                        throw new InvalidOperationException(string.Format("Unable to parse data type value: {0}", tag.DataType));
                    var length = Int32.Parse(m.Groups[1].Value);
                    

                    sb.AppendFormat(@"
{0}[S7Array(Count = {2})]
{0}[S7Tag( Address = ""{3}"" )]
{0}public string {1} {{ get; set; }}

", tabs, tag.Name, length, typeConverter.Address("CHAR", bytesCount));


                    //sb.AppendFormat(tabs + "[S7Tag( Address = {0} {1})]\r\n", typeConverter.Prefix(tag.DataType), bytesCount);
                    //sb.AppendFormat(tabs + "[S7Tag( Address = \"{0}\" )]\r\n", typeConverter.Address("CHAR", bytesCount));
                    bytesCount += length + 2;
                }
                else
                {
                    var type = typeConverter[tag.DataType];
                    //var prefix = typeConverter.Prefix(tag.DataType);
                    //var bytes = typeConverter.Bytes(tag.DataType);
                    //if (type == "bool")
                    //    bytes *= .8;

                    sb.AppendFormat(tabs + "[S7Tag( Address = \"{0}\" )]\r\n", typeConverter.Address(tag.DataType, bytesCount));
                    sb.AppendFormat(tabs + "public {0} {1} {{ get; set; }}\r\n\r\n", type, tag.Name);

                    bytesCount = Class.GetIncreasedNumberOfBytes(bytesCount, typeConverter.GetType(type));
                }

                //if (tag.DataType == "CHAR" || tag.DataType == "BYTE")
                //    bytesCount--;
                
            }

            return sb;
        }
    }
}
