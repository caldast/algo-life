using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caldast.AlgoLife.Sorting_Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caldast.AlgoLife.Sorting_Searching.Tests
{
    [TestClass()]
    public class SelectionSortTests
    {
        [TestMethod]
        public void Should_Sort_Array_Of_Ints()
        {
            int[] arr = { 8, 2, 5, 4, 3, 5, 2, 1, 6, 7, 9, 4 };
            var selction = new SelectionSort();
            selction.Sort(arr);
            CollectionAssert.AreEqual(new int[] { 1,2,2,3, 4,4, 5,5, 6, 7,8, 9 }, arr);
        }
        [TestMethod]
        public void Should_Sort_NegativeNumbers_Array()
        {
            int[] arr = {  -4, -3, -5, -2, -1, -6, -7};
            var selction = new SelectionSort();
            selction.Sort(arr);

            CollectionAssert.AreEqual(new int[] {  -7,-6,-5,-4,-3,-2,-1 }, arr);
        }
    }
}