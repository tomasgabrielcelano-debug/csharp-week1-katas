using System;
using Xunit;
using Katas;

namespace Katas.Tests;

public class WordCountKataTests
{
    [Fact]
    public void CountWords_WhenNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => WordCountKata.CountWords(null));
    }

    [Fact]
    public void CountWords_WhenWhitespace_ReturnsEmpty()
    {
        var result = WordCountKata.CountWords("   \n\t ");
        Assert.Empty(result);
    }

    [Fact]
    public void CountWords_CountsWords()
    {
        var result = WordCountKata.CountWords("hola hola chau");
        Assert.Equal(2, result["hola"]);
        Assert.Equal(1, result["chau"]);
    }

    [Fact]
    public void CountWords_IsCaseInsensitive()
    {
        var result = WordCountKata.CountWords("Hola hola HOla");
        Assert.Equal(3, result["hola"]);
    }

    [Fact]
    public void CountWords_IgnoresPunctuation()
    {
        var result = WordCountKata.CountWords("hello, world! hello.");
        Assert.Equal(2, result["hello"]);
        Assert.Equal(1, result["world"]);
    }
}
