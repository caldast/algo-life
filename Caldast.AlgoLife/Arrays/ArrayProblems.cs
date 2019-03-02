using System;
using System.Collections.Generic;
using System.Text;

namespace Caldast.AlgoLife.Arrays
{
    public class ArrayProblems
    {
        /// <summary>
        /// Gets spiral order of the 2D m x n array without modifying input.
        /// Time Complexity: O(mn)
        /// Space Complexity: O(mn)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int[] GetSpiralOrder(int[,] a)
        {
            if (a == null)
            {
                throw new ArgumentException("input cannot be null");
            }
            int m = a.GetLength(0);
            int n = a.GetLength(1);

            int size = m*n;
            int[] output = new int[size];
            int offset = 0;
            int count = 0;

            while (count < size)
            {               
                // square matrix and odd size
                if (m == n && offset == m - offset - 1)
                {
                    output[count++] = a[offset, offset];
                    break;
                }

                // traverse the first row
                for (int i = offset; i < n - offset - 1; i++)
                {
                    output[count++] = a[offset,i];
                }

                // traverse the right-most row 
                for (int i = offset; i < m-offset-1; i++)
                {
                    output[count++] = a[i, n - offset - 1];
                }

                // traverse the bottom-most row 
                for (int i = n-offset-1; i>offset; i--)
                {
                    output[count++] = a[m - offset - 1,i];
                }

                // traverse the left-most row 
                for (int i = m - offset - 1; i > offset; i--)
                {
                    output[count++] = a[i,offset];
                }

                offset++;
            }

           
            return output;
        }
      

        internal static void PrintAllSolutionsToEquation()
        {
            int n = 10;
            Dictionary<double, List<Pair>> map = new Dictionary<double, List<Pair>>();
            for (int a = 1; a <= n; a++)
            {
                for (int b = 1; b <= n; b++)
                {
                    double result = Math.Pow(a, 3) + Math.Pow(b, 3);
                    var pair = new Pair(a, b);
                    if (map.ContainsKey(result))
                    {
                        map[result].Add(pair);
                    }
                    else
                    {
                        map.Add(result, new List<Pair>() { pair });
                    }


                }
            }

            foreach (var pairs in map.Values)
            {

                foreach (var pair1 in pairs)
                {
                    foreach (var pair2 in pairs)
                    {
                        Console.WriteLine($"{pair1.First},{pair1.Second}, {pair2.First}, {pair2.Second}");
                    }
                }
                Console.Write(Environment.NewLine);

            }

        }
        
        public void Rotate(int[,] m)
        {
            int n = m.GetLength(0);
            int innerL = 0;
            for (int i = 0; i < n / 2; i++)
            {
                innerL = n - 1 - i;
                for (int j = i; j < innerL; j++)
                {
                    int temp = m[j,i];
                    m[j, i] = m[i, innerL - j+i];

                    m[i, innerL - j+i] = m[innerL - j+i, innerL];

                    m[innerL - j+i, innerL] = m[innerL, j];
                    m[innerL, j] = temp;

                }
            }
            
        }

        public int GetMedian(int[] ar1,
                         int[] ar2,
                         int n)
        {
            int i = 0;
            int j = 0;
            int count;
            int m1 = -1, m2 = -1;

            // Since there are 2n elements,  
            // median will be average of  
            // elements at index n-1 and n in  
            // the array obtained after  
            // merging ar1 and ar2 
            for (count = 0; count <= n; count++)
            {
                // Below is to handle case  
                // where all elements of ar1[]   
                // are smaller than smallest 
                // (or first) element of ar2[]  
                if (i == n)
                {
                    m1 = m2;
                    m2 = ar2[0];
                    break;
                }

                /* Below is to handle case where all  
                elements of ar2[] are smaller than  
                smallest(or first) element of ar1[] */
                else if (j == n)
                {
                    m1 = m2;
                    m2 = ar1[0];
                    break;
                }

                if (ar1[i] < ar2[j])
                {
                    // Store the prev median  
                    m1 = m2;
                    m2 = ar1[i];
                    i++;
                }
                else
                {
                    // Store the prev median  
                    m1 = m2;
                    m2 = ar2[j];
                    j++;
                }
            }

            return (m1 + m2) / 2;
        }
        public int GetMedianRecursive(int[] A, int[] B)
        {
            if (A.Length != B.Length)
            {
                throw new Exception("Cannot find median for different size arrays");
            }
            return GetMedianRecursiveUtil(A, B, 0, A.Length - 1, 0, B.Length - 1);
        }
        public int GetMedianRecursiveUtil(int[] A, int[] B, int aStart, int aEnd, int bStart, int bEnd)
        {
            int n = aEnd - aStart + 1;
            if (n == 2)
            {
                return (Math.Max(A[aStart], B[bStart]) + Math.Min(A[aEnd], B[bEnd])) / 2;
            }
            int m1 = FindMedian(A,aStart,aEnd);
            int m2 = FindMedian(B, bStart, bEnd);
            if (m1 == m2)
                return m1;
            else if (m1 > m2)
            {
                if (n % 2 == 0)
                {
                    return GetMedianRecursiveUtil(A, B, aStart, n / 2, bStart + n / 2 - 1, bEnd);
                }
                return GetMedianRecursiveUtil(A, B, aStart, n / 2, bStart + n / 2, bEnd);
            }
            else
            {
                if (n % 2 == 0)
                {
                    return GetMedianRecursiveUtil(A, B, aStart + n / 2 - 1, aEnd, bStart, n / 2);
                }

                return GetMedianRecursiveUtil(A, B, aStart + n /2 , aEnd, bStart, n / 2);

            }
            
        }

