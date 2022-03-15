using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataStructures.Array
{
    public class Array : IEnumerable, ICloneable
    {
        public int lenght => InnerList.Length;
        public Object[] InnerList { get; set; }
        public Array(int defaultSize=16)
        {
            InnerList = new Object[defaultSize];
        }
        public Array(params Object[] sourceArray):this(sourceArray.Length)
        {
            //int c = 0;
            //foreach (var item in sourceArray)
            //{
            //    InnerList[c] = item;
            //    c++;
            //}
            System.Array.Copy(sourceArray, InnerList, sourceArray.Length);
        }
        public Object GetValue(int index)
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
        public void SetValue(int index, object deger)
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

        public IEnumerator GetEnumerator()
        {
             return InnerList.GetEnumerator();
            //return new CustomArrayEnumerator(InnerList);
        }
        public int IndexOf(Object value)
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
    }
}
