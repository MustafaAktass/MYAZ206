using System.Collections;

namespace LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> :IEnumerable<T>
    {
        public int Count { get; private set; }
        public DbNode<T> Head { get; set; }
        public DbNode<T> Tail { get; set; }
        private bool isHeadNull=>Head == null;
        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public DoublyLinkedList(IEnumerable<T> collection):this()
        {
            foreach (var item in collection)
            {
               AddLast(item);
            }
        }
        public void AddFirst(T value)
        {
            var newNode=new DbNode<T>(value);
            if (isHeadNull)
            {
                Head = newNode;
                Tail = newNode;
                Count++;
                return;
            }
            newNode.Next = Head;
            Head.Prev = newNode;
            Head= newNode;
            Count++;
            return ;

        }
        public void AddLast(T value)
        {
            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }

            var newNode= new DbNode<T>(value);
            Tail.Next = newNode;
            Tail.Prev = Tail;
            Tail = newNode;
            Count++;
            return;
        }
        public void AddBefore(DbNode<T> node, T value)
        {
            if (node == null || value is null)
                throw new ArgumentNullException();

            
            if (isHeadNull || node.Equals(Head))
            {
                AddFirst(value);
                return;
            }
            var newNode = new DbNode<T>(value);
            var current = Head;
            var prev = current;

            while(current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = prev.Next;
                    newNode.Prev = prev;
                    prev.Next = newNode;
                    newNode.Next.Prev = newNode;
                }
                prev = current;
                current = current.Next;
            }
            throw new ArgumentException("There is no such a node in the list.");
        }
        public T RemoveFirst()
        {
            if (isHeadNull)
            {
                throw new Exception(nameof(Head));
            }
            var temp = Head;
            if (Count == 1)
            {
                Head = null;
                return temp.Value;
            }
            Head = Head.Next;
            Head.Prev = null;
            Count--;
            return temp.Value;           
        }
        public T RemoveLast()
        {
            if (isHeadNull || Count == 0)
                throw new Exception();

            // Head silinecek ise
            if (Count == 1)
            {
                var temp = Head;
                Head = null;
                Count--;
                return temp.Value;
            }
            var temp2 = Tail;
            Tail.Prev.Next = null;
            Tail = Tail.Prev;
            return temp2.Value;
           
        }
        public T Remove(T value) // O(n)
        {
            // liste boş
            if (isHeadNull)
                throw new Exception("The list is empty.");

            // ara
            var current = Head;
            var prev = current;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    // ilk düğüm
                    if (current.Value.Equals(Head.Value))
                        return RemoveFirst();

                    // son düğüm
                    if (current.Value.Equals(Tail.Value))
                        return RemoveLast();

                    // ara düğüm 
                    var temp = current;
                    prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                    current = null;
                    Count--;
                    return temp.Value;
                }
                prev = current;
                current = current.Next;
            }
            throw new ArgumentException("There is no such a this node in the list.");
        }
        public List<T> ToList() => new List<T>(this);
        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
