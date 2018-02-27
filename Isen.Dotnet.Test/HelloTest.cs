using System;
using Xunit;
using Isen.Dotnet.Library;

namespace Isen.Dotnet.Test
{
    public class HelloTest
    {
        [Fact]
        public void World()
        {
            var result = Hello.World;
            var expected = "Hello, World!";
            Assert.True(result==expected);
        }

        [Fact]
        public void Greet()
        {
            var result = Hello.Greet("Kail");
            Assert.StartsWith("Hello Kail, it is", result);
        }

        [Fact]
        public void GreetUpper()
        {
            var result = Hello.GreetUpper("Kail");
            Assert.StartsWith("Hello KAIL, it is", result);
        }
    }
    
}
