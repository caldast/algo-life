using System;
using System.Collections.Generic;
using System.Linq;

namespace Caldast.AlgoLife.Strings
{
    class StringOperations
    {
        /// <summary>
        /// Time Complexity: O(1) since the total no of ip addresses (IPv4) is 2^32 (32-bit)
        /// </summary>
        /// <returns>The all ip address.</returns>
        /// <param name="s">S.</param>
        public List<string> GetAllIpAddress(string s)
        {
            var res = new List<string>();

            for (int i = 1; i < 4 && i < s.Length; i++)
            {
                string first = s.Substring(0, i);

                if (IsValidIpSegment(first))
                {
                    for (int j = 1; j < 4 && i+j < s.Length; j++)
                    {
                        string sec = s.Substring(i, j);

                        if (IsValidIpSegment(sec))
                        {
                            for (int k = 1; k < 4 && i+j+k < s.Length; k++)
                            {
                                string third = s.Substring(i+j, k);
                                string fourth = s.Substring(i+j+k);

                                if (IsValidIpSegment(third)
                                    && IsValidIpSegment(fourth))
                                {
                                    res.Add(first + "." + sec + "." + third + "." + fourth);
                                }
                            }
                        }
                    }
                }
            }

            return res;
        }

        private bool IsValidIpSegment(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;

            if (s.StartsWith("0", StringComparison.Ordinal) && s.Length > 1)
                return false;

            int val = int.Parse(s);
            return val >= 0 && val <= 255;
        }
        public static void Permute(String str,
                             int l, int r)
        {
            if (l == r)
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = Swap(str, l, i);
                    Permute(str, l + 1, r);
                    str = Swap(str, l, i);
                }
            }
        }

        public static String Swap(String a,
                            int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

        public string Urlify(char[] input, int n)
        {
            int s = 0;

            for (int i = 0; i < n; i++)
            {
                if (input[i] == ' ')
                {
                    s++;
                }
            }
            int e = n - 1 + 3 * s - s;
            for (int i = n - 1; i >= 0; i--)
            {
                if (input[i] != ' ')
                {
                    input[e] = input[i];
                    e--;
                }
                else
                {
                    input[e--] = '0';
                    input[e--] = '2';
                    input[e--] = '%';
                }
            }
            return new string(input);
        }
        public int LongestCommonSubSequence_InEfficient(string a, string b)
        {
            int len = 0;
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = i; j < b.Length; j++)
                {
                    string s = b.Substring(i, j - i + 1);
                    if (Match(a, s) && s.Length > len)
                    {
                        len = s.Length;
                    }
                }
            }
            return len;
        }

        private bool Match(string a, string s)
        {
            int j = 0;           
            for (int i = 0; i < a.Length; i++)
            {                
                if (j < s.Length && a[i] == s[j])
                {
                    j++;
                }
                if (j == s.Length)
                {
                    return true;
                }
                
            }
            return false;
        }
    
        public string LongestCommonPrefix(String[] strs)
        {
            if (strs.Length == 0) return "";
            String prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (prefix == string.Empty) return "";
                }
            }
            return prefix;
        }

        public string LongestCommonPrefix1(string[] strs)
        {
            int len = strs.Length;
            if (strs == null || len == 0)
                return "";

            int end = 0;
            string s = strs[0];

            for (int i = 0; i < s.Length; i++)
            {
                int j = 1;
                int count = 0;
                while (j < len)
                {
                    string next = strs[j];
                    if (next.Length > i && next[i] == s[i])
                        count++;
                    else
                        return s.Substring(0,end);

                    j++;
                }

                if (count == len - 1)
                    end = i + 1;
            }

            return s.Substring(0, end);
        }

        public bool IsSubSequence(String str1, String str2, int m, int n)
        {

            if (n == 0)
                return false;
            if (m == 0)
                return true;
            if (str1[m - 1] == str2[n - 1])
            {
                return IsSubSequence(str1, str2, m - 1, str2.Length);
            }
            else

                return IsSubSequence(str1, str2, m, n - 1);


        }
        public void Parens(int n)
        {
            ParenHelper(new char[2 * n], n,n,0);
        }
        private void ParenHelper(char[] output, int leftParenRemaining, int rightParenRemaining, int index)
        {
           
            if (leftParenRemaining < 0 || rightParenRemaining < leftParenRemaining)
                return;

            if (leftParenRemaining == 0 && rightParenRemaining == 0)
            {
                Console.WriteLine(output);
                return;
            }

            output[index] = '(';
            ParenHelper(output, leftParenRemaining-1, rightParenRemaining,index+1);
            output[index] = ')';
            ParenHelper(output, leftParenRemaining, rightParenRemaining - 1, index + 1);
        }

        public void PrintAllCombinations(string input)
        {
           
            char[] cArr = new char[input.Length];

            List<List<char>> lists = GetCharList(input);

            PrintCombinationRecurse(lists, 0, cArr, input.Length);
        }

        private void PrintCombinationRecurse(List<List<char>> lists, int indx, char[] cArr, int n)
        {
            if (indx == n)
            {
                foreach (char c in cArr)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < lists[indx].Count; i++)
            {
                cArr[indx] = lists[indx][i];
                PrintCombinationRecurse(lists, indx + 1, cArr, n);
            }
        }

        public void PrintAllCombinationsIterative(string input)
        {
            if (string.IsNullOrEmpty(input))
                return;

            int n = input.Length;

            char[] cArr = new char[n];

            List<List<char>> cList = GetCharList(input);

            for (int i = 0; i < n; i++)
            {
                cArr[i] = cList[i][0];
            }

            while (true)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(cArr[i]);                   
                }
                Console.WriteLine();

                for (int j = n - 1; j >= -1; j--)
                {
                    if (j == -1)
                        return;
                    int k = FindIndex(cArr[j], cList[j]);

                    if (k == -1) continue;

                    if (k == cList[j].Count - 1)
                    {
                        cArr[j] = cList[j][0];
                    }
                    else
                    {
                        cArr[j] = cList[j][k + 1];
                        break;
                    }
                }

            }
        }

        private int FindIndex(char c, List<char> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (c == list[i])
                    return i;
            }
            return -1;
        }

        private List<List<char>> GetCharList(string input)
        {
            var list = new List<List<char>>();
            foreach (char c in input)
            {
                switch (c)
                {
                    case '2':
                        list.Add(new List<char>() { 'A','B','C' });
                        break;
                    case '3':
                        list.Add(new List<char>() { 'D', 'E', 'F' });
                        break;
                    case '4':
                        list.Add(new List<char>() { 'G', 'H', 'I' });
                        break;
                    case '5':
                        list.Add(new List<char>() { 'J', 'K', 'L' });
                        break;
                    case '6':
                        list.Add(new List<char>() { 'M', 'N', 'O' });
                        break;
                    case '7':
                        list.Add(new List<char>() { 'P', 'Q', 'R','S' });
                        break;
                    case '8':
                        list.Add(new List<char>() { 'T', 'U', 'V'});
                        break;
                    case '9':
                        list.Add(new List<char>() { 'W', 'X', 'Y','Z' });
                        break;

                }
            }
            return list;

        }

       
    }
}
