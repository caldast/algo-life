using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.DynamicProgramming
{
    public class WordBreak
    {
        public bool Do(string [] arr, string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            bool result = IsPresent(arr, input);
            for(int i=1;i<input.Length;i++)
            {
                result |= Do(arr, input.Substring(0, i))
                        && IsPresent(arr, input.Substring(i));
            }
            return result;
        }

        public bool DoMemoized(string[] arr, string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            var dict = new Dictionary<string, bool>();
            return DoMemoizedUtil(arr, input, dict);
        }

        private bool DoMemoizedUtil(string[] arr, string input, Dictionary<string,bool> dict)
        {
            if (dict.ContainsKey(input))
                return dict[input];

            bool result = IsPresent(arr, input);
            for (int i = 1; i < input.Length; i++)
            {
                result |= DoMemoizedUtil(arr, input.Substring(0, i), dict)
                        && IsPresent(arr, input.Substring(i));
            }
            dict.Add(input, result);
            return result;
        }

        private bool IsPresent(string [] arr, string input)
        { 
            foreach(string s in arr)
            {
                if (s.Equals(input))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Time Complexity: O(n^3)
        /// Space Complexity: O(n)
        /// </summary>
        /// <returns><c>true</c>, if bottom up was done, <c>false</c> otherwise.</returns>
        /// <param name="s">S.</param>
        /// <param name="wordList">Word list.</param>
        public WbResult[] DoBottomUp(string[] wordList, string s)
        {
            WbResult[] result = new WbResult[s.Length + 1];

            // Fill array with empty result
            int k = 0;
            while(k<result.Length)
            {
                result[k] = new WbResult(false, -1, -1);
                k++;
            }
            // Add words in hash for faster lookup
            var dict = new HashSet<string>();
            foreach (string word in wordList)
            {
                dict.Add(word);
            }
            result[0] = new WbResult(true,-1,-1); // for empty string
            int prev = 0;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j <i; j++)
                {
                    if (result[j].Result && dict.Contains(s.Substring(j,i-j)))
                    {
                        result[i] = new WbResult(true,j,prev);
                        prev = i;
                        break;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </summary>
        /// <param name="s">S.</param>
        /// <param name="arr">Arr.</param>
        /// <param name="startIndex">Start index.</param>
        public void PrintBottomUp(string s, WbResult [] arr, int startIndex)
        {
            if (arr[startIndex].Prev == -1)
                return;

            PrintBottomUp(s, arr, arr[startIndex].Prev);
            Console.WriteLine(s.Substring(arr[startIndex].Start, startIndex - arr[startIndex].Start));

        }

        public class WbResult
        { 
            public bool Result { get;}
            public int Start { get; }
            public int Prev { get; }

            public WbResult(bool result, int start, int prev)
            {
                Result = result;
                Start = start;
                Prev = prev;
            }
        }
    }
}
