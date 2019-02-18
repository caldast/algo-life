using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.DynamicProgramming
{
    public class MatrixChainMultiplication
    {
        /// <summary>
        /// Counts the minimum multiplication cost for matrices.
        /// Time Complexity: O(n^2)
        /// Space Complexity: O(n)
        /// </summary>
        /// <returns>The minimum multiplication.</returns>
        /// <param name="arr">Arr.</param>
        public int CountMinCostForMultiplication(int [] arr)
        {
            return CountMinCostForMultiplicationUtil(arr, 1, arr.Length-1);
        }

        private int CountMinCostForMultiplicationUtil(int[] arr, int i, int j)
        {
            if (i == j)
                return 0;

            int min = int.MaxValue;

            for(int k=i;k<j;k++)
            {
                min = Math.Min(min,(CountMinCostForMultiplicationUtil(arr, i, k)
                         + CountMinCostForMultiplicationUtil(arr, k+1, j)
                         + arr[i - 1]* arr[k] * arr[j]));
            }
            return min;
        }
        /// <summary>
        /// Counts the minimum multiplication cost for matrices.
        /// Time Complexity: O(n^3)
        /// Space Complexity: O(n^2)
        /// </summary>
        /// <returns>The minimum cost for multiplication.</returns>
        /// <param name="arr">Arr.</param>
        public int CountMinCostForMultiplication_Memoized(int[] arr)
        {
            int[,] memo = new int[arr.Length, arr.Length];
            for (int r = 0; r < memo.GetLength(0); r++)
            {
                for (int c = 0; c < memo.GetLength(1); c++)
                {
                    memo[r, c] = -1;
                }
            }
            return CountMinCostForMultiplicationUtil_Memoized(arr, 1, arr.Length - 1,memo);
        }
        private int CountMinCostForMultiplicationUtil_Memoized(int[] arr, int i, int j, int[,]memo)
        {
            if (i == j)
                return 0;

            if (memo[i, j] >= 0)
                return memo[i, j];

            int min = int.MaxValue;

            for (int k = i; k < j; k++)
            {
                min = Math.Min(min, (CountMinCostForMultiplicationUtil_Memoized(arr, i, k,memo)
                         + CountMinCostForMultiplicationUtil_Memoized(arr, k + 1, j,memo)
                         + arr[i - 1] * arr[k] * arr[j]));
            }
            return min;
        }

        /// <summary>
        /// Time Complexity: O(n^3)
        /// Space Complexity: O(n)
        /// </summary>
        /// <returns>The minimum cost for multiplication memoized bottom up.</returns>
        /// <param name="p">P.</param>
        public int CountMinCostForMultiplication_Memoized_BottomUp(int[] p)
        {
            int n = p.Length;

            int[,] m = new int[n+1,n+1];
            int[,] s = new int[n + 1, n + 1];
           
            int j = 0;
            int temp = 0;

            for(int l = 2; l< n;l++)
            {
                for(int i=1;i<n-l+1;i++)
                {
                    j = l+i-1;

                    m[i, j] = int.MaxValue;

                    for(int k=i;k<j;k++)
                    {
                        temp = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];
                        if(temp < m[i,j])
                        {
                            m[i, j] = temp;
                            s[i, j] = k;
                        }
                    }
                }
            }

            PrintParens(p, s, 1, n-1);
            return m[1, n-1];
        }

        private void PrintParens(int[] p,  int[,]s, int i, int j)
        {
            if (i == j)
                Console.Write(p[i-1]+" ");
            else
            {
                Console.Write("("+" ");
                PrintParens(p, s, i, s[i, j]);
                PrintParens(p, s,s[i, j] + 1, j);
                Console.Write(")"+" ");
            }
        }
    }
}
