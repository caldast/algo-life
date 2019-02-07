using System;
using System.Security.Cryptography;

namespace Caldast.AlgoLife
{
    public class MergeSort
    {

        public void Sort(int[] A, int start, int end)
        {
            if (start < end)
            {
                int m = start + (end - start) / 2;
                Sort(A, start, m);
                Sort(A, m + 1, end);
                Merge(A, start, m, end);
            }
        }

        private void Merge(int[] A, int start, int mid, int end)
        {
            int left = mid - start + 1;
            int right = end - mid;
            int []leftArr = new int[left+1];
            int [] rightArr = new int[right+1];

            int i = 0;
            int j = 0;
            for (i = 0; i < left; i++)
            {
                leftArr[i] = A[start + i];
            }
            for (j = 0; j < right; j++)
            {
                rightArr[j] = A[mid + j+1];
            }

            leftArr[left] = int.MaxValue;
            rightArr[right] = int.MaxValue;
            i = 0;
            j = 0;
            for (int k = start; k <= end; k++)
            {
                
                if (leftArr[i] <= rightArr[j])
                    A[k] = leftArr[i++];
                else
                    A[k] = rightArr[j++];
               

            }
        }
    }
}



