namespace Caldast.AlgoLife.Sorting_Searching
{
    public class SelectionSort
    {
        /// <summary>
        /// Selction Sort. 
        /// Time Complexity=> Worst: O(n^2) (when sorted in non-increasing), Best: O(n) (when sorted in non-decreasing).
        /// Space  Complexity=> O(1).
        /// Stable=> Yes.
        /// </summary>
        /// <param name="arr"></param>
        public void Sort(int[] arr)
        {
            if(arr == null)
                return;

            int i = 0;
            while (i < arr.Length - 1)
            {
                int j = i + 1;
                int key = arr[j];
                while (j > 0 && key < arr[j-1])
                {
                    arr[j] = arr[j - 1];
                    j--;
                }

                arr[j] = key;
                i++;
            }
        }
    }
}
