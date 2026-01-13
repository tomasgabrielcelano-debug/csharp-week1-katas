using System;
using Katas;

namespace Exercises;

public static class Day1
{
    public static void Run()
    {
        Console.WriteLine("Day1");

        Console.WriteLine($"SumList: {SumListKata.Sum(new[] { 1, 2, 3 })}");

        var wc = WordCountKata.CountWords("Hello hello, WORLD!");
        Console.WriteLine($"WordCount: hello={wc["hello"]} world={wc["world"]}");

        var evens = FilterEvenAndSortKata.FilterEvenAndSort(new[] { 7, 2, 10, 3, -4, 0 });
        Console.WriteLine($"FilterEvenAndSort: {string.Join(", ", evens)}");

        var (min, max) = MinMaxSafeKata.MinMaxSafe(new[] { 3, -2, 10, 4 });
        Console.WriteLine($"MinMaxSafe: min={min} max={max}");

        var (min2, max2) = MinMaxSafeKata.MinMaxSafe(Array.Empty<int>());
        Console.WriteLine($"MinMaxSafe(empty): min={min2} max={max2}");
    }
}
