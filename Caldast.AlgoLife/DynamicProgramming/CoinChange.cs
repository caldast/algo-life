namespace Caldast.AlgoLife.DynamicProgramming
{
    public class CoinChange
    {
        public int CountWays_Recursion(int[] coins, int s,int n)
        {
            if (n == 0)
                return 1;
            if (n < 0)
                return 0;
            int ways = 0;
            for (int i = s; i < coins.Length; i++)
            {
                ways += CountWays_Recursion(coins, i, n - coins[i]);
            }

            return ways;
        }

        public int CountWaysTopDownMemoization(int[] coins, int n)
        {
            int [,] memo = new int[n+1, coins.Length];
            for (int i = 0; i < memo.GetLength(0); i++)
            {
                for (int j = 0; j < memo.GetLength(1); j++)
                {
                    memo[i, j] = -1;
                }
            }

            return CountWaysTopDownMemoization(coins, 0, n, memo);
        }

        private int CountWaysTopDownMemoization(int[] coins, int s, int n, int[,] memo)
        {
            if (n == 0)
                return 1;
            if (n < 0)
                return 0;

            if (memo[n,s] >= 0)
                return memo[n,s];

            int ways = 0;
            for (int i = s; i < coins.Length; i++)
            {
                ways += CountWaysTopDownMemoization(coins, i, n - coins[i], memo);
            }

            memo[n,s] = ways;

            return memo[n,s];
        }

        public int CountWaysBottomUp(int [] coins, int n)
        {
            int [] memo = new int[n+1];
            memo[0] = 1;
            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = 1; j < memo.Length; j++)
                {
                    if (coins[i] <= j)
                        memo[j] = memo[j - coins[i]] + memo[j];
                }
            }

            return memo[memo.Length - 1];
        }
    }
}
