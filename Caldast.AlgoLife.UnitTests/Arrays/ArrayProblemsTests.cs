using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Caldast.AlgoLife.Arrays.Tests
{
    [TestClass]
    public class ArrayProblemsTests
    {
        [TestMethod]
        public void GetSpiralOrderTest()
        {
            var arrayProblems = new ArrayProblems();
            // m x n matrix
            int[,] inputForSpiral = new int[,] { {1,2,3,4,5,6},
                                                 {7,8,9,1,2,3},
                                                 {4,5,6,7,8,9},
                                                 {1,2,3,4,5,6},
                                                 {7,8,9,1,2,3}
                                                };

            int[] spiralOrder = arrayProblems.GetSpiralOrder(inputForSpiral);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 3, 9, 6,
                3, 2, 1, 9, 8, 7, 1, 4, 7, 8, 9, 1, 2, 8, 5, 4, 3, 2, 5, 6, 7 }, spiralOrder);

            // m x m matrix 
            int[,] inputForSpiral1 = new int[,] { {1,2,3},
                                                  {4,5,6},
                                                  {7,8,9}
                                                };
            int[] spiralOrder1 = arrayProblems.GetSpiralOrder(inputForSpiral1);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 }, spiralOrder1);

            // 1 x 1 matrix
            int[,] inputForSpiral2 = new int[,] { {1} };
            int[] spiralOrder2 = arrayProblems.GetSpiralOrder(inputForSpiral2);
            CollectionAssert.AreEqual(new int[] { 1 }, spiralOrder2);
           
            // null matrix           
             
            Assert.ThrowsException<ArgumentException>(()=> arrayProblems.GetSpiralOrder(null));
        }
    }
}