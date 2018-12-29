using System.Collections.Generic;

namespace Caldast.AlgoLife
{
    class BucketSort
    {
        public void Sort(int [] arr)
        {
            // create buckets based on number of elements
            var buckets = new List<int>[arr.Length];

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            // insert into bucket using a hash function
            for (int i = 0; i < arr.Length; i++)
            {               
                buckets[FindMSB(arr[i])].Add(arr[i]);
            }

            // perform insertion sort on each list 

            for (int i = 0; i < buckets.Length; i++)
            {
                // buckets[i] = new List<int>();
                buckets[i].Sort();
            }

            // combine buckets
            
            int k = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    arr[k++] = buckets[i][j];
                }
            }

        }

        private int FindMSB(int number)
        {
            int msb = 0;
            for (int i = 1; number / i > 0; i=i*10)
            {
                msb = (number / i) % 10;
            }
            return msb;
        }
    }
}
