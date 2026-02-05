using System.Collections.Generic;

public static class Extensions
{
    /// <summary>
    /// This is the extension method the test file is looking for.
    /// It converts an IEnumerable to a bracketed string format.
    /// </summary>
    public static string AsString<T>(this IEnumerable<T> values)
    {
        return "<IEnumerable>{" + string.Join(", ", values) + "}";
    }
}