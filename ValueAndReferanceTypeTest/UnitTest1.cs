using Xunit;
using ValueAndRefType;

namespace ValueAndReferanceTypeTest
{
    public class UnitTest1
    {
        [Fact]
        public void SwapByValue()
        {
            int a = 10;
            int b = 20;

            var valtype = new Value();
            valtype.Swap(a, b);
            Assert.NotEqual(a,20);
            Assert.NotEqual(b,10);
        }
        [Fact]
        public void SwapByRef()
        {
            int a = 10;
            int b = 20;

            var valtype = new Referance();
            valtype.Swap(ref a, ref b);
            Assert.Equal(a, 20);
            Assert.Equal(b, 10);
        }
        [Fact]
        public void CheckOutKeyword()
        {
            int a = 100 ;
            var refType=new Referance();
            refType.CheckOut(out a);
            Assert.Equal(25, a);
        }
    }
}