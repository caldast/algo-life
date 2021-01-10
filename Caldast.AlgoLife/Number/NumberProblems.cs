using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Caldast.AlgoLife.Number
{
    public class NumberProblems
    {

        public int[] GenerateNextPermutation(int[] num)
        {
            // the idea is generate next lexicographical permutation
            // in order to do so we want to increment the sequence as little as possible
            // To do so, we will have to find a digit to increment. By incrementing I mean swapping with 
            // some larger number that's already in the num since the permutation needs to be of those numbers only
            // How to find such number to increase? 
            // One way is to find the largest non-increasing suffix. Since this suffix is already the largest permutation 
            // of its own, we need to find a value immediately left of this suffix. 
            // Once we have this pivot value, we swap with the smallest number in the suffix that's larger than this pivot
            // Since we want to make this new suffix as smaller as possible, we will sort the suffix. Actually, we don't need 
            // to sort using sorting algorithm, we can simply reverse and that will take care of the sorting. why? This is because
            // our suffix was in non-increasing order and we swapped the pivot (which was less than the head element of the suffix)
            // with an smallest element in the suffix that was larger than pivot so the non-increasing order should be maintained.

            if (num == null)
            {
                throw new ArgumentNullException($"{nameof(num)}");
            }            

            int i = num.Length-1;
            while (i > 0 && num[i] <= num[i - 1])
            {
                i--;
            }
            if (i == 0) return num;
            int pivot = num[i - 1];

            int nextLargerInSuffix = FindSmallestGreaterThanValue(num, pivot, i, num.Length - 1);

            Swap(num, i - 1, nextLargerInSuffix);
            
            Reverse(num,i,num.Length-1);

            return num;
        }
      
        private int FindSmallestGreaterThanValue(int[] s, int key, int l, int r)
        {

            int index = -1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (s[mid] <= key)
                    r = mid - 1;
                else
                {
                    l = mid + 1;
                    if (index == -1 || s[index] >= s[mid])
                        index = mid;
                }
            }
            return index;
        }

       private void Reverse(int[] arr, int s, int e)
        {        
           
            while (s < e)
            {
                int temp = arr[s];
                arr[s] = arr[e];
                arr[e] = temp;
                s++;
                e--;
            }
        }

        /// <summary>
        /// Generates min number after removing n digits
        /// Time Complexity: O(n+k)
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string GenerateLowestNumber(string number, int n)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("input cannot null or empty");

            if (n == 0)
                return number;
            else if (number.Length <= n)
                return "0";
            else
            {
                var st = new Stack<char>();

                for (int i = 0; i < number.Length; i++)
                {
                    while (n > 0 && st.Count > 0 && number[i] < st.Peek())
                    {
                        st.Pop();
                        n--;
                    }

                    st.Push(number[i]);
                }


                while (n > 0)
                {
                    st.Pop();
                    n--;
                }


                var sb = new StringBuilder();
                while (st.Count > 0)
                {
                    sb.Append(st.Pop());
                }

                //reverse 
                Reverse(sb);
                return sb.ToString();
            }

        }

        private void Reverse(StringBuilder str)
        {
            if (str == null)
                return;

            int s = 0;
            int e = str.Length - 1;
            while (s < e)
            {
                char t = str[s];
                str[s] = str[e];
                str[e] = t;
                s++;
                e--;
            }
        }
        public string ConvertBase(string s, int b1, int b2)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            if (b1 < 2 || b2 < 2 || b2 > 16)
                throw new ArgumentException("Invalid base");

            bool isNeg = false;
            if (s[0] == '-')
            {
                isNeg = true;
                s = s.Substring(1);
            }

            int num = 0;
            int i = s.Length - 1;
            int pow = 1;

            while (i >= 0)
            {
                num += (char.IsDigit(s[i]) ? s[i] - '0' : s[i] - 'A' + 10) * pow;
                pow = pow * b1;
                i--;
            }

            var sb = new StringBuilder();
            i = s.Length - 1;
            while (num > 0)
            {
                char c = num % b2 >= 10 ? (char)('A' + num % b2 - 10) : (char)('0' + num % b2);
                sb.Append(c);
                num = num / b2;
            }
            string str = Reverse(sb.ToString());
            return isNeg ? "-" + str : str;
        }

        public string Reverse(string str)
        {
            int s = 0;
            int e = str.Length - 1;
            char[] cArr = str.ToCharArray();
            while (s < e)
            {
                char temp = cArr[s];
                cArr[s] = cArr[e];
                cArr[e] = temp;
                s++;
                e--;
            }
            return new string(cArr);
        }

       
        public int StringToInteger(string s)
        {
            /*
                "-12378" = -12378           
            */
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException("input cannot be null or empty");

            bool isNeg = false;
            int i = 0;

            if (s[0] == '-')
            {
                isNeg = true;
                i = 1;
            }

            int num = 0;
            while (i < s.Length)
            {
                int val = s[i] - '0';
                if (val < 0 || val > 9)
                    throw new Exception("invalid values");
                num *= 10;
                num += val;
                i++;
            }
            if (isNeg)
                num = -num;
            return num;

        }
        public bool CanFindZero(int[] arr, int startIndex, int searchValue)
        {
            if (arr == null || arr.Length == 0)
                return false;

            int[] memo = new int[arr.Length];

            Initialize(memo);

            return CanFindZeroUtil(arr, 0, memo);
        }

        private void Initialize(int[] memo)
        {
            int i = 0;
            while (i < memo.Length)
            {
                memo[i] = -1;
                i++;
            }
        }

        private bool CanFindZeroUtil(int[] arr, int startIndex, int[] memo)
        {
            if (startIndex < 0 || startIndex >= arr.Length)
                return false;

            if (arr[startIndex] == 0)
                return true;

            // if searchValue is true in the index, no need to check further
            if (memo[startIndex] != -1)
                return arr[startIndex] == 1;

            int next = arr[startIndex];

            // check right to see if we find zer
            bool right = CanFindZeroUtil(arr, startIndex + next, memo);

            memo[startIndex] = right ? 1 : 0;

            if (right) return true;

            bool left = CanFindZeroUtil(arr, startIndex - next, memo);

            // check if left side is true 
            if (memo[startIndex] == -1 || memo[startIndex] == 0)
            {
                memo[startIndex] = left ? 1 : 0;
            }

            return left || right;
        }


        private void Rightrotate(int[] arr, int n,
            int outofplace, int cur)
        {
            int tmp = arr[cur];
            for (int i = cur; i > outofplace; i--)
                arr[i] = arr[i - 1];
            arr[outofplace] = tmp;
        }

        public void Rearrange(int[] arr, int n)
        {
            int outofplace = -1;

            for (int index = 0; index < n; index++)
            {
                if (outofplace >= 0)
                {

                    if (((arr[index] >= 0) &&
                         (arr[outofplace] < 0)) ||
                        ((arr[index] < 0) &&
                         (arr[outofplace] >= 0)))
                    {
                        Rightrotate(arr, n, outofplace, index);

                        if (index - outofplace >= 2)
                            outofplace = outofplace + 2;
                        else
                            outofplace = -1;
                    }
                }

                if (outofplace == -1)
                {
                    if (((arr[index] >= 0) &&
                         ((index & 0x01) == 0)) ||
                        ((arr[index] < 0) &&
                         (index & 0x01) == 1))
                        outofplace = index;
                }
            }
        }

        public int MySqrt(int x)
        {

            int low = 0; int high = x;
            int res = 0;

            while (low <= high)
            {
                //int mid = low + (high-low)/2;
                int mid = (low + high) >> 1;

                if (mid == x / mid)
                    return mid;

                else if (mid < x / mid)
                {
                    res = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }


            }                     
            return res;
        }
        public int RomanToInt(string s)
        {
            int result = 0;
            int len = s.Length;
            int prev = 0;
            int partial = 0;
            int i = 0;

            while (i < len)
            {
                int cur = FindValue(s[i]);
                if (cur == 0)
                    throw new Exception("Invalid");

                int next = 0;
                if (i + 1 < len)
                {
                    next = FindValue(s[i + 1]);
                    if (next == 0)
                        throw new Exception("Invalid");


                }

                if (cur < next)
                {
                    if (next == cur * 5 || next == cur * 10)
                    {
                        partial = next - cur;
                        i = i + 2;
                    }
                    else
                    {
                        throw new Exception("Invalid");
                    }
                }
                else
                {
                    partial = cur;
                    i = i + 1;
                }
                result += partial;

                if (prev != 0 && prev < partial)
                    throw new Exception("Invalid");

                prev = partial;

            }
            return result;

            int FindValue(char c)
            {
                switch (c)
                {
                    case 'I':
                    case 'i':
                        return 1;
                    case 'V':
                    case 'v':
                        return 5;
                    case 'X':
                    case 'x':
                        return 10;
                    case 'L':
                    case 'l':
                        return 50;
                    case 'C':
                    case 'c':
                        return 100;
                    case 'D':
                    case 'd':
                        return 500;
                    case 'M':
                    case 'm':
                        return 1000;
                }
                return 0;
            }

        }
   

        public string IntToText(int num)
        {
            string[] ZeroToNine = { "Zero", "One", "Two", "Three", "Four", "Five", "Six",
                                    "Seven", "Eight", "Nine"};

            string[] TenToNineTeen = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
                                    "Eighteen", "Nineteen"};

            string[] Tens = { "", "", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            string[] ThousandPlus = { "", "Thousand", "Million", "Billion" };

            if (num == 0)
                return ZeroToNine[0];

            if (num < 0)
                return "Negative" + " " + IntToText(-1 * num);

            var linkedList = new LinkedList<string>();

            //if (num > 1000000000)
            //{
            //    linkedList.AddLast(Convert(num / 1000000000) + " Billion");
            //    num = num % 1000000000;
            //}
            //if (num > 1000000)
            //{
            //    linkedList.AddLast(Convert(num / 1000000) + " Million");
            //    num = num % 1000000;
            //}

            //if (num > 1000)
            //{
            //    linkedList.AddLast(Convert(num / 1000) + " Thousand");
            //    num = num % 1000;
            //}

            //linkedList.AddLast(Convert(num));

            int counter = 0;
            while (num % 1000 > 0)
            {
                linkedList.AddFirst(Convert(num % 1000) + " " + ThousandPlus[counter]);
                counter++;
                num = num / 1000;
            }
            return ListToString(linkedList);

            string ListToString(LinkedList<string> list)
            {
                var sb = new StringBuilder();
                while (list.Count > 1)
                {
                    sb.Append(list.First.Value);
                    sb.Append(" ");
                    list.RemoveFirst();
                }
                sb.Append(list.First.Value);
                list.RemoveFirst();
                return sb.ToString();
            }
            string Convert(int n)
            {
                var list = new LinkedList<string>();
                if (n >= 100)
                {
                    list.AddLast(ZeroToNine[n / 100]);
                    list.AddLast("Hundred");
                    n = n % 100;
                }

                if (n > 9 && n < 20)
                {
                    list.AddLast(TenToNineTeen[n % 10]);
                }
                else if (n >= 20)
                {
                    list.AddLast(Tens[n / 10]);
                    n = n % 10;
                }
                if (n > 0 && n < 10)
                {
                    list.AddLast(ZeroToNine[n]);
                }

                return ListToString(list);
            }
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (dict.ContainsKey(diff))
                {
                    return new int[] { dict[diff], i };
                }
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
            throw new Exception("target not found");
        }

        public int Reverse(int x)
        {
            int result = 0;
            bool isNegative = false;
            if (x < 0)
            {
                isNegative = true;
                x = -x;
            }
            while (x > 0)
            {
                int currDigit = x % 10;
                if ((int.MaxValue - currDigit) / 10 < result)
                {
                    // overflow
                    return 0;
                }
                result = result * 10 + currDigit;
                x = x / 10;
            }
            if (isNegative)
            {
                result = -result;
            }
            return result;
        }
        public void Permute(int[] arr, int start, int end)
        {
            if (start == end)
            {
                int i = 0;
                while (i < arr.Length)
                {
                    Console.Write(arr[i] + " ");
                    i++;
                }
                Console.WriteLine("");
            }

            for (int i = start; i <= end; i++)
            {

                Swap(arr, start, i);
                Permute(arr, start + 1, end);
                Swap(arr, start, i);

            }

        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public int GetMissingNumberMethod_Sum(int[] a, int n)
        {
            if (a == null || a.Length == 0)
            {
                throw new ArgumentException("cannot be null or empty");
            }

            int sum = (n * (n + 1)) / 2;

            int first = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                first += a[i];
            }

            return sum - first;
        }

        public bool IsMatch(string binary, string hex)
        {
            int d1 = ConvertToDec(binary, 2);
            int d2 = ConvertToDec(hex, 16);
            if (d1 < 0 || d2 < 0)
                return false;
            return d1 == d2;
        }

        int ConvertToDec(string input, int b)
        {
            if (string.IsNullOrEmpty(input))
                return -1;

            int len = input.Length;
            int result = 0;

            for (int i = len - 1; i >= 0; i--)
            {
                result += CharLookup(input[i]) * (int)Math.Pow(b, len - 1 - i);
            }
            return result;
        }

        int CharLookup(char c)
        {
            switch (c)
            {
                case 'A':
                case 'a':
                    return 10;
                case 'B':
                case 'b':
                    return 11;
                case 'C':
                case 'c':
                    return 12;
                case 'D':
                case 'd':
                    return 13;
                case 'E':
                case 'e':
                    return 14;
                case 'F':
                case 'f':
                    return 15;
                default:
                    return (int)c - '0';
            }
        }
    }

}
