
using System;

/// <summary>
///  
/// </summary>
[S7DB(DB = 4)]
public class TestDB: DBBase // DB4
{
    /// <summary>
    /// 
    /// </summary>
    public short count { get; set; }

    public short date { get; set; } // DATE

    public TimeSpan time { get; set; } // ora del giorno

    public TimeSpan ts { get; set; } // timespan

    public DateTime datetime { get; set; }
    /// <summary>
    /// Variabile jolly provvisoria
    /// </summary>

    protected short [] __DB_VAR = new short[10];
    [S7Array(Count = 10)]
    public short [] DB_VAR { get { return __DB_VAR; } set { __DB_VAR = value; } } // = new short[10];\r\n
    /// <summary>
    /// 
    /// </summary>

    protected byte [] __chars = new byte[5];
    [S7Array(Count = 5)]
    public byte [] chars { get { return __chars; } set { __chars = value; } } // = new byte[5];\r\n
    /// <summary>
    /// 
    /// </summary>
    public class T_myclass	{

        /// <summary>
        /// 
        /// </summary>
        public short v1 { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public double v2 { get; set; }

    }

    public T_myclass myclass { get; set; }
}