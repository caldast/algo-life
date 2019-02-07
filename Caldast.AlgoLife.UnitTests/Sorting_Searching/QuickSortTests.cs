using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caldast.AlgoLife;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caldast.AlgoLife.Tests
{
    [TestClass()]
    public class QuickSortTests
    {
        [TestMethod()]
        public void SortRecursiveTest()
        {
            var arr = new int[] {4, 3, 2, 1, 5, 0};
          
            QuickSort.SortRecursive(arr,0, arr.Length-1);
            CollectionAssert.AreEqual(arr, new int[] { 0,1,2,3,4,5});
        }

        [TestMethod()]
        public void SortIterativeTest()
        {
            var arr = new int[] { 4, 3, 2, 1, 0 };

            QuickSort.SortIterative(arr, 0, arr.Length - 1);
            CollectionAssert.AreEqual(arr, new int[] { 0, 1, 2, 3, 4 });
        }
    }
}