        public double FindMedian1(int[] A, int[] B, int n, int m)
        {
            int minIndex = 0;
            int maxIndex = n;

            double median = 0;

            int i = 0;
            int j = 0;

            while (minIndex <= maxIndex)
            {
                i = (minIndex + maxIndex) / 2;
                j = ((m + n + 1) / 2) -i ;

                if (i > 0 && j < m && B[j] < A[i - 1])
                {
                    maxIndex = maxIndex - 1;
                }

                else if (j > 0 && i < n && A[i] < B[j - 1])
                {
                    minIndex = i + 1;
                }
                else
                {
                    if (i == 0)
                    {
                        median = B[j - 1];
                        break;
                    }
                    else if (j == 0)
                    {
                        median = A[i - 1];
                        break;
                    }
                    
                    else
                    {
                        median = Math.Max(A[i - 1], B[j - 1]);
                        break;
                    }
                }
            }

            if (i == n)
            {
                median = (median + B[j])/2.0;
            }
            else if (j == m)
            {
                median = (median + A[i])/2.0;
            }

            else if ((m + n) % 2 == 0)
            {
                return (Math.Min(A[i], B[j]) + median) / 2.0;
            }
            return median;

        }

        public double FindMedianSortedArrays(int[] A, int[] B, int n,int m)
        {

            int min_index = 0,
            max_index = n, i = 0,
            j = 0, median = 0;

            while (min_index <= max_index)
            {
                i = (min_index + max_index) / 2;
                j = ((n + m + 1) / 2) - i;

                // if i = n, it means that Elements  
                // from a[] in the second half is an  
                // empty set. and if j = 0, it means  
                // that Elements from b[] in the first 
                // half is an empty set. so it is  
                // necessary to check that, because we 
                // compare elements from these two  
                // groups. Searching on right 
                if (i < n && j > 0 && B[j - 1] > A[i])
                    min_index = i + 1;

                // if i = 0, it means that Elements 
                // from a[] in the first half is an  
                // empty set and if j = m, it means  
                // that Elements from b[] in the second 
                // half is an empty set. so it is  
                // necessary to check that, because  
                // we compare elements from these two 
                // groups. searching on left 
                else if (i > 0 && j < m && B[j] < A[i - 1])
                    max_index = i - 1;

                // we have found the desired halves. 
                else
                {
                    // this condition happens when we  
                    // don't have any elements in the  
                    // first half from a[] so we 
                    // returning the last element in  
                    // b[] from the first half. 
                    if (i == 0)
                        median = B[j - 1];

                    // and this condition happens when  
                    // we don't have any elements in the 
                    // first half from b[] so we  
                    // returning the last element in  
                    // a[] from the first half. 
                    else if (j == 0)
                        median = A[i - 1];
                    else
                        median = Math.Max(A[i - 1],
                        B[j - 1]);
                    break;
                }
            }

            // calculating the median. 
            // If number of elements is odd  
            // there is one middle element. 
            if ((n + m) % 2 == 1)
                return (double)median;

            // Elements from a[] in the  
            // second half is an empty set.  
            if (i == n)
                return (median + B[j]) / 2.0;

            // Elements from b[] in the 
            // second half is an empty set. 
            if (j == m)
                return (median + A[i]) / 2.0;

            return (median + Math.Min(A[i],
            B[j])) / 2.0;
        }

