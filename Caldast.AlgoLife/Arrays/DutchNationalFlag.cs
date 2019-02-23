using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caldast.AlgoLife.Arrays
{
    class DutchNationalFlag
    {        
        public void Rearrange(int[] arr, int index)
        {
            if (arr == null)
                throw new Exception("input cannot be null");
            int l = 0;
            int m = 0;
            int h = arr.Length - 1;
            int p = arr[index];

            while (m <= h)
            {
                if (arr[m] < p)
                {
                    Swap(arr, m, l);
                    m++;
                    l++;
                }
                else if (arr[m] > p)
                {
                    Swap(arr, m, h);
                    h--;
                }
                else m++;
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
