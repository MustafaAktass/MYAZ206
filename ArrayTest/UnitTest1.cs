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
        public void defaultConstructorTest(int defaultSize)
        {
            var array = new Array(defaultSize);
            Assert.Equal(defaultSize, array.lenght);
        }
        [Fact]
        public void paramsConstructorTest()
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
        [Fact]
        public void IndexOfTest()
        {
            //arrange
            var array=new DataStructures.Array.Array(10,11,12,13);
            //act
            var result = array.IndexOf(10);
            //assert
            Assert.Equal(0, result);
        }
    }
}