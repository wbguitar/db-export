using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using S7.Net;
using S7.Net.UnitTest.Helpers;
using S7Cyb;

namespace NUnit.Tests1
{

    [TestFixture]
    public class TestClass
    {
        private const string PLC_IP = "213.131.0.161";
        private const string TEST_IP = "127.0.0.1";
        /// <summary>
        /// Looks for every class derived from <see cref="DBBase"/> that represents a specific DB class and test read/write from/to PLC: the test randomize the values of the properties 
        /// in the class, writes the values to the related DB in the PLC, then reads the DB again and checks if the two instance of the DB class are the same.
        /// The purpose of the test is to verify that the classes are correctly aligned to the related DB (and possibly to verify that there are no read/write bugs). 
        /// For the test to work properly, the classes should be generated from DbToExcel app, using the actual Step7 program that is loaded in the PLC; once the classes are generated
        /// copy the *.cs files in the "DBs" folder of this test project, then run the TestDBReadWrite test.
        /// NOTE: the PLC should be stopped before running the test, to ensure that there will be no overwrite on the PLC side.
        /// </summary>
        private Random r = new Random();
        [Test(Author = "FBetti", Description = "Test PLC I/O for every DB class")]
        public void TestDBReadWrite()
        {
            var plc = new S7.Net.Plc(CpuType.S7300, PLC_IP, 0, 2);
            var err = plc.Open();
            if (err != ErrorCode.NoError)
                throw new Exception("");

            var ass = Assembly.GetExecutingAssembly();
            var types = ass.GetTypes().Where(t =>
                typeof(DBBase).IsAssignableFrom(t) && t != typeof(DBBase));

            DoTestDB<TestDB>(plc);
            //DoTestDB<DB_SCALE_1>(plc);
            //DoTestDB<DB_Allarmi>(plc);

            // parse each DB class in the assembly and test read/write with PLC
            foreach (var t in types)
            {
                DoTestDB(t, plc);
            }

            plc.Close();
        }

        [Test]
        public void TestDBReadWriteProperty()
        {
            S7TestServer.Start();

            var plc = new S7.Net.Plc(CpuType.S7300, TEST_IP, 0, 2);
            var err = plc.Open();
            if (err != ErrorCode.NoError)
                throw new Exception("");

            var db = randomize(typeof(TestDB)) as TestDB;
            //Assert.IsTrue(db.Write(nameof(db.count), plc));
            //Assert.IsTrue(db.Write(nameof(db.timeofday), plc));
            //Assert.IsTrue(db.Write(nameof(db.datetime), plc));
            Assert.IsTrue(db.Write("db.count", plc));
            Assert.IsTrue(db.Write("db.timeofday", plc));
            Assert.IsTrue(db.Write("db.datetime", plc));

            plc.Close();
            S7TestServer.Stop();
        }

        private void DoTestDB(Type t, Plc plc)
        {
            // reads the DB number from class attribute
            var dbnum = t.GetCustomAttributes(typeof(S7DBAttribute)).FirstOrDefault() as S7DBAttribute;

            // create a randomized object
            var db = (DBBase)randomize(t);
            // writes to the PLC
            plc.WriteClass(db, dbnum.DB);

            // reads from the PLC
            var db1 = plc.ReadClass(() => (DBBase)Activator.CreateInstance(t), dbnum.DB);
            // the two objects should be equals
            checkEquals(db, db1);
            Console.WriteLine("Class {0} (DB{1}) ok", t.Name, dbnum.DB);
        }

        private void DoTestDB<T>(Plc plc) where T : DBBase
        {
            DoTestDB(typeof(T), plc);
        }

        object randomize(Type type)
        {
            if (type.IsPrimitive)
            {
                if (type == typeof(string))
                    return r.Next(Int32.MaxValue).ToString();
                else if (type == typeof(char))
                    return (char)r.Next(255);
                else if (type == typeof(byte))
                    return (byte)r.Next(byte.MaxValue);
                else if (type == typeof(double))
                    return (float)r.NextDouble();


                return Convert.ChangeType(r.Next(short.MaxValue), type);
            }

