using System.Collections.Generic;
using Caldast.AlgoLife.DynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.UnitTests.DynamicProgramming
{
    [TestClass]
    public class CutRodTests
    {
        [TestMethod]
        public void FindMaxPriceRecursive_ShouldProduceMaxCut()
        {
            var cutRod = new CutRod();

            int actual = cutRod.FindMaxPriceRecursive(new[] {0, 2, 5, 9, 6}, 4);

            Assert.AreEqual(actual, 11);
        }
        [TestMethod]
        public void FindMaxPriceRecursiveTopDown_ShouldProduceMaxCut()
        {
            var cutRod = new CutRod();

            int actual = cutRod.FindMaxPriceRecursiveTopDown(new[] { 0, 2, 5, 9, 6 }, 4);

            Assert.AreEqual(actual, 11);
        }

        [TestMethod]
        public void BottomUpApproach_ShouldProduceOptimalCutLengths()
        {
            var cutRod = new CutRod();

            List<int> actual = cutRod.BottomUpApproach(new[] { 0, 2, 5, 9, 6 }, 4);

            var expected = new List<int> {1, 3};

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}