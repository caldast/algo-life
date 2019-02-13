using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.DynamicProgramming
{
    public class LongestIncreasingSubsequence
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

        /// <summary>
        /// Bottom-up approach for Longest Incresing Subsequence.
        /// Time Complexity: O(n^2)
        /// Space Complexity: O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public LinkedList<int> IterativeLis(int[] arr)
        {
            /*
             The idea here is to maintain two different arrays 
             a) for max length of subsequence. For each element in the original array 
             (except first since we know it's max subsequence len will be 1), we iterate from the beginning using
             another pointer (j below) and check if current element (arr[i] below) is larger and if so we increment by 1 
             (since now the length is atleast 2) with the value from corresponding j index (length for previous element in original array) maintained in 
             max length array. Since in DP we generally use the result of previous step to calculate result for next step,
             we take that advantage here too.
             
             b) Index of previous element that is part of subsequence formed together with current index
             This is maintained so that we can iterate the subsequence chain to print result. 
             We also maintain the index of where the maximum length is stored which will give 
             us the index to start iterating backwards from.
             */
            if (arr == null || arr.Length == 0)
                return null;
            int [] maxLenArr = new int[arr.Length];
            int [] indexArr = new int[arr.Length];

            maxLenArr[0] = 1;
            indexArr[0] = -1;
            int maxLenIndex = 0;
            int maxLen = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                maxLenArr[i] = 1;
                indexArr[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        maxLenArr[i] = maxLenArr[j] + 1;
                        indexArr[i] = j;
                    }

                }

                if (maxLenArr[i] > maxLen)
                {
                    maxLenIndex = i;
                    maxLen = maxLenArr[i];
                }
            }

            var list = new LinkedList<int>();
            while(maxLenIndex!=-1)
            {
                list.AddFirst(arr[maxLenIndex]);
                maxLenIndex = indexArr[maxLenIndex];
            } 

            return list;
        }

        /// <summary>
        /// Time Complexity : O(nlogn)
        /// Space Complexity: O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxSubsequenceLengthUsingBinarySearch(int[] arr)
        {
            /*
             The idea here is to perform binary search on the temp array that we maintain.
             Please note that this temp array won't give the largest subsequence but it's count (no of elements)
             will give the largest subsequence length.
             
            For each element in the original array, we try to find its place in temp array. This is done
            by performing binary search on temp array. We define the region (start, end) in temp array to 
            perform binary search.
             */

            int [] temp = new int[arr.Length];

            int len = 0;

            foreach (var element in arr)
            {
                int idx = BinarySearch(temp, 0, len - 1, element);
                temp[idx] = element;
                if (idx == len)
                {
                    len++;
                }
            }

            return len;
        }

        private int BinarySearch(int[] arr, int low, int high, int search)
        {
            while (low <= high)
            {
                int mid = (low + (high-low)/2);
                if (arr[mid] == search)
                    return mid;
                else if (search > arr[mid])
                    low = mid + 1;
                else high = mid - 1;
            }

            return low;

        }

    }
}
