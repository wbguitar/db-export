using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using S7Cyb;

namespace S7.Net.Types
{
    /// <summary>
    /// Contains the methods to convert a C# class to S7 data types
    /// </summary>
    public static class Class
    {
        private static IEnumerable<PropertyInfo> GetAccessableProperties(Type classType)
        {
            return classType
#if NETFX_CORE
                .GetProperties().Where(p => p.GetSetMethod() != null);
#else
                .GetProperties(
                    BindingFlags.SetProperty |
                    BindingFlags.Public |
                    BindingFlags.Instance)
                .Where(p => p.GetSetMethod() != null);
#endif

        }

        private static double GetIncreasedNumberOfBytes(double startingNumberOfBytes, Type type)
        {
            double numBytes = startingNumberOfBytes;

            switch (type.Name)
            {
                case "Boolean":
                    numBytes += 0.125;
                    break;
                case "Byte":
                    numBytes = Math.Ceiling(numBytes);
                    numBytes++;
                    break;
                case "Int16":
                case "UInt16":
                    AdjustBytes(ref numBytes);
                    numBytes += 2;
                    break;
                case "Int32":
                case "UInt32":
                    AdjustBytes(ref numBytes);

                    numBytes += 4;
                    break;
                case "Float":
                case "Double":
                    AdjustBytes(ref numBytes);

                    numBytes += 4;
                    break;
                case "String":
                    throw new InvalidOperationException("For string we should not be here!!");
                default:
                   
                    var propertyClass = Activator.CreateInstance(type);
                    numBytes += GetClassSize(propertyClass);
                    break;
            }

            return numBytes;
        }

        /// <summary>
        /// Gets the size of the class in bytes.
        /// </summary>
        /// <param name="instance">An instance of the class</param>
        /// <returns>the number of bytes</returns>
        public static int GetClassSize(object instance)
        {
            if (instance is TimeSpan)
                return sizeof(int);
            if (instance is DateTime)
                return sizeof(long);
            if (instance is string)
                return ((string) instance).Length; // correct???

            double numBytes = 0.0;

            var properties = GetAccessableProperties(instance.GetType());
            foreach (var property in properties)
            {
                if (property.PropertyType.IsArray)
                {
                    Type elementType = property.PropertyType.GetElementType();
                    Array array = (Array)property.GetValue(instance, null);
                    if (array.Length <= 0)
                    {
                        throw new Exception("Cannot determine size of class, because an array is defined which has no fixed size greater than zero.");
                    }

                    for (int i = 0; i < array.Length; i++)
                    {
                        numBytes = GetIncreasedNumberOfBytes(numBytes, elementType);
                    }
                }
                else if (property.PropertyType == typeof(string))
                {
                    var att =
                        property.GetCustomAttributes(typeof(S7ArrayAttribute))
                            .FirstOrDefault() as S7ArrayAttribute;
                    if (att == null)
                        throw new InvalidOperationException("String properties should be marked with S7ArrayAttribute specifying string lenght!!");
                    numBytes += att.Count;
                }
                else if (property.PropertyType.IsClass)
                {
                    numBytes += GetClassSize(Activator.CreateInstance(property.PropertyType));
                    AdjustBytes(ref numBytes);
                }
                else
                {
                    numBytes = GetIncreasedNumberOfBytes(numBytes, property.PropertyType);
                }
            }
            return (int)Math.Ceiling(numBytes);
        }

        private static object GetPropertyValue(Type propertyType, byte[] bytes, ref double numBytes)
        {
            object value = null;

