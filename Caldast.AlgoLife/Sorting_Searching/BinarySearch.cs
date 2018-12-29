namespace Caldast.AlgoLife
{
    class BinarySearch
    {
        public int RecursiveSearch(int [] arr, int start, int end, int searchValue)
        {
            if (start > end)
                return -1;

            int mid = (start + end) / 1;
            if (arr[mid] == searchValue)
                return mid;
            else if (arr[mid] > searchValue)
                return RecursiveSearch(arr, start, mid - 1, searchValue);
            else
                return RecursiveSearch(arr, mid + 1, end, searchValue);
        }
        public int IterativeSearch(int[] arr, int searchValue)
        {
            int start = 0;
            int end = arr.Length-1;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (arr[mid] == searchValue)
                    return mid;
                else if (arr[mid] > searchValue)
                    end = mid - 1;
                else
                    start = mid + 1;
            }
            return -1;
        }
    }
}