        private int FindMedian(int[] A, int s, int e)
        {
            int n = e - s + 1;
            if (n % 2 == 0)
            {
                return A[n / 2 - 1 + s];
            }
            return A[n / 2 + s];
        }       

        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            int j = 0;

            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    j = i + 1;
                    while (j < nums.Length && val == nums[j])
                    {
                        j++;
                    }
                    Console.WriteLine(j);
                    if (j == nums.Length)
                    {
                        return i;
                    }
                    else
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }

                }
            }
            Console.WriteLine(i);
            return i;
        }
        //public int Multiply(int[] a, int[] b)
        //{
        //    if (a == null || b == null)
        //        throw new ArgumentNullException("Input value cannot be null");

        //    int result = 0; 
        //    for (int i = b.Length-1, counter = 1; i >=0; i--, counter*=10)
        //    {
        //        int carry = 0;
        //        int partialResult = 0;
        //        int place = 1; 
        //        for (int j = a.Length-1; j >=0; j--, place *= 10)
        //        {
        //            int prod = (b[i] * a[j]) + carry;
        //            int value = prod % 10;
        //            carry = prod / 10;
        //            partialResult += value * place;
        //        }
        //        if (carry == 1)
        //        {
        //            partialResult += place * 10;
        //        }
        //        result += counter * partialResult;
        //    }
        //    return result;
        //}
        public int Multiply(int[] a, int[] b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Input value cannot be null");

            int res = 0, i, j, mcol, mrow;
            for (mcol = 1, i = a.Length - 1; i >= 0; i--, mcol *= 10)
            {
                for (mrow = 1, j = b.Length - 1; j >= 0; j--, mrow *= 10)
                {
                    res += a[i] * b[j] * mcol * mrow;
                }
            }
            return res;
        }
        public int Min2(int[] arr)
        {
            int first = arr[0];
            int second = arr[1];

            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] < first)
                {
                    second = first;
                    first = arr[i];
                }
                else if (arr[i] < second)
                    second = arr[i];

            }
            return second;
        }

        public List<List<int>> AllSubsets(int[] arr)
        {

            return AllSubsetsHelper(arr, arr.Length);

        }

        private List<List<int>> AllSubsetsHelper(int[] arr, int n)
        {
            List<List<int>> list = null;
            if (n == 0)
            {
                list = new List<List<int>>();
                list.Add(new List<int>());
                return list;
            }

            list = AllSubsetsHelper(arr, n - 1);
            var subset = new List<List<int>>();
            foreach (var lst in list)
            {
                List<int> temp = new List<int>();
                temp.AddRange(lst);
                temp.Add(n);
                subset.Add(temp);
            }
            list.AddRange(subset);
            return list;
        }
        public void TowersOfHanoiRecursive(Stack<int> src, Stack<int> aux, Stack<int> dest)
        {
            char s = 'S', a = 'A', d = 'D';            
            TowersOfHanoiRecursiveHelper(src.Count, src, aux, dest, s, a, d);
        }

        private void TowersOfHanoiRecursiveHelper(int n, Stack<int> src, Stack<int> aux, Stack<int> dest, char s, char a, char d)
        {           
            if (n > 0)
            {
                TowersOfHanoiRecursiveHelper(n - 1, src, dest, aux, s, d, a);
                Console.WriteLine($"Moved from {s} to {d}");
                MoveDisk(src, dest, s, d);
                TowersOfHanoiRecursiveHelper(n - 1, aux, src, dest, a, s, d);
            }
        }
        private string Print(Stack<int> stack)
        {
            var sb = new StringBuilder();
            sb.Append("[ ");
            foreach (var s in stack)
            {
                sb.Append(s);
            }
            sb.Append(" ]");
            return sb.ToString();

        }
        public void TowersOfHanoiIterative(Stack<int> src, Stack<int> aux, Stack<int> dest)
        {
            char s = 'S', a = 'A', d = 'D';
            int n = (int)Math.Pow(2, src.Count) - 1;
            if (n % 2 == 0)
            {
                Stack<int> temp = aux;
                aux = dest;
                dest = temp;
            }
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 1)
                    MoveDisk(src, dest, s, d);
                else if (i % 3 == 2)
                    MoveDisk(src, aux, s, a);
                else if (i % 3 == 0)
                    MoveDisk(aux, dest, a, d);
            }
        }
        private void MoveDisk(Stack<int> src, Stack<int> dest, char s, char d)
        {
            if (src.Count == 0)
            { 
                Console.WriteLine($"Moved From = {d} to {s}");
                src.Push(dest.Pop());
                return;
            }
            if (dest.Count == 0)
            {
                dest.Push(src.Pop());
                Console.WriteLine($"Moved From = {s} to {d}");
                return;
            }

            if (src.Peek() > dest.Peek())
            {
                Console.WriteLine($"Moved From = {d} to {s}");
                src.Push(dest.Pop());
            }
            else
            {
                Console.WriteLine($"Moved From = {s} to {d}");
                dest.Push(src.Pop());
            }
        }

        private void MoveDisk(int n, Stack<int> src, Stack<int> dest, char s, char d)
        {
            if (src.Count == 0)
            {
                Console.WriteLine($"Moved From = {d} to {s}");
                src.Push(dest.Pop());
                return;
            }
            if (dest.Count == 0)
            {
                dest.Push(src.Pop());
                Console.WriteLine($"Moved From = {s} to {d}");
                return;
            }

            if (src.Peek() > dest.Peek())
            {
                Console.WriteLine($"Moved From = {d} to {s}");
                src.Push(dest.Pop());
            }
            else
            {
                Console.WriteLine($"Moved From = {s} to {d}");
                dest.Push(src.Pop());
            }
        }

        
    }

    internal class Pair
    {
        public int First { get; set; }
        public int Second { get; set; }
        public Pair(int _first, int _second)
        {
            First = _first;
            Second = _second;
        }
        public override string ToString()
        {
            return $"({First},{Second})";
        }
    }
}
