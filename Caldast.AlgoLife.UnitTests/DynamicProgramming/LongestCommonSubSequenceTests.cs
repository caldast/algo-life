using System.Collections.Generic;
using Caldast.AlgoLife.DynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.UnitTests.DynamicProgramming
{
    [TestClass]
    public class LongestCommonSubSequenceTests
    {
        [TestMethod]
        public void FindLcsLength_Recursive()
        {
            int[] arr1 = {10, 5, 6, 7, 8,11};
            int[] arr2 = { 10, 5, 6, 11, 8 };

            var lcs = new LongestCommonSubSequence();
            int len = lcs.FindLcsLength_Recursive(arr1, arr2);
            Assert.AreEqual(4,len);

            int[] arr3 = { 10};
            int[] arr4 = { 9 };

            lcs = new LongestCommonSubSequence();
            len = lcs.FindLcsLength_Recursive(arr3, arr4);
            Assert.AreEqual(0, len);
        }

        [TestMethod]
        public void FindLcsLength_Memoized()
        {
            int[] arr1 = { 10, 5, 6, 7, 8, 11,12,13 };
            int[] arr2 = { 10, 5, 6, 11, 8 };

            var lcs = new LongestCommonSubSequence();
            int len = lcs.FindLcsLength_Memoized(arr1, arr2);
            Assert.AreEqual(4, len);

            int[] arr3 = { 10 };
            int[] arr4 = { 9,11,12 };

            lcs = new LongestCommonSubSequence();
            len = lcs.FindLcsLength_Memoized(arr3, arr4);
            Assert.AreEqual(0, len);
        }

        [TestMethod]
        public void FindLCS_BottomUp_Test()
        {
            int[] arr1 = { 10, 5, 6, 7, 8, 11, 12, 13 };
            int[] arr2 = { 10, 5, 6, 11, 8 };

            var lcs = new LongestCommonSubSequence();
            var result = lcs.FindLCS_BottomUp(arr1, arr2);
            var actualSequence = new List<int>();

            int i = result.SymbolArray.GetLength(0)-1;
            int j = result.SymbolArray.GetLength(1)-1;

            lcs.GetLCS(result.SymbolArray, arr1, i, j, actualSequence);

            CollectionAssert.AreEqual(new int[] {10,5,6,11}, actualSequence);
        }
    }
}