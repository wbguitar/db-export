using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using S7.Net;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        private Random r = new Random();
        [Test]
        public void TestMethod()
        {
            var plc = new S7.Net.Plc(CpuType.S7300, "213.131.0.161", 0, 2);
            var err = plc.Open();
            if (err != ErrorCode.NoError)
                throw new Exception("");

            var ass = Assembly.GetExecutingAssembly();
            var types = ass.GetTypes().Where(t =>
                typeof(DBBase).IsAssignableFrom(t) && t != typeof(DBBase));

            // parse each DB class in the assembly and test read/write with PLC
            foreach (var t in types)
            {
                Console.WriteLine(t.Name);
                // reads the DB number from class attribute
                var dbnum = t.GetCustomAttributes(typeof(S7DBAttribute)).FirstOrDefault() as S7DBAttribute;

                // test the DB class read from the PLC
                //var db = plc.ReadClass(() => (DBBase)Activator.CreateInstance(t), dbnum.DB);
                var db = (DBBase)Activator.CreateInstance(t);

                // create a randomized object
                foreach (PropertyInfo propertyInfo in t.GetProperties())
                {
                    // for every property
                    
                    if (propertyInfo.PropertyType.IsArray)
                    {
                        // if it's an array we should instantiate the correct number of elements, read from the property attribute
                        var att =
                            propertyInfo.GetCustomAttributes(typeof(S7ArrayAttribute))
                                .FirstOrDefault() as S7ArrayAttribute;
                        if (att != null)
                        {
                            var elemType = propertyInfo.PropertyType.GetElementType();
                            // instantiate the array and randomize every element
                            var arr = Array.CreateInstance(elemType, att.Count);
                            for (int i = 0; i < att.Count; i++)
                            {
                                var rval = randomize(elemType);
                                arr.SetValue(rval, i);
                            }

                            propertyInfo.SetValue(db, arr);
                        }
                        else
                            throw new Exception("Array element should define S7ArrayAttribute");
                    }
                    else if (propertyInfo.PropertyType.IsClass)
                    {
                        // TODO: need recursion
                    }
                    else
                    {
                        // not an array, so we'll set the randomized value
                        var rval = randomize(propertyInfo.PropertyType);
                        propertyInfo.SetValue(db, rval);
                    }
                }

                // test the DB class write to the PLC
                plc.WriteClass(db, dbnum.DB);
                var db1 = plc.ReadClass(() => (DBBase)Activator.CreateInstance(t), dbnum.DB);

                //Assert.AreEqual(db, db1);
            }

            plc.Close();
        }

        object randomize(Type type)
        {
            if (type == typeof(DateTime))
                return DateTime.Now - TimeSpan.FromTicks(r.Next(Int32.MaxValue));
            else if (type == typeof(TimeSpan))
                return TimeSpan.FromTicks(r.Next(short.MaxValue));
            else if (type == typeof(string))
                return r.Next(Int32.MaxValue).ToString();
            else if (type == typeof(char))
                return (char)r.Next(255);
            else if (type == typeof(byte))
                return (byte)r.Next(byte.MaxValue);
            
            return Convert.ChangeType(r.Next(short.MaxValue), type);
        }



        [Test]
        public void TestMethod1()
        {
            var plc = new S7.Net.Plc(CpuType.S7300, "213.131.0.161", 0, 2);
            var err = plc.Open();
            if (err != ErrorCode.NoError)
                throw new Exception("");

            var t = typeof(DB4);

            // reads the DB number from class attribute
            var dbnum = t.GetCustomAttributes(typeof(S7DBAttribute)).FirstOrDefault() as S7DBAttribute;

            // test the DB class read from the PLC
            //var db = plc.ReadClass(() => (DBBase)Activator.CreateInstance(t), dbnum.DB);
            var db = new DB4();

            // create a randomized object
            foreach (PropertyInfo propertyInfo in t.GetProperties())
            {
                // for every property

                if (propertyInfo.PropertyType.IsArray)
                {
                    // if it's an array we should instantiate the correct number of elements, read from the property attribute
                    var att =
                        propertyInfo.GetCustomAttributes(typeof(S7ArrayAttribute))
                            .FirstOrDefault() as S7ArrayAttribute;
                    if (att != null)
                    {
                        var elemType = propertyInfo.PropertyType.GetElementType();
                        // instantiate the array and randomize every element
                        var arr = Array.CreateInstance(elemType, att.Count);
                        for (int i = 0; i < att.Count; i++)
                        {
                            var rval = randomize(elemType);
                            arr.SetValue(rval, i);
                        }

                        propertyInfo.SetValue(db, arr);
                    }
                    else
                        throw new Exception("Array element should define S7ArrayAttribute");
                }
                else if (propertyInfo.PropertyType.IsClass)
                {
                    propertyInfo.SetValue(db, Activator.CreateInstance(propertyInfo.PropertyType));
                    // TODO: need recursion
                }
                else
                {
                    // not an array, so we'll set the randomized value
                    var rval = randomize(propertyInfo.PropertyType);
                    propertyInfo.SetValue(db, rval);
                }
            }
            
            // test the DB class write to the PLC
            //var ecode = plc.WriteClass(db, dbnum.DB);
            //Assert.AreEqual(ecode, ErrorCode.NoError);


            var bytes = S7.Net.Types.Class.ToBytes(db);
            var ercode = plc.WriteBytes(DataType.DataBlock, dbnum.DB, 0, bytes);

            
            //ecode = plc.WriteClass(db.myclass, dbnum.DB);
            //Assert.AreEqual(ecode, ErrorCode.NoError);
            ////var db1 = plc.ReadClass(() => new Ricettepredosaggio(), dbnum.DB);
            //var db1 = plc.ReadClass<DB4>(dbnum.DB);

            bytes = plc.ReadBytes(DataType.DataBlock, dbnum.DB, 0, bytes.Length);
            DB4 db1 = new DB4();
            S7.Net.Types.Class.FromBytes(db1, bytes);
            //Assert.AreEqual(db, db1);

            plc.Close();
        }
    }
}
