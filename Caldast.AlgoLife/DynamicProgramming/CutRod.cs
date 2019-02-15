using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.DynamicProgramming
{
    public class CutRod
    {
        /// <summary>
        /// Recursive : Time Complexity O(2^n), Space: O(n)
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public int FindMaxPriceRecursive(int [] prices, int length)
        {
            if (length <= 0)
                return 0;

            int maxPrice = int.MinValue;

            for (int i = 1; i <=length; i++)
            {
                maxPrice = Math.Max(maxPrice, prices[i-1] + FindMaxPriceRecursive(prices, length - i));
            }
            return maxPrice;
        }
        /// <summary>
        /// Used memoization. Time Complexity : O(n^2), Space : O(n)
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindMaxPriceRecursiveTopDown(int[] prices, int n)
        {
            int[] memo = new int[n + 1];
            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = int.MinValue;
            }

            return FindMaxPriceRecursiveTopDownHelper(prices, n, memo);
        }

        private int FindMaxPriceRecursiveTopDownHelper(int[] prices, int n,
            int [] memo)
        {
            if (memo[n] >= 0)
                return memo[n];

            if (n <= 0)
            {
                return 0;
            }
            else
            {
                int maxPrice = int.MinValue;

                for (int i = 1; i <= n; i++)
                {
                    maxPrice = Math.Max(maxPrice, prices[i] + FindMaxPriceRecursive(prices, n - i));
                }

                memo[n] = maxPrice;
                return maxPrice;
            }
        }

        public List<int> BottomUpApproach(int[] prices, int n)
        {
            int[] pieces = new int[n+1];
            int[] maxRevenue = new int[n+1];

            for (int j = 1; j <= n; j++)
            {
                int maxPrice = int.MinValue;
                for (int i = 1; i <= j; i++)
                {
                    if (maxPrice < prices[i] + maxRevenue[j - i])
                    {
                        maxPrice = prices[i] + maxRevenue[j - i];
                        pieces[j] = i;
                    }

                }

                maxRevenue[j] = maxPrice;
            }

            var list = new List<int>();
            while (n > 0)
            {
                list.Add(pieces[n]);
                n = n - pieces[n];
            }

            return list;
        }
    }
}
