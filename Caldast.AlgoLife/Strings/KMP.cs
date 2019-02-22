namespace Caldast.AlgoLife.Strings
{
    public class KMP
    {
        /// <summary>
        /// Time Complexity: O(m+n); m = length of pattern, n = length of text.
        /// Space Complexity: O(m), m = length of pattern
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public int HasSubstring(string text, string pattern)
        {
            if (text == null || pattern == null)
            {
                throw new System.ArgumentException("input cannot be null");
            }

            
            int[] pArr = BuildPrefixArray(pattern);

            int i = 0;
            int j = 0;

            while (i < text.Length && j<pattern.Length)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    if (j != 0)
                    {
                        j = pArr[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
                if (j == pattern.Length)
                {
                    return i - j;
                }

            }
            return -1;
        }
        
        private int[] BuildPrefixArray(string pattern)
        {
            int[] pArr = new int[pattern.Length];

            int i = 1;
            int j = i - 1;

            while (i < pattern.Length && j < pattern.Length)
            {
                
                if (pattern[i] == pattern[j])
                {
                    pArr[i] = j + 1;
                    j++;
                    i++;
                }
                else
                {
                    if (j != 0)
                    {
                        j = pArr[j - 1];
                    }
                    else
                    {
                        i++;
                      
                    }

                }
            }
            return pArr;
        }
    }
}