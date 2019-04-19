using System;

namespace Caldast.AlgoLife.OrderStatistics
{
    public class RandomizedSelect
    {

        private Random _rand = new Random();        

        public int FindIthSmallest(int [] arr, int p, int r, int i)
        {
            if (p == r)
                return arr[p];

            int q = RandomPartition(arr, p, r);
            int k = q - p + 1;

            if (k == i)
                return arr[q];

            else if (i < k)
                return FindIthSmallest(arr, p, q - 1, i);
            else return FindIthSmallest(arr, q + 1, r, i - k);
        }

        private int RandomPartition(int [] arr, int p, int r)
        {
            int i = _rand.Next(p, r);
            Swap(arr, i, r);
            return LomutoPartition(arr, p, r);
        }

        private int LomutoPartition(int[] arr, int p, int r)
        {
            int x = arr[r];
            int i = p - 1;
            for (int j = p; j <= r-1; j++)
            {
                if (arr[j] <= x)
                {
                    i = i + 1;
                    Swap(arr, i, j);
                }

            }
            Swap(arr, i + 1, r);
            return i + 1;
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
