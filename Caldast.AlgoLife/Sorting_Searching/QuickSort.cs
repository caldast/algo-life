using System;
using System.Text;

namespace Caldast.AlgoLife
{
   public class QuickSort
    {
        public static void SortRecursive(int[] a, int p, int r)
        {
            Console.Write($"\na= {ToString(a)}, p= {p}, q= {r}");
            if (p < r)
            {
                int q = HoarePartition(a, p, r);
                SortRecursive(a, p, q);
                SortRecursive(a, q + 1, r);
            }

        }
        public static void SortIterative(int[] a, int l, int r)
        {
            int[] stack = new int[r - l + 1];

            int top = -1;

            stack[++top] = l;
            stack[++top] = r;
            int p = 0;
            while (top >= 0)
            {
                r = stack[top--];
                l = stack[top--];

                p = LomutoPartition(a, l, r);

                if (p - 1 > l)
                {
                    stack[++top] = l;
                    stack[++top] = p - 1;
                }


                if (p + 1 <r)
                {
                    stack[++top] = p+1;
                    stack[++top] = r;
                }
            }
            
        }
        private static int LomutoPartition(int[] a, int l, int r)
        {
            int p = a[r];
            int i = l - 1;
            for (int j = l; j <= r - 1; j++)
            {
                if (a[j] <= p)
                {
                    i = i + 1;
                    Swap(a, i, j);
                }
            }
            Swap(a, i + 1, r);
            return i + 1;
        }

        public static int HoarePartition(int[] a, int p, int r) {
            int partition = a[p];
            int i = p - 1;
            int j = r+1;
            while (i<j)
            {
                do
                {
                    i++;
                } while (a[i] < partition);
                do
                {
                    j--;
                } while (a[j] > partition);
               
                if (i<j)
                {
                    Swap(a, i, j);
                }                
            }
            //Swap(a, p, j);
            return j;

        }

        private static void Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        private static string ToString(int[] arr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int element in arr)
            {
                sb.Append(element);
            }
            return sb.ToString();
        }
    }
    class QuickSortByMedianOf3
    {
        public static void Sort(int[] a, int l, int r)
        {
            var size = r - l;
            if (size <= 3)
            {
                ManualSort(a, l, r);
            }
            else {
                int median = MedianOf3(a, l, r);
                int partition = HoarePartition(a, median,r);
                Sort(a, l, partition);
                Sort(a, partition + 1, r);
            }
        }

        public static int MedianOf3(int [] a, int left, int right)
        {
            int center = (left + right) / 2;
            // order left & center
            if (a[left] > a[center])
                Swap(a,left, center);
            // order left & right
            if (a[left] > a[right])
                Swap(a,left, right);
            // order center & right
            if (a[center] > a[right])
                Swap(a,center, right);

            return center;
        }
        private static int HoarePartition(int[] a, int p, int r)
        {
            int partition = a[p];
            int i = p - 1;
            int j = r + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (a[i] < partition);
                do
                {
                    j--;
                } while (a[j] > partition);

                if (i >= j)
                {
                    return j;
                }
                Swap(a, i, j);
            }
        }

        public static int Partition(int [] a, int left, int right, long pivot)
        {
            int leftPtr = left; // right of first elem
            int rightPtr = right - 1; // left of pivot

            while (true)
            {
               
                while (a[++leftPtr] < pivot);               
                while (a[--rightPtr] > pivot);
                if (leftPtr >= rightPtr) // if pointers cross, partition done
                    break;
                else
                    // not crossed, so
                    Swap(a,leftPtr, rightPtr); // swap elements
            }
            Swap(a,leftPtr, right - 1); // restore pivot
            return leftPtr; // return pivot location
        }

        private static void ManualSort(int [] a, int left, int right)
        {
            int size = right - left + 1;
            if (size <= 1)
                return; // no sort necessary
            if (size == 2)
            { // 2-sort left and right
                if (a[left] > a[right])
                    Swap(a,left, right);
                return;
            }
            else // size is 3
            { // 3-sort left, center, & right
                if (a[left] > a[right - 1])
                    Swap(a,left, right - 1); // left, center
                if (a[left] > a[right])
                    Swap(a,left, right); // left, right
                if (a[right - 1] > a[right])
                    Swap(a,right - 1, right); // center, right
            }
        }
        private static void Swap(int[] a, int l, int r)
        {
            int temp = a[l];
            a[l] = a[r];
            a[r] = temp;
        }
    }
}
