namespace Caldast.AlgoLife.Sorting
{
    class BubbleSort
    {
        public void Sort(int[] arr)
        {
            bool swapped = false;
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        Swap(arr, i, j);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }
        void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;            
        }
    }
}
