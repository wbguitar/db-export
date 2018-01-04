using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DBToExcel
{
    public static class CSharpHelper
    {
        private const string TAB = "\t";
        private const string NAMESPACE = "S7Cyb";

        static readonly Dictionary<string, string> typeConverter = new Dictionary<string, string>()
        {
            {"BOOL", "bool"},
            {"INT", "short"},
            {"DINT", "int"},
            {"WORD", "ushort"},
            {"DWORD", "uint"},
            {"REAL", "double"},
            {"BYTE", "byte"},
            {"CHAR", "byte"},
            {"TIME", "TimeSpan"},
            {"TIME_OF_DAY", "TimeSpan"},
            {"DATE_AND_TIME", "DateTime"},
            {"DATE", "short"},
            //{"", ""},
            //{"", ""},
            //{"", ""},
            //{"", ""},// = new
            //{"", ""},
            //{"", ""},
        };


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

//            dict["DBBase"] = new StringBuilder(@"
//using System;
//
//public static class Utils
//{
//    /// <summary>
//    /// Gets DateTime value from short
//    /// </summary>
//    /// <remarks>In S7 Date type represents number of days from 1990/1/1</remarks>
//    /// <param name=""s7Date"">S7 Date value as short</param>
//    /// <returns>The calculated date time</returns>
//    public static DateTime GetDate(this short s7Date)
//    {
//        return DateTime.Parse(""1990-1-1"") + TimeSpan.FromDays(s7Date);
//    }
//}
//
///// <summary>
///// Base class representing a basic Step 7 DB
///// </summary>
///// <remarks>Dummy class, used only for reflection purpose</remarks>
//public class DBBase
//{
//}
//
///// <summary>
///// Used to specify the number of DB related to a DB class
///// </summary>
//public class S7DBAttribute : System.Attribute
//{
//    public int DB { get; set; }
//}
//
///// <summary>
///// Used in an array property to specify the array dimension
///// </summary>
//public class S7ArrayAttribute : System.Attribute
//{
//    public int Count { get; set; }
//}
//");

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

[S7DB(DB = {1})]
public class {0}: DBBase // DB{1}
{{
", className, db.Number);
                    var tags = db.Tags.Cast<clsTag>();
                    sb.Append(parseTags(tags));
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

        static StringBuilder parseTags(IEnumerable<clsTag> tags, int nestCount = 1)
        {
            var tabs = Enumerable.Range(0, nestCount).Select(i => TAB).Aggregate("", (s1, s2) => s1 + s2);
            var sb = new StringBuilder();
            foreach (var tag in tags)
            {
                //Debug.WriteLine("TAB{0} {1} {{ get; set; }} // {2}", tag.DataType, tag.Name, tag.Comment);

                sb.Append(createComment(tag, tabs));
                if (tag.DataType.StartsWith("UDT") || tag.DataType.StartsWith("STRUCT"))
                {
                    //sb.Append(createComment(tag, tabs));
                    var className = "T_" + tag.Name;
                    sb.AppendFormat("{0}public class {1}", tabs, className);
                    var innerTags = parseTags(tag.Tags.Cast<clsTag>(), nestCount + 1);
                    sb.AppendLine(tabs + "{");
                    sb.Append(innerTags);
                    sb.AppendLine("\r\n" + tabs + "}");
                    sb.AppendFormat(@"
{0}public {1} {2} {{ get; set; }}", tabs, className, tag.Name);
                }
                else if (tag.DataType.StartsWith("ARRAY"))
                {
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

                    //sb.Append(createComment(tag, tabs));
                    if (!typeConverter.ContainsKey(@type))
                        throw new Exception(string.Format("Type not found: {0}", @type));

                    //sb.AppendFormat("{0}[S7Array(Count = {1})]\r\n", tabs, count);
                    sb.AppendFormat(@"
{0}protected {1} [] __{2} = new {1}[{3}];
{0}[S7Array(Count = {3})]
{0}public {1} [] {2} {{ get {{ return __{2}; }} set {{ __{2} = value; }} }} // = new {1}[{3}];\r\n", tabs, typeConverter[@type], tag.Name, count);
                }
                else if (tag.DataType.StartsWith("STRING"))
                {
                    var m = Regex.Match(tag.DataType, @"STRING\s*\[\s*(\d*)\s*\]");
                    if (!m.Success)
                        throw new InvalidOperationException(string.Format("Unable to parse data type value: {0}", tag.DataType));
                    var lenght = Int32.Parse(m.Groups[1].Value);

                    //sb.Append(createComment(tag, tabs));
                    //sb.AppendFormat(tabs + "public string {0} {{ get; set; }}\r\n\r\n", tag.Name);
                    sb.AppendFormat(@"
{0}[S7Array(Count = {2})]
{0}public string {1} {{ get; set; }}

", tabs, tag.Name, lenght);


                }
                else
                {
                    if (!typeConverter.ContainsKey(tag.DataType))
                        throw new Exception(string.Format("Type not found: {0}", tag.DataType));

                    //sb.Append(createComment(tag, tabs));
                    sb.AppendFormat(tabs + "public {0} {1} {{ get; set; }}\r\n\r\n", typeConverter[tag.DataType], tag.Name);
                }
            }

            return sb;
        }
    }
}