            if (type == typeof(DateTime))
                return DateTime.Now - TimeSpan.FromMilliseconds(r.Next(Int32.MaxValue));

            if (type == typeof(TimeSpan))
                return TimeSpan.FromMilliseconds(r.Next(int.MaxValue));

            if (type == typeof(string))
            {
                var count = r.Next(256);
                var sb = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    sb.Append((char)r.Next(1, 128));
                }

                return sb.ToString();
            }

            var obj = Activator.CreateInstance(type);
            // create a randomized object
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                // for every property

                if (propertyInfo.PropertyType.IsArray)
                {
                    // if it's an array we should instantiate the correct number of elements, read from the property attribute
                    var att =
                        propertyInfo.GetCustomAttributes(typeof(S7ArrayAttribute))
                            .FirstOrDefault() as S7ArrayAttribute;
                    if (att == null)
                        throw new Exception("Array element should define S7ArrayAttribute");
                    var elemType = propertyInfo.PropertyType.GetElementType();
                    // instantiate the array and randomize every element
                    var arr = Array.CreateInstance(elemType, att.Count);
                    for (int i = 0; i < att.Count; i++)
                    {
                        var rval = randomize(elemType);
                        arr.SetValue(rval, i);
                    }

                    propertyInfo.SetValue(obj, arr);
                }
                //else if (propertyInfo.PropertyType.IsClass)
                //{
                //    var inobj = randomize(propertyInfo.PropertyType);
                //    propertyInfo.SetValue(obj, inobj);
                //}
                else
                {
                    // not an array, so we'll set the randomized value
                    var rval = randomize(propertyInfo.PropertyType);
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        var att =
                            propertyInfo.GetCustomAttributes(typeof(S7ArrayAttribute))
                                .FirstOrDefault() as S7ArrayAttribute;
                        if (att == null)
                            throw new Exception("String element should define S7ArrayAttribute");
                        if ((rval as string).Length > att.Count)
                            rval = (rval as string).Substring(0, att.Count);
                    }
                    propertyInfo.SetValue(obj, rval);
                }
            }

            return obj;
        }

        //[Test]
        //public void TestMethod1()
        //{
        //    var plc = new S7.Net.Plc(CpuType.S7300, "213.131.0.161", 0, 2);
        //    var err = plc.Open();
        //    if (err != ErrorCode.NoError)
        //        throw new Exception("");

        //    var t = typeof(TestDB);

        //    // reads the DB number from class attribute
        //    var dbnum = t.GetCustomAttributes(typeof(S7DBAttribute)).FirstOrDefault() as S7DBAttribute;

        //    // test the DB class read from the PLC
        //    //var db = plc.ReadClass(() => (DBBase)Activator.CreateInstance(t), dbnum.DB);
        //    var db = new TestDB();

        //    // create a randomized object
        //    //foreach (PropertyInfo propertyInfo in t.GetProperties())
        //    //{
        //    //    // for every property

        //    //    if (propertyInfo.PropertyType.IsArray)
        //    //    {
        //    //        // if it's an array we should instantiate the correct number of elements, read from the property attribute
        //    //        var att =
        //    //            propertyInfo.GetCustomAttributes(typeof(S7ArrayAttribute))
        //    //                .FirstOrDefault() as S7ArrayAttribute;
        //    //        if (att != null)
        //    //        {
        //    //            var elemType = propertyInfo.PropertyType.GetElementType();
        //    //            // instantiate the array and randomize every element
        //    //            var arr = Array.CreateInstance(elemType, att.Count);
        //    //            for (int i = 0; i < att.Count; i++)
        //    //            {
        //    //                var rval = randomize(elemType);
        //    //                arr.SetValue(rval, i);
        //    //            }

        //    //            propertyInfo.SetValue(db, arr);
        //    //        }
        //    //        else
        //    //            throw new Exception("Array element should define S7ArrayAttribute");
        //    //    }
        //    //    else if (propertyInfo.PropertyType.IsClass)
        //    //    {
        //    //        propertyInfo.SetValue(db, Activator.CreateInstance(propertyInfo.PropertyType));
        //    //        // TODO: need recursion
        //    //    }
        //    //    else
        //    //    {
        //    //        // not an array, so we'll set the randomized value
        //    //        var rval = randomize(propertyInfo.PropertyType);
        //    //        propertyInfo.SetValue(db, rval);
        //    //    }
        //    //}

        //    //db.myclass.v1 = (short)r.Next(short.MaxValue);
        //    //db.myclass.v2 = (float)r.NextDouble();

        //    db = (TestDB)randomize(typeof(TestDB));

        //    // test the DB class write to the PLC
        //    var ecode = plc.WriteClass(db, dbnum.DB);
        //    Assert.AreEqual(ecode, ErrorCode.NoError);


        //    //var bytes = S7.Net.Types.Class.ToBytes(db);
        //    //var ercode = plc.WriteBytes(DataType.DataBlock, dbnum.DB, 0, bytes);
        //    //var db1 = plc.ReadClass(() => new Ricettepredosaggio(), dbnum.DB);
        //    var db1 = plc.ReadClass<TestDB>(dbnum.DB);

        //    //bytes = plc.ReadBytes(DataType.DataBlock, dbnum.DB, 0, bytes.Length);
        //    //DB4 db1 = new DB4();
        //    //S7.Net.Types.Class.FromBytes(db1, bytes);

        //    //Assert.AreEqual(db, db1);
        //    Assert.DoesNotThrow(() => checkEquals(db, db1));

        //    plc.Close();
        //}

        void checkEquals(object o1, object o2, PropertyInfo property = null)
        {
            var t1 = o1.GetType();
            var t2 = o2.GetType();

            if (t1 != t2)
                throw new Exception(string.Format("Different types: {0} {1}", t1.FullName, t2.FullName));

            if (t1.IsPrimitive || t1 == typeof(DateTime) || t1 == typeof(TimeSpan))
            {
                //if (o1 != o2)
                //    throw new Exception(string.Format("{0} different: {1} {2}", t1.Name, o1, o2));

                //Assert.AreEqual(o1, o2);
                AreEqual(o1, o2, property);
                return;
            }

            if (t1 == typeof(string))
            {
                //Assert.AreEqual(((string)o1).Trim(), ((string)o2).Trim());
                AreEqual(((string)o1).Trim(), ((string)o2).Trim(), property);
                return;
            }

            var props = o1.GetType().GetProperties();
            foreach (var pi in props)
            {
                var p1 = pi.GetValue(o1);
                var p2 = pi.GetValue(o2);

                if (pi.PropertyType.IsArray)
                {
                    var arr1 = p1 as Array;
                    var arr2 = p2 as Array;
                    //Assert.AreEqual(arr1.Length, arr2.Length);
                    AreEqual(arr1.Length, arr2.Length, property);
                    //if (arr1.Length != arr2.Length)
                    //throw new Exception(string.Format("{0}: arrays with different lengths", pi.Name, arr1.Length, arr2.Length));

                    for (int i = 0; i < arr1.Length; i++)
                    {
                        checkEquals(arr1.GetValue(i), arr2.GetValue(i), pi);
                    }
                }
                else //if (pi.PropertyType.IsClass)
                {
                    checkEquals(p1, p2, pi);
                }
            }
        }

        void AreEqual(object o1, object o2, PropertyInfo property)
        {
            if (!Object.Equals(o1, o2))
            {
                Console.Write(" ***** EQUALITY FAILURE ", property != null ? property.Name : "unspecified");
                var bak = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                var prop = property != null ?
                    string.Format("{0}.{1}", property.ReflectedType.ToString().Replace('+', '.').Replace("T_", "").Replace("S7Cyb.", ""), property.Name)
                    : "unspecified";
                Console.Write("\t\t{0}\t\t", prop);
                Console.ForegroundColor = bak;
                Console.WriteLine(": overwritten by the PLC?", property != null ? property.Name : "unspecified");
            }
        }
    }
}
