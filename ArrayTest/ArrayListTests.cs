using DataStructures.Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArrayTest
{
    public class ArrayListTests
    {
        private ArrayList _arrayList;
        public ArrayListTests()
        {
            _arrayList = new ArrayList();
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(16)]
        [InlineData(32)]
        [InlineData(64)]
        public void ArrayList_Constructor_Test(int defaultSize)
        {
            //Arrange
            var arrayList=new DataStructures.Array.ArrayList(defaultSize);

            //Assert
            Assert.Equal(arrayList.lenght, defaultSize);
        }
        [Fact]
        public void ArrayList_Add_Test()
        {
            //Arrange
            for(int i = 0; i < 50; i++)
            {
                _arrayList.Add(i);
            }
            //Assert
            Assert.Equal(64, _arrayList.lenght);
        }
        [Theory]
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(128)]
        [InlineData(256)]
        public void ArrayList_Remove_Test(int lenght)
        {
            //Arrange
            for (int i = 0; i < lenght; i++)
            {
                _arrayList.Add(i);
            }
            Assert.Equal(lenght,_arrayList.lenght);
            for (int i = _arrayList.lenght-1; i > 4; i--)
            {
                _arrayList.Remove();
            }
            Assert.Equal(16, _arrayList.lenght);
        }
        [Fact]
        public void ForeEach_Test()
        {
            //arrange
            _arrayList.Add("a");
            _arrayList.Add("b");
            _arrayList.Add("c");
            _arrayList.Add("d");
            //act
            _arrayList.Remove();
            _arrayList.Remove();
            string s = "";
            foreach(var item in _arrayList)
            {
                s += item;
            }
            //assert
            Assert.Equal("ab", s);
        }
        [Fact]
        public void ArrayList_IEnumerable_Test()
        {
            //arrange
            var list=new List<int> { 1,2,3,4};
            //act
            var _array = new DataStructures.Array.ArrayList(list);
            string s = "";
            foreach (var item in _array)
            {
                s += item;
            }
            //assert
            Assert.Equal("1234", s);
        }

    }
}
