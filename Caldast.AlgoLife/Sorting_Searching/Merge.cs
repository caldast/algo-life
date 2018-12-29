namespace Caldast.AlgoLife
{
    class MergeSort
    {

        public void Sort(int[] a, int leftStart, int rightEnd) {
            if (leftStart < rightEnd) {
                int mid = (leftStart + rightEnd) / 2;
                Sort(a, leftStart, mid);
                Sort(a, mid + 1, rightEnd);
                Merge(a, leftStart, mid, rightEnd);
            }
        }

        public void Merge(int [] a, int leftStart, int mid, int rightEnd) {
           
            int sizeOfLeftArray = mid - leftStart + 1;
            int sizeOfRightArray = rightEnd - mid;

            int[] leftArray = new int[sizeOfLeftArray];
            int[] rightArray = new int[sizeOfRightArray];

            int i = 0;
            int j = 0;
            for (i = 0; i < sizeOfLeftArray; i++) {
                leftArray[i] = a[leftStart + i];
            }
            for (j = 0; j < sizeOfRightArray; j++)
            {
                rightArray[j] = a[mid + 1+j];
            }
            //leftArray[sizeOfLeftArray] = int.MaxValue;
            //rightArray[sizeOfRightArray] = int.MaxValue;

            i = 0;
            j = 0;
            for (int k=leftStart; k < rightEnd+1; k++)
            {
                if (i == sizeOfLeftArray)
                {
                    while (j < sizeOfRightArray)
                    {
                        a[k] = rightArray[j];
                        j++;
                        k++;
                    }
                    break;
                }
                else if (j == sizeOfRightArray)
                {
                    while (i < sizeOfLeftArray)
                    {
                        a[k] = leftArray[i];
                        i++;
                        k++;
                    }
                    break;
                }
                if (leftArray[i] <= rightArray[j])
                {
                    a[k] = leftArray[i];
                    i++;
                }
                else {
                    a[k] = rightArray[j];
                    j++;
                }
                
            }

        }

    }
}
