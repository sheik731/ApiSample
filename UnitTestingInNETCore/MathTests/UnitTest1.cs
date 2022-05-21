using System;
using Xunit;
using Math;

namespace MathTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var actual = class1.Add(1,3);
            Assert.Equal(4,actual);
        }
    }
}