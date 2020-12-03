namespace Caldast.AlgoLife
{
    internal class HeapSort
    {
        internal void Sort(int [] arr)
        {
            BuildMaxHeap(arr);
            for (int i = arr.Length - 1; i > 0; i--)
            {
                // put max heap at the end of array
                Swap(arr,i, 0);
                MaxHeapify(arr, 0, i-1);
            }
        }
        private void BuildMaxHeap(int[] arr)
        {
            int len = arr.Length;
            for (int i = arr.Length/2-1; i >= 0; i--)
            {
                MaxHeapify(arr, i, len);
            }
        }

        private void MaxHeapify(int[] arr, int node, int heapSize)
        {
            int left = 2 * node + 1;
            int right = 2 * node + 2;
            int largest = node;

            // find the largest 
            if (left < heapSize && arr[left] > arr[node])
                largest = left;

            if (right < heapSize && arr[right] > arr[largest])
                largest = right;

            if (node != largest)
            {
                Swap(arr, node, largest);
                MaxHeapify(arr,largest,heapSize);
            }
        }

        private void Swap(int [] arr,int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
