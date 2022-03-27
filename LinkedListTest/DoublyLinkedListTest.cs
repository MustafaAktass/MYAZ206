using LinkedList.DoublyLinkedList;
using System;
using Xunit;

namespace LinkedListTest
{
    public class DoublyLinkedListTest
    {
        private DoublyLinkedList<char> _list;
        public DoublyLinkedListTest()
        {
            _list = new DoublyLinkedList<char>(new char[] {'a','z'});
        }
        [Theory]
        [InlineData('d')]
        [InlineData('r')]
        [InlineData('y')]
        public void AddFirst_Test(char value)
        {
            //act
            _list.AddFirst(value);

            //assert
            Assert.Equal(value, _list.Head.Value);
        }
        [Theory]
        [InlineData('d')]
        [InlineData('r')]
        [InlineData('y')]
        public void AddLast_Test(char value)
        {
            //act
            _list.AddLast(value);
            var tailValue = _list.Tail.Value;

            //assert
            Assert.Equal(value, tailValue);

            Assert.Collection(_list,
                item=>Assert.Equal(item,'a'),
                item=>Assert.Equal(item,'z'),
                item=>Assert.Equal(item,value));
        }
        [Theory]
        [InlineData('k')]
        [InlineData('m')]
        [InlineData('n')]
        [InlineData('r')]
        [InlineData('s')]
        public void AddBefore_Test(char value)
        {
            
            // act
            _list.AddBefore(_list.Head.Next, value);

            // Assert
            Assert.Equal(value, _list.Head.Next.Value);

            Assert.Collection(_list,
                item => Assert.Equal(item, 'a'),
                item => Assert.Equal(item, value),
                item => Assert.Equal(item, 'z'));
        }

        [Fact]
        public void RemoveLast_Exception_Test()
        {
            // a, z
            // Act
            var r1 = _list.RemoveLast(); // z
            var r2 = _list.RemoveLast(); // a

            // Assert
            Assert.Equal(r1, 'z');
            Assert.Equal(r2, 'a');

            Assert.Throws<Exception>(() => _list.RemoveLast());
        }

        [Fact]
        public void RemoveFirst_Test()
        {
            // a, z
            // z
            // Act
            _list.RemoveFirst();

            // Assert
            Assert.Collection(_list, item => Assert.Equal(item, 'z'));

        }
        [Fact]
        public void ToList_Test()
        {
            //act
            var list=_list.ToList();
            //Assert
            Assert.Collection(list,
                item => Assert.Equal(item,_list.Head.Value),
                item=>Assert.Equal(item,_list.Head.Next.Value));

           }

    }
}
