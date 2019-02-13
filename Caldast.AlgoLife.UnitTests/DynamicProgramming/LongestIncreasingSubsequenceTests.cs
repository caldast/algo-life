using Caldast.AlgoLife.DynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Caldast.AlgoLife.UnitTests.DynamicProgramming
{
    [TestClass]
    public class LongestIncreasingSubsequenceTests
    {
        [TestMethod]
        public void IterativeLis_Is_Generating_Largest_SubSequence()
        {
            var lis = new LongestIncreasingSubsequence();
            int[] arr = {1,2,3,4,5};
            LinkedList<int> sequence = lis.IterativeLis(arr);
            CollectionAssert.AreEqual(new []{1,2,3,4,5},sequence);

            int[] arr1 = { 60,50,40,30,20 };
            LinkedList<int> sequence1 = lis.IterativeLis(arr1);
            CollectionAssert.AreEqual(new[] {60}, sequence1);

        }

        [TestMethod]
        public void IterativeLis_Is_Counting_Largest_SubSequence()
        {
            var lis = new LongestIncreasingSubsequence();
            int[] arr = { 10, 9, 2, 5, 3, 7, 101, 6 };
            LinkedList<int> sequence = lis.IterativeLis(arr);
            Assert.AreEqual(4,sequence.Count);
        }

        [TestMethod]
        public void BinarySearchLis_Is_Counting_Largest_SubSequence()
        {
            var lis = new LongestIncreasingSubsequence();
            int[] arr = { 10, 9, 2, 5, 3, 7, 101, 6 };
            int len = lis.MaxSubsequenceLengthUsingBinarySearch(arr);
            Assert.AreEqual(4, len);
        }


    }
}