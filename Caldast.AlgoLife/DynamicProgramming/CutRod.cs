using System;

namespace Caldast.AlgoLife.DynamicProgramming
{
    public class CutRod
    {
        public int Recursive(int [] prices, int length)
        {
            if (length <= 0)
                return 0;

            int q = int.MinValue;

            for (int i = 0; i <length; i++)
            {
                q = Math.Max(q, prices[i] + Recursive(prices, length - i-1));
            }
            return q;
        }
    }
}
