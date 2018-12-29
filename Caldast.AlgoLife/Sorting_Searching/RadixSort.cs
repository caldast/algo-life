using System;

namespace Caldast.AlgoLife
{
    // sort on digits starting from LSD all the way to MSD
    class RadixSort
    {
        public void Sort(int[] arr)
        {
            int max = GetMax(arr);

            for (int pos = 1; max / pos > 0; pos = pos * 10)
            {
                CountingSort(arr, pos);
            }            
        }
        public void CountingSort(int[] arr, int pos)
        {
            int[] count = new int[10];
            for (int j = 0; j < arr.Length; j++)
            {
                count[(arr[j] / pos) % 10]++;
            }

            for (int j = 1; j < 10; j++)
            {
                count[j]= count[j] + count[j-1];
            }

            int[] temp = new int[arr.Length];

            for (int j = arr.Length - 1; j >= 0; j--)
            {
                temp[count[(arr[j] / pos) % 10] - 1] = arr[j];
                count[(arr[j] / pos) % 10]--;
            }

            for (int j = 0; j < arr.Length; j++)
            {
                arr[j] = temp[j];
            }

        }

        private int GetMax(int[] arr)
        {
            if (arr.Length == 0)
                throw new ArgumentException("array cannot be empty");
            
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
    }
}
