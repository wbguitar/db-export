
using System;
using System.Collections.Generic;
using NUnit.Framework;

/// <summary>
///  
/// </summary>
[S7DB(DB = 4)]
[Serializable]
public class DB4 : DBBase // DB2
{
    public short count { get; set; }
    private short[] _arrInts = new short[10];
    [S7Array(Count = 10)]
    public short[] Arr
    {
        get { return _arrInts; }
        set { _arrInts = value; }
    }

    private byte[] _arrChars = new byte[5];
    [S7Array(Count = 5)]
    public byte[] Chars
    {
        get { return _arrChars; }
        set { _arrChars = value; }
    }


    [Serializable]
    public class Myclass
    {
        public short v1 { get; set; }
        public double v2 { get; set; }
    }
    //Myclass _myclass = new Myclass();
    //public Myclass myclass { get { return _myclass; } set { _myclass = value; } }
    public Myclass myclass { get; set; }

    //public short v1 { get; set; }
    //public double v2 { get; set; }
}
