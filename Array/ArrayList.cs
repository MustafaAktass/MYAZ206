using System.Collections;

namespace DataStructures.Array
{
    public class ArrayList:DataStructures.Array.Array,IEnumerable
    {
        
        private int position;
        public int count => position;
        public ArrayList(int defaultSize=2):base(defaultSize)
        {
            position = 0;
        }
        public ArrayList(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }
        public void Add(Object value)
        {
            if (position == lenght)
            {
                DoubleArray();
            }
            if (position < lenght)
            {
                InnerList[position]=value;
                position++;
            }
            else
                throw new Exception();
        }
        public Object Remove()
        {
            if (position >= 0)
            {
                var temp=InnerList[position-1];
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
                var temp = new Object[InnerList.Length / 2];
                System.Array.Copy(InnerList, temp, InnerList.Length/2);
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
                var temp = new Object[InnerList.Length*2];
                System.Array.Copy(InnerList, temp, InnerList.Length);
                InnerList = temp;
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }
        new public IEnumerator GetEnumerator()
        {
            return InnerList.Take(position).GetEnumerator();
        }
    }
}
