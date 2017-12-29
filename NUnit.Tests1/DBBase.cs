using System;

[Serializable]
public class DBBase
{
    //public int DB { get; set; }
}

public class S7DBAttribute : System.Attribute
{
    public int DB { get; set; }
}

public class S7ArrayAttribute : System.Attribute
{
    public int Count { get; set; }
}
