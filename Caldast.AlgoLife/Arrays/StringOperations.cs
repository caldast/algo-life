using System;

namespace Caldast.AlgoLife.Arrays
{
    class StringOperations
    {
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
            ParentHelper(n, 0, 0, new char[2*n],0);
        }
        private void ParentHelper(int n, int left, int right, char [] output, int index)
        {
            if (output == null)
                return;

            if (left > n || right > left)
                return;

            if (left == n && right == n)
            {
                Console.WriteLine(output);
                return;
            }
            output[index] = '(';
            ParentHelper(n, left + 1, right, output, index+1);
            output[index] = ')';
            ParentHelper(n, left, right+1, output, index + 1);
        }
    }
}
