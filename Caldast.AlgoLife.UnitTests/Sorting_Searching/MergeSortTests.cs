using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.Tests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void Should_Sort_Array()
        {
            int[] arr = {8, 2, 5, 4, 3, 5, 2, 1, 6, 7, 9, 4};
            var m = new MergeSort();
            m.Sort(arr,3,9);

            CollectionAssert.AreEqual(new int[]{ 8, 2, 5, 1, 2, 3, 4, 5, 6, 7, 9, 4},arr);
        }
        [TestMethod]
        public void Should_Sort_NegativeNumbers_Array()
        {
            int[] arr = { 8, 2, 5, -4, -3, -5, -2, -1, -6, -7, 9, 4 };
            var m = new MergeSort();
            m.Sort(arr, 3, 9);

            CollectionAssert.AreEqual(new int[] { 8, 2, 5, -7, -6, -5, -4, -3, -2, -1,9, 4 }, arr);
        }
    }
}