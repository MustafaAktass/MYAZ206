using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array.Generic
{
    public class Array<T>:ICloneable, IEnumerable<T>
    {
        private int position;
        public int count => position;
        
        public Array(IEnumerable<T> collection):this()
        {
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }
        public int lenght => InnerList.Length;
        public T[] InnerList { get; set; }
        public Array(int defaultSize = 16)
        {
            position = 0;
            InnerList = new T[defaultSize];
        }
        public Array(params T[] sourceArray) : this(sourceArray.Length)
        {
            //int c = 0;
            //foreach (var item in sourceArray)
            //{
            //    InnerList[c] = item;
            //    c++;
            //}
            System.Array.Copy(sourceArray, InnerList, sourceArray.Length);
        }
        public T GetValue(int index)
        {
            if (index > InnerList.Length && index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (InnerList[index] == null)
            {
                throw new ArgumentNullException();
            }
            else
                return InnerList[index];
        }
        public void SetValue(int index, T deger)
        {
            if (index > InnerList.Length && index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (deger == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                InnerList[index] = deger;
            }
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public void Add(T value)
        {
            if (position == lenght)
            {
                DoubleArray();
            }
            if (position < lenght)
            {
                InnerList[position] = value;
                position++;
            }
            else
                throw new Exception();
        }
        public T Remove()
        {
            if (position >= 0)
            {
                var temp = InnerList[position - 1];
                position--;
                if (position == InnerList.Length / 4)
                {
                    HalfArray();
                }
                return temp;
            }
            else
                throw new Exception();
        }

        private void HalfArray()
        {
            try
            {
                var temp = new T[InnerList.Length / 2];
                System.Array.Copy(InnerList, temp, InnerList.Length / 2);
                InnerList = temp;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void DoubleArray()
        {
            try
            {
                var temp = new T[InnerList.Length * 2];
                System.Array.Copy(InnerList, temp, InnerList.Length);
                InnerList = temp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public int IndexOf(T value)
        {
            for (int i = 0; i < InnerList.Length; i++)
            {
                if (value.Equals(InnerList[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator<T>(InnerList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

