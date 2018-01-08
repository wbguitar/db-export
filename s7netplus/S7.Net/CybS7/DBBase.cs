using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using S7.Net;
using S7.Net.Types;

namespace S7Cyb
{
    public static class Utils
    {
        /// <summary>
        /// Gets DateTime value from short
        /// </summary>
        /// <remarks>In S7 Date type represents number of days from 1990/1/1</remarks>
        /// <param name="s7Date">S7 Date value as short</param>
        /// <returns>The calculated date time</returns>
        public static DateTime GetDate(this short s7Date)
        {
            return DateTime.Parse("1990-1-1") + TimeSpan.FromDays(s7Date);
        }

        public static bool Write<T>(this T db, string propertyName, Plc plc) where T : DBBase
        {
            var property = typeof(T).GetProperty(propertyName);
            if (property == null)
                return false;

            var att = typeof(T).GetCustomAttributes(typeof(S7DBAttribute)).FirstOrDefault() as S7DBAttribute;

            var props = typeof(T).GetProperties();
            var count = 0.0;
            foreach (var prop in props)
            {
                if (prop.Name == propertyName)
                {
                    var val = prop.GetValue(db);
                    var err = plc.Write(DataType.DataBlock, att.DB, (int)count, val);
                    return err == ErrorCode.NoError;
                }
                count += Class.GetClassSize(Activator.CreateInstance(prop.PropertyType));

            }

            Debug.Assert(false); // if the propertyName is correct we shouldn't be here!!
            return false;
        }
    }

    /// <summary>
    /// Base class representing a basic Step 7 DB
    /// </summary>
    /// <remarks>Dummy class, used only for reflection purpose</remarks>
    public class DBBase
    {
    }

    /// <summary>
    /// Used to specify the number of DB related to a DB class
    /// </summary>
    public class S7DBAttribute : System.Attribute
    {
        public int DB { get; set; }
        
    }

    /// <summary>
    /// Used in an array property to specify the array dimension
    /// </summary>
    public class S7ArrayAttribute : System.Attribute
    {
        public int Count { get; set; }
    }

    public class S7TagAttribute : Attribute
    {
        public int Address { get; set; }
    }
}