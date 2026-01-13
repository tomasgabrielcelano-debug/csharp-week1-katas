using System;
using Xunit;
using Katas;

namespace Katas.Tests;

public class SumListKataTests
{
    [Fact]
    public void Sum_WhenNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => SumListKata.Sum(null));
    }

    [Fact]
    public void Sum_WhenEmpty_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => SumListKata.Sum(Array.Empty<int>()));
    }

    [Fact]
    public void Sum_WithNumbers_ReturnsSum()
    {
        Assert.Equal(6, SumListKata.Sum(new[] { 1, 2, 3 }));
    }
}
