using System;
using Xunit;
using Katas;

namespace Katas.Tests;

public class FilterEvenAndSortKataTests
{
    [Fact]
    public void FilterEvenAndSort_WhenNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => FilterEvenAndSortKata.FilterEvenAndSort(null));
    }

    [Fact]
    public void FilterEvenAndSort_WhenEmpty_ReturnsEmpty()
    {
        var result = FilterEvenAndSortKata.FilterEvenAndSort(Array.Empty<int>());
        Assert.Empty(result);
    }

    [Fact]
    public void FilterEvenAndSort_FiltersEvens_AndSortsAscending()
    {
        var result = FilterEvenAndSortKata.FilterEvenAndSort(new[] { 3, 2, 1, 4 });
        Assert.Equal(new[] { 2, 4 }, result);
    }

    [Fact]
    public void FilterEvenAndSort_WorksWithNegatives_AndZero()
    {
        var result = FilterEvenAndSortKata.FilterEvenAndSort(new[] { 5, -2, 4, -3, 0 });
        Assert.Equal(new[] { -2, 0, 4 }, result);
    }

    [Fact]
    public void FilterEvenAndSort_AllOdd_ReturnsEmpty()
    {
        var result = FilterEvenAndSortKata.FilterEvenAndSort(new[] { 1, 3, 5 });
        Assert.Empty(result);
    }
}
