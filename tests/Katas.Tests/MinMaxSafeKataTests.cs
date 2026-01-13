using System;
using Xunit;
using Katas;

namespace Katas.Tests;

public class MinMaxSafeKataTests
{
    [Fact]
    public void MinMaxSafe_WhenNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => MinMaxSafeKata.MinMaxSafe(null));
    }

    [Fact]
    public void MinMaxSafe_WhenEmpty_ReturnsNullNull()
    {
        var (min, max) = MinMaxSafeKata.MinMaxSafe(Array.Empty<int>());
        Assert.Null(min);
        Assert.Null(max);
    }

    [Fact]
    public void MinMaxSafe_WithOneElement_ReturnsThatElement()
    {
        var (min, max) = MinMaxSafeKata.MinMaxSafe(new[] { 7 });
        Assert.Equal(7, min);
        Assert.Equal(7, max);
    }

    [Fact]
    public void MinMaxSafe_WithMany_ReturnsMinAndMax()
    {
        var (min, max) = MinMaxSafeKata.MinMaxSafe(new[] { 3, -2, 10, 4 });
        Assert.Equal(-2, min);
        Assert.Equal(10, max);
    }
}
