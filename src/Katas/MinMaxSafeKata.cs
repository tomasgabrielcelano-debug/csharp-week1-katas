using System;
using System.Collections.Generic;

namespace Katas;

public static class MinMaxSafeKata
{
    public static (int? Min, int? Max) MinMaxSafe(IEnumerable<int>? numbers)
    {
        if (numbers is null)
            throw new ArgumentNullException(nameof(numbers));

        using var e = numbers.GetEnumerator();
        if (!e.MoveNext())
            return (null, null);

        int min = e.Current;
        int max = e.Current;

        while (e.MoveNext())
        {
            int n = e.Current;
            if (n < min) min = n;
            if (n > max) max = n;
        }

        return (min, max);
    }
}
