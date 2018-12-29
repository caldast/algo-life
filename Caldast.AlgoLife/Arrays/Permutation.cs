using System;
using System.Collections.Generic;
using System.Linq;

namespace Caldast.AlgoLife.Arrays
{
    public class Permutation
    {
        public void FindUniquePermutation(char [] arr)
        {
            var dict = new Dictionary<char, int>();
            foreach (char c in arr)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict.Add(c, 1);
            }
            var result = new char[arr.Length];

            for (int i = 0; i < dict.Count; i++)
            {
                var e = dict.ElementAt(i); 
                PermuteUtil(dict,e.Key, result, 0);
            }
            
        }


        private void PermuteUtil(Dictionary<char, int> dict, char c ,char[] result, int depth)
        { 

            dict[c]--;
            result[depth] = c;
            depth++;

            for (int i = 0; i < dict.Count; i++)
            {
                var e = dict.ElementAt(i);
                if (e.Value > 0)
                {
                    PermuteUtil(dict, e.Key, result, depth);                   
                }
            }
            dict[c]++;

            if (depth == result.Length)
            {
                PrintArray(result);
                return;
            }

        }

        public void FindUniquePermutationModified(char[] arr)
        {
            var dict = new SortedDictionary<char, int>();
            foreach (char c in arr)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict.Add(c, 1);
            }

            char[] str = new char[dict.Count];
            int[] count = new int[dict.Count];

            int index = 0;
            foreach (var kv in dict)
            {
                str[index] = kv.Key;
                count[index] = kv.Value;
                index++;
            }

            var result = new char[arr.Length];

            PermuteUtilModified(count, str, result, 0);

        }

        private void PermuteUtilModified(int[] count, char [] str, char[] result, int depth)
        {
            if (depth == result.Length)
            {
                PrintArray(result);
                return;
            }

            for (int i = 0; i < count.Length; i++)
            {
                int ct = count[i];
                if (ct > 0)
                {
                    char c = str[i];
                    count[i]--;
                    result[depth] = c; 
                    PermuteUtilModified(count, str, result, depth+1);
                    count[i]++;
                }
            }            

        }

        private void PrintArray(char[] arr)
        {
            foreach (char c in arr)
                Console.Write($"{c} ");

            Console.Write("\n");
        }
    }
}
