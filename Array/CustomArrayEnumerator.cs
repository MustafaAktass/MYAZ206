using System.Collections;

namespace DataStructures.Array
{
    public class CustomArrayEnumerator : IEnumerator
    {
        private Object[] _array;
        private int _index;
        public object Current => _array[_index];
        public CustomArrayEnumerator(Object[] sourceArray)
        {
            _array = sourceArray;
            _index =_array.Length;
        }
        public bool MoveNext()
        {
            if (_index ==_array.Length)
            {
                _index--;
                return true;
            }
            if( _index > 0)
            {
                _index--;
                return true;
            }
            else
            {
                _index =_array.Length;
                return false;
            }
           
        }
        public void Reset()
        {
            _index = _array.Length;
        }
    }
}