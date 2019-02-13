using Caldast.AlgoLife.DynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caldast.AlgoLife.UnitTests.DynamicProgramming
{
    [TestClass]
    public class CoinChangeTests
    {
        [TestMethod]
        public void CoinChange_NoOfWaysToRepresent_Recursion_Test()
        {
            var coinChange = new CoinChange();
            int[] coins = new int[] {1, 5, 10};
            int ways = coinChange.CountWays_Recursion(coins, 0, 10);
            int expected = 4;
            Assert.AreEqual(expected, ways);

            ways = coinChange.CountWays_Recursion(coins, 0, 8);
            expected = 2;
            Assert.AreEqual(expected, ways);
        }

        [TestMethod]
        public void CoinChange_NoOfWaysToRepresent_TopDownMemoization_Test()
        {
            var coinChange = new CoinChange();
            int[] coins = new int[] {1, 5, 10};
            int ways = coinChange.CountWaysTopDownMemoization(coins, 10);
            int expected = 4;
            Assert.AreEqual(expected, ways);

            ways = coinChange.CountWaysTopDownMemoization(coins, 8);
            expected = 2;
            Assert.AreEqual(expected, ways);
        }


        [TestMethod]
        public void CoinChange_NoOfWaysToRepresent_BottomUp_Test()
        {
            var coinChange = new CoinChange();
            int[] coins = { 5, 10 };
            int ways = coinChange.CountWaysBottomUp(coins, 12);
            int expected = 0;
            Assert.AreEqual(expected, ways);

        }
    }
}