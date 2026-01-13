using Katas;
using Xunit;

namespace Katas.Tests;

public class HelloWorldKataTests
{
    [Fact]
    public void Message_Returns_HelloWorld()
    {
        Assert.Equal("Hello, World! Hola mundo !", HelloWorldKata.Message());
    }
}
