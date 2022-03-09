using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndRefType
{
    public class Referance
    {
        public int x { get; set; }
        public int y { get; set; }
        public void Swap(ref int x, ref int y)
        {
            var temp =x;
            x = y;
            y = temp;
        }

        public void CheckOut(out int x)
        {
            x = 25;
        }
    }
}
