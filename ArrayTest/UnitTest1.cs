using Xunit;
using DataStructures.Array;

namespace ArrayTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(16)]
        [InlineData(32)]
        [InlineData(64)]
        public void Test1(int defaultSize)
        {
            var array = new Array(defaultSize);
            Assert.Equal(defaultSize, array.lenght);
        }
        [Fact]
        public void Test2()
        {
            var array = new DataStructures.Array.Array(1, 2, 3);
            Assert.Equal(3, array.lenght);
        }
        [Fact]
        public void Test3()
        {
            var array = new DataStructures.Array.Array(1, 2, 3);
            string s = "";
            foreach (var item in array)
            {
                s += item;
            }
            Assert.NotEqual("123", s);
        }
       
    }
}