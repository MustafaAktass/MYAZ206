using LinkedList.DoublyLinkedList;
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
    }
}
