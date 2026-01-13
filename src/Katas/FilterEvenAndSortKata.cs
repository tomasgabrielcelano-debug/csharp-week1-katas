using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas;

public static class FilterEvenAndSortKata
{
    public static IReadOnlyList<int> FilterEvenAndSort(IEnumerable<int>? numbers)
    {
        if (numbers is null)
            throw new ArgumentNullException(nameof(numbers));

        // LINQ: filtramos pares y ordenamos ascendente; ToList materializa el resultado.
        return numbers
            .Where(n => n % 2 == 0)
            .OrderBy(n => n)
            .ToList();
    }
}
