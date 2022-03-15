using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Array.Generic;
using Xunit;

namespace ArrayTest
{
    public class GenericArrayTest
    {
        private Array<char> _array;
        public GenericArrayTest()
        {           
            _array = new Array<char>(new char[] {'s','a','m','u'});
        }
        [Theory]
        [InlineData(16)]
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(128)]
        [InlineData(256)]
        public void DefaultSize_Test(int defultSize)
        {
            var arr=new Array<char>(defultSize);

            Assert.Equal(arr.lenght, defultSize);
        }

        [Fact]
        public void Params_constructor_Test()
        {
            var arr=new Array<int>(1,2,3,4);
            Assert.Equal(4,arr.lenght);
        }
        [Fact]
        public void GetValue_Test()
        {
            var a=_array.GetValue(0);
            Assert.Equal('s', a);
        }
        [Fact]
        public void SetValue_Test()
        {
            _array.SetValue(0, 'S');
            Assert.Equal('S', _array.GetValue(0));
        }

    }
}
