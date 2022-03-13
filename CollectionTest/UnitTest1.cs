using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CollectionTest
{
    public class UnitTest1
    {
        private List<int> leftList;
        private List<int> rightList;

        public UnitTest1()
        {
            leftList = new List<int> { 1, 2, 3, 4, 4, 5 };
            rightList = new List<int> { 4, 5, 6, 6, 7 };
        }
        [Fact]
        public void Test1()
        {
            var intersectionList = leftList.Intersect(rightList);
            Assert.Equal(2, intersectionList.ToList().Count);

            Assert.Collection(intersectionList,
                item => Assert.Equal(4, item),
                item => Assert.Equal(5, item));
        }
        [Fact]
        public void unionTest()
        {
            var unionlist = leftList.Union(rightList).OrderBy(item => item).ToList();
            Assert.Equal(7, unionlist.ToList().Count);
            Assert.Collection(unionlist,
                item => Assert.Equal(1, item),
                item => Assert.Equal(2, item),
                item => Assert.Equal(3, item),
                item => Assert.Equal(4, item),
                item => Assert.Equal(5, item),
                item => Assert.Equal(6, item),
                item => Assert.Equal(7, item));
        }
        
    }
}