            switch (propertyType.Name)
            {
                case "Boolean":
                    // get the value
                    int bytePos = (int)Math.Floor(numBytes);
                    int bitPos = (int)((numBytes - (double)bytePos) / 0.125);
                    if ((bytes[bytePos] & (int)Math.Pow(2, bitPos)) != 0)
                        value = true;
                    else
                        value = false;
                    numBytes += 0.125;
                    break;
                case "Byte":
                    numBytes = Math.Ceiling(numBytes);
                    value = (byte)(bytes[(int)numBytes]);
                    numBytes++;
                    break;
                case "Int16":
                    AdjustBytes(ref numBytes);

                    // hier auswerten
                    ushort source = Word.FromBytes(bytes[(int)numBytes + 1], bytes[(int)numBytes]);
                    value = source.ConvertToShort();
                    numBytes += 2;
                    break;
                case "UInt16":
                    AdjustBytes(ref numBytes);

                    // hier auswerten
                    value = Word.FromBytes(bytes[(int)numBytes + 1], bytes[(int)numBytes]);
                    numBytes += 2;
                    break;
                case "Int32":
                    AdjustBytes(ref numBytes);

                    // hier auswerten
                    uint sourceUInt = DWord.FromBytes(bytes[(int)numBytes + 3],
                                                                       bytes[(int)numBytes + 2],
                                                                       bytes[(int)numBytes + 1],
                                                                       bytes[(int)numBytes + 0]);
                    value = sourceUInt.ConvertToInt();
                    numBytes += 4;
                    break;
                case "UInt32":
                    AdjustBytes(ref numBytes);

                    // hier auswerten
                    //value = DWord.FromBytes(
                    //    bytes[(int)numBytes],
                    //    bytes[(int)numBytes + 1],
                    //    bytes[(int)numBytes + 2],
                    //    bytes[(int)numBytes + 3]);
                    value = DWord.FromByteArray(bytes.Skip((int)numBytes).Take(4).ToArray());
                    numBytes += 4;
                    break;
                case "Double":
                    AdjustBytes(ref numBytes);

                    // hier auswerten
                    value = Double.FromByteArray(
                        new byte[] {
                            bytes[(int)numBytes],
                            bytes[(int)numBytes + 1],
                            bytes[(int)numBytes + 2],
                            bytes[(int)numBytes + 3] });
                    numBytes += 4;
                    break;

                case "TimeSpan":
                {
                    AdjustBytes(ref numBytes);

                    // hier auswerten
                    uint src = DWord.FromBytes(bytes[(int)numBytes + 3],
                        bytes[(int)numBytes + 2],
                        bytes[(int)numBytes + 1],
                        bytes[(int)numBytes + 0]);
                    value = TimeSpan.FromMilliseconds(src);
                    numBytes += 4;
                }
                    break;
                case "DateTime":
                {
                    AdjustBytes(ref numBytes);

                    // hier auswerten
                    //uint src = DWord.FromBytes(bytes[(int)numBytes + 3],
                    //    bytes[(int)numBytes + 2],
                    //    bytes[(int)numBytes + 1],
                    //    bytes[(int)numBytes + 0]);
                    var ticks = BitConverter.ToInt64(bytes.Skip((int)numBytes).Take(8).ToArray(), 0);
                    if (ticks < DateTime.MinValue.Ticks)
                        ticks = DateTime.MinValue.Ticks;
                    else if (ticks > DateTime.MaxValue.Ticks)
                        ticks = DateTime.MaxValue.Ticks;
                    value = new DateTime(ticks);
                    numBytes += 8;
                }
                    break;
                default:
                    var propClass = Activator.CreateInstance(propertyType);
                    var buffer = new byte[GetClassSize(propClass)];
                    if (buffer.Length > 0)
                    {
                        Buffer.BlockCopy(bytes, (int)Math.Ceiling(numBytes), buffer, 0, buffer.Length);
                        FromBytes(propClass, buffer);
                        value = propClass;
                        numBytes += buffer.Length;
                    }
                    break;
            }

            return value;
        }

        /// <summary>
        /// Sets the object's values with the given array of bytes
        /// </summary>
        /// <param name="sourceClass">The object to fill in the given array of bytes</param>
        /// <param name="bytes">The array of bytes</param>
        public static void FromBytes(object sourceClass, byte[] bytes)
        {
            if (bytes == null)
                return;

            
            if (bytes.Length != GetClassSize(sourceClass))
                return;

            // and decode it
            double numBytes = 0.0;

            var properties = GetAccessableProperties(sourceClass.GetType());
            foreach (var property in properties)
            {
                if (property.PropertyType.IsArray)
                {
                    Array array = (Array)property.GetValue(sourceClass, null);
                    Type elementType = property.PropertyType.GetElementType();
                    for (int i = 0; i < array.Length && numBytes < bytes.Length; i++)
                    {
                        array.SetValue(
                            GetPropertyValue(elementType, bytes, ref numBytes),
                            i);
                    }
                }
                else if (property.PropertyType == typeof(string))
                {
                    AdjustBytes(ref numBytes);

                    var att =
                        property.GetCustomAttributes(typeof(S7ArrayAttribute))
                            .FirstOrDefault() as S7ArrayAttribute;
                    
                    if (att == null)
                        throw new InvalidOperationException("String properties should be marked with S7ArrayAttribute specifying string lenght!!");

                    var bstr = bytes.Skip((int)numBytes).Take(att.Count).ToArray();
                    var val = S7.Net.Types.String.FromByteArray(bstr);
                    Debug.Assert(val.Length == att.Count);
                    property.SetValue(sourceClass, val, null);
                    numBytes += val.Length; // 1 char == 1 byte
                }
                else if (property.PropertyType.IsClass)
                {
                    AdjustBytes(ref numBytes);

                    property.SetValue(
                        sourceClass,
                        GetPropertyValue(property.PropertyType, bytes, ref numBytes),
                        null);
                }
                else
                {
                    property.SetValue(
                        sourceClass,
                        GetPropertyValue(property.PropertyType, bytes, ref numBytes),
                        null);
                }
            }
        }

        private static double AdjustBytes(ref double numBytes)
        {
            numBytes = Math.Ceiling(numBytes);
            if ((numBytes / 2 - Math.Floor(numBytes / 2.0)) > 0)
            {
                //numBytes = Math.Floor(numBytes + 1);
                numBytes++;
            }

            return numBytes;
        }

