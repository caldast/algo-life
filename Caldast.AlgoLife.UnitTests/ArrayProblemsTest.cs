using System;
using Caldast.AlgoLife.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.UnitTests
{
    [TestClass]
    public class ArrayProblemsTest
    {
        private ArrayProblems arrayProblem = null;
        [TestInitialize]
        public void Initialize()
        {
            arrayProblem = new ArrayProblems();
        }
        [TestMethod]
        public void Array_Multiply_Should_Be_Same_As_Product_Of_Numbers()
        {
            int result = arrayProblem.Multiply(new int[] { 2, 2, 3, 4 }, new int[] { 5, 6 });
            int expected = 2234 * 56;
            Assert.AreEqual<int>(expected, result);
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Array_Multiply_Inputs_Cannot_Be_Null()
        {
            int result = arrayProblem.Multiply(null, null);
           
        }

    }
}
