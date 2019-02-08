using Caldast.AlgoLife.DynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.UnitTests.DynamicProgramming
{
    [TestClass]
    public class KnapSackTests
    {
        [TestMethod]
        public void KnapsackBottomUpDpTest()
        {
            int[] prices = { 1, 4, 5, 7 };
            int[] weight = { 1, 3, 4, 5 };
            int capacity = 7;

            var knp = new KnapSack();
            KnapSack.KnapSackResult result = knp.KnapsackBottomUpDp(weight, prices, capacity);
            Assert.AreEqual(result.MaxValue, 9);
            CollectionAssert.AreEqual(result.Weights, new []{3,4});
        }
    }
}