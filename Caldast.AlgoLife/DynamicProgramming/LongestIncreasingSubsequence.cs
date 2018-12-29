using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.DynamicProgramming
{
    class LongestIncreasingSubsequence
    {
        private int LisHelper(int[] A, int i, int n, int prev)
        {          
            if (i == n)
            {
                return 0;
            }
            
            int excl = LisHelper(A, i + 1, n, prev);
           
            int incl = 0;
            if (A[i] > prev)
            {
                incl = 1 + LisHelper(A, i + 1, n, A[i]);
            }
            
            return Math.Max(incl, excl);
        }

        public int LisRecursive(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return 0;

            return LisHelper(arr, 0,arr.Length,int.MinValue);
        }

        public LinkedList<int> Iterative(int[] arr)
        {          
            int[] maxArr = new int[arr.Length];
            int[] prevArray = new int[arr.Length];

            int maxLen = 1;
            int maxIndex = -1;
            maxArr[0] = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                maxArr[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        if (maxArr[j] + 1 > maxArr[i])
                        {
                            maxArr[i] = maxArr[j] + 1;

                            if (maxLen < maxArr[j] + 1)
                            {
                                maxLen = maxArr[j] + 1;
                                maxIndex = i;
                            }
                            prevArray[i] = j;
                        }
                    }
                }
            }

            var list = new LinkedList<int>();
            while (true)
            {
                list.AddFirst(arr[maxIndex]);
                if (maxIndex == 0)
                {
                    break;
                }
                maxIndex = prevArray[maxIndex];
            }

            return list;
        }
    }
}
