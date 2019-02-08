using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.DynamicProgramming
{
    public class KnapSack
    {
        public class KnapSackResult
        {
            public List<int> Weights { get; set; }
            public int MaxValue { get; set; }

            public KnapSackResult(List<int> weights, int maxValue)
            {
                Weights = weights;
                MaxValue = maxValue;
            }
        }

        public KnapSackResult KnapsackBottomUpDp(int[] weights, int[] prices, int capacity)
        {
            if (weights == null || weights.Length == 0
                                || prices == null || prices.Length == 0)
                return null;

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

            var result = new List<int>();

            GetValues(dp, weights, weights.Length, capacity, result);

            return new KnapSackResult(result, dp[weights.Length, capacity]); 
        }

        public void GetValues(int[,] dp,int [] weights, int i, int  j, List<int> result)
        {
            if (dp[i, j] == 0)
                return;

            if (i-1>=0 && dp[i,j] == dp[i-1,j])
                GetValues(dp,weights,i-1,j, result);
            else
            {
                GetValues(dp,weights,i-1,j-weights[i-1], result);
                result.Add(weights[i-1]);
            }
        }
    }
}
