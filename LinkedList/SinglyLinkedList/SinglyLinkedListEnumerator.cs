using System.Collections;

namespace LinkedList.SinglyLinkedList
{
    public class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private SinglyLinkedListNode<T> Head { get; set; }
        private SinglyLinkedListNode<T> current { get; set; }
        public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            Head= head;
            current = null;
        }
        public T Current => current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if(Head == null)
                return false;
            if(current == null)
            {
                current = Head;
                return true;
            }
            if (current.Next != null)
            {
                current=current.Next;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {   
            current=null;
            Head = null;
        }
    }
}
