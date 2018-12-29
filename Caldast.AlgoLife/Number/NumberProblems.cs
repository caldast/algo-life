using System;
using System.Collections.Generic;
using System.Text;

namespace Caldast.AlgoLife.Number
{
    public class NumberProblems
    {
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

                else if (mid < x/mid)
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

            while(i < len)
            {
                int cur = FindValue(s[i]);
                if (cur == 0)
                    throw new Exception("Invalid");              

                int next = 0;
                if (i + 1 < len)
                {
                    next = FindValue(s[i+1]);
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

                if (prev!=0 && prev < partial)
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
                result += CharLookup(input[i]) * (int) Math.Pow(b, len - 1 - i);
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
                    return (int) c-'0';
            }
        }
    }

}
