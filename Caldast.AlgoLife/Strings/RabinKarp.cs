namespace Caldast.AlgoLife.Strings
{
    public class RabinKarp
    {
        /// <summary>
        /// Time complexity: O(nm); m = length of pattern, n = length of text.
        /// Space complexity: O(1)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        public int HasSubstring(string text, string pattern)
        {
            if (text == null || pattern == null)
            {
                throw new System.ArgumentException("input cannot be null");
            }

            const int q = 17;
            const int d = 256;

            int m = pattern.Length;
            int n = text.Length;
            int i = 0;
            int j = 0;
            int pHash = 0; 
            int textHash = 0;  
            int highDegree  = 1;
            
            for (i = 0; i < m - 1; i++)
                highDegree  = (highDegree  * d) % q;

            for (i = 0; i < m; i++)
            {
                pHash = (d * pHash + pattern[i]) % q;
                textHash = (d * textHash + text[i]) % q;
            }

          
            for (i = 0; i <= n-m; i++)
            {
                if (pHash == textHash)
                {                    
                    for (j = 0; j < m; j++)
                    {
                        if (text[i+j] != pattern[j])
                            break;
                    }

                    
                    if (j == m)
                        return i;
                }
                if (i < n - m)
                {                    

                    textHash = (d * (textHash - text[i] * highDegree ) + text[i+m]) % q;
                    
                    if (textHash < 0)
                        textHash = (textHash + q);
                }

               
            }
            return -1;
        }
        
    }
}
