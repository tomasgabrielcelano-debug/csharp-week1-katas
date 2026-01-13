using System;
using System.Collections.Generic;

namespace Katas;

public static class SumListKata
{
    public static int Sum(IEnumerable<int>? numbers)
    {
        if (numbers is null)
            throw new ArgumentNullException(nameof(numbers));

        int sum = 0;
        bool hasAny = false;

        foreach (var n in numbers)
        {
            hasAny = true;
            sum += n;
        }

        if (!hasAny)
            throw new ArgumentException("Sequence is empty.", nameof(numbers));

        return sum;
    }
}
