using System.Collections;

namespace DataStructures.Array.Generic
{
    public class ArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] _array;
        private int _index;
        public ArrayEnumerator(T[] array)
        {
            _array = array;
            _index = -1;
        }
        public T Current => _array[_index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _array = null;  
        }

        public bool MoveNext()
        {
            if(_index >= _array.Length-1)
            {
                _index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}

