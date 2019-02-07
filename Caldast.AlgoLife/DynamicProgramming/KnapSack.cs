using System;

namespace Caldast.AlgoLife.DynamicProgramming
{
    public class KnapSack
    {

        public int KnapsackBottomUpDp(int[] weights, int[] prices, int capacity)
        {
            if (weights == null || weights.Length == 0
                                || prices == null || prices.Length == 0)
                return -1;

            int [,] dp = new int[weights.Length + 1,capacity +1];

            for (int i = 1; i <= weights.Length; i++)
            {
                for (int j = 1; j <= capacity; j++)
                {
                    if (weights[i-1] > j)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], prices[i-1] + dp[i - 1, j - weights[i - 1]]);
                    }
                }
            }

            return dp[weights.Length, capacity];
        }
    }
}
