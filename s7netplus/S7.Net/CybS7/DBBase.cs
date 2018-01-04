using System;

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