        private static void ToBytes(object propertyValue, byte[] bytes, ref double numBytes)
        {
            int bytePos = 0;
            int bitPos = 0;
            byte[] bytes2 = null;
            
            switch (propertyValue.GetType().Name)
            {
                case "Boolean":
                    // get the value
                    bytePos = (int)Math.Floor(numBytes);
                    bitPos = (int)((numBytes - (double)bytePos) / 0.125);
                    if ((bool)propertyValue)
                        bytes[bytePos] |= (byte)Math.Pow(2, bitPos);            // is true
                    else
                        bytes[bytePos] &= (byte)(~(byte)Math.Pow(2, bitPos));   // is false
                    numBytes += 0.125;
                    break;
                case "Byte":
                    numBytes = (int)Math.Ceiling(numBytes);
                    bytePos = (int)numBytes;
                    bytes[bytePos] = (byte)propertyValue;
                    numBytes++;
                    break;
                case "Int16":
                    bytes2 = Int.ToByteArray((Int16)propertyValue);
                    break;
                case "UInt16":
                    bytes2 = Word.ToByteArray((UInt16)propertyValue);
                    break;
                case "Int32":
                    bytes2 = DInt.ToByteArray((Int32)propertyValue);
                    break;
                case "UInt32":
                    bytes2 = DWord.ToByteArray((UInt32)propertyValue);
                    break;
                case "Double":
                    bytes2 = Double.ToByteArray((double)propertyValue);
                    break;

                case "TimeSpan":
                    bytes2 = DInt.ToByteArray((int)((TimeSpan) propertyValue).TotalMilliseconds);
                    break;

                case "DateTime":
                    bytes2 = BitConverter.GetBytes(((DateTime)propertyValue).Ticks);
                    break;

                case "String":
                {
                    var str = propertyValue as string;

                    bytes2 = S7.Net.Types.String.ToByteArray(str);
                }
                    
                    break;
                default:
                    bytes2 = ToBytes(propertyValue);
                    break;
            }

            if (bytes2 != null)
            {
                // add them
                bytePos = (int)AdjustBytes(ref numBytes);
                for (int bCnt = 0; bCnt < bytes2.Length; bCnt++)
                    bytes[bytePos + bCnt] = bytes2[bCnt];
                numBytes += bytes2.Length;
            }
        }

        /// <summary>
        /// Creates a byte array depending on the struct type.
        /// </summary>
        /// <param name="sourceClass">The struct object</param>
        /// <returns>A byte array or null if fails.</returns>
        public static byte[] ToBytes(object sourceClass)
        {
            if (sourceClass is TimeSpan)
            {
                return BitConverter.GetBytes((int)((TimeSpan) sourceClass).TotalMilliseconds);
            }

            if (sourceClass is DateTime)
            {
                return BitConverter.GetBytes(((DateTime) sourceClass).Ticks);
            }

            if (sourceClass is string)
            {
                return S7.Net.Types.String.ToByteArray(sourceClass as string);
            }


            int size = GetClassSize(sourceClass);
            byte[] bytes = new byte[size];
            double numBytes = 0.0;

            var properties = GetAccessableProperties(sourceClass.GetType());
            foreach (var property in properties)
            {
                if (property.PropertyType.IsArray)
                {
                    Array array = (Array)property.GetValue(sourceClass, null);
                    Type elementType = property.PropertyType.GetElementType();
                    for (int i = 0; i < array.Length && numBytes < bytes.Length; i++)
                    {
                        ToBytes(array.GetValue(i), bytes, ref numBytes);
                    }
                }
                else if (property.PropertyType == typeof(string))
                {
                    var sbytes = getBytes(property, sourceClass);
                    Array.Copy(sbytes, 0, bytes, (int)numBytes, (int)sbytes.Length);
                    numBytes += sbytes.Length;
                }
                else if (property.PropertyType.IsClass)
                {
                    var innerObj = property.GetValue(sourceClass, null);
                    ToBytes(innerObj, bytes, ref numBytes);
                }
                else
                {
                    ToBytes(property.GetValue(sourceClass, null), bytes, ref numBytes);
                }
            }
            return bytes;
        }

        static byte[] getBytes(PropertyInfo property, object sourceClass)
        {
            var att =
                property.GetCustomAttributes(typeof(S7ArrayAttribute))
                    .FirstOrDefault() as S7ArrayAttribute;
            var s = property.GetValue(sourceClass, null) as string;
            if (att == null)
                throw new InvalidOperationException("String properties should be marked with S7ArrayAttribute specifying string lenght!!");

            // truncate if too long
            if (s.Length > att.Count)
                s = s.Substring(0, att.Count);
            else if (s.Length < att.Count)
            {
                // fill with spaces to get full length
                var len = s.Length;
                for (int i = 0; i < (att.Count - len); i++)
                {
                    s += " ";
                }
            }
            return Encoding.ASCII.GetBytes(s);
        }
    }
}
