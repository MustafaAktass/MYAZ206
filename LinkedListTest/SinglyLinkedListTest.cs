using LinkedList.SinglyLinkedList;
using System;
using Xunit;

namespace LinkedListTest
{
    public class SinglyLinkedListTest
    {
        private SinglyLinkedList<int> _list;
        public SinglyLinkedListTest()
        {
            _list = new SinglyLinkedList<int>(new int[] {6,8});
        }
        [Fact]
        public void Count_Test()
        {
            int count=_list.Count;
            Assert.Equal(2, count);
        }
        [Theory]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void AddFirst_Test(int value)
        {
            _list.AddFirst(value);
            Assert.Equal(value, _list.Head.Value);
           
        }
        [Fact]
        public void GetEnumerator_Test()
        {
            Assert.Collection(_list,
            item=>Assert.Equal(item,8),
            item => Assert.Equal(item, 6));

        }
        [Theory]
        [InlineData(15)]
        public void AddLast_Test(int value)
        {
            _list.AddLast(value);
            Assert.Collection(_list,
                item => Assert.Equal(8, item),
                item=>Assert.Equal(6,item),
                item=>Assert.Equal(value,item));
        }
        [Theory]
        [InlineData(6)]
        [InlineData(20)]
        [InlineData(4)]
        [InlineData(30)]
        [InlineData(12)]
        [InlineData(32)]
        public void AddBefore_Test(int value)
        {
            //act
            _list.AddBefore(_list.Head.Next, value);
            //assert
            Assert.Collection(_list, item => Assert.Equal(8, item),
             item => Assert.Equal(value, item),
             item => Assert.Equal(6, item));
             
        }
        [Fact]
        public void AddBefore_ArgumentException()
        {
            //act
            var node = new SinglyLinkedListNode<int>(55);
            //assert
            Assert.Throws<ArgumentException>(() => _list.AddBefore(node, 45));
        }
        [Theory]
        [InlineData(6)]
        [InlineData(20)]
        [InlineData(4)]
        [InlineData(30)]
        [InlineData(12)]
        [InlineData(32)]
        public void AddAfter_Test(int value)
        {
            //act
            _list.AddAfter(_list.Head, value);
            //assert
            Assert.Collection(_list,
                item => Assert.Equal(8, item),
                item => Assert.Equal(value, item),
                item => Assert.Equal(6, item));
        }
        [Fact]
        public void AddAfter_ArgumentException()
        {
            //act
            var node = new SinglyLinkedListNode<int>(55);
            //assert
            Assert.Throws<ArgumentException>(() => _list.AddAfter(node, 45));
        }
        [Fact]
        public void RemoveFirst_Test()
        {
            _list.RemoveFirst();
             Assert.Collection(_list,
                 item=>Assert.Equal(6, item));
        }
        [Fact]
        public void RemoveFirst_Exception_Test()
        {
            _list.RemoveFirst();
            _list.RemoveFirst();

            Assert.Throws<Exception>(() => _list.RemoveFirst());
        }
        [Fact]
        public void RemoveLast_Test()
        { 
            _list.RemoveLast();
            Assert.Collection(_list,
            item=>Assert.Equal(8, item));
        }
        [Theory]
        [InlineData(8)]
        public void Remove_Test(int value)
        {
            _list.AddAfter(_list.Head, 10);
            _list.Remove(value);

            Assert.Collection(_list,
                item => Assert.Equal(10, item),
                item=>Assert.Equal(6,item));
        }
    }
}