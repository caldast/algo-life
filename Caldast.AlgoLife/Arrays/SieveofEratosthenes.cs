using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.Arrays
{
    public class SieveofEratosthenes
    {
        /// <summary>
        /// Time Complexity: O(n log logn)
        /// Space Complexity: O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<int> FindPrimes(int n)
        {
            int size = n + 1;
            bool[] isPrime = new bool[size];

            for (int i = 2; i < size; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i * i < size; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j < size; j = j + i)
                    {
                        isPrime[j] = false;

                    }
                }
            }

            var output = new List<int>();

            for (int i = 2; i < size; i++)
            {
                if (isPrime[i])
                    output.Add(i);
            }
            return output;
        }

        public List<int> FindPrimesUsingOdd(int n)
        {
            List<int> primes = new List<int>();
            if (n < 2)
            {
                return primes;
            }
            primes.Add(2);

            int size = (n - 3) / 2 + 1; //excluding 0,1,2 

            bool[] isPrime = new bool[size];
            for (int i = 0; i < size; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 0; i < size; i++)
            {
                if (isPrime[i])
                {
                    int p = 2 * i + 3;
                    primes.Add(p);

                    for (long j = ((i * i) * 2) + 6 * i + 3; j < size; j += p)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            return primes;

        }
        public List<int> FindPrimesUsingSegmentedSieve(int n)
        {
            // Find primes from 2 to √n

            int root = (int)Math.Sqrt(n);
            List<int> primes = FindPrimes(root);

            var outputList = new List<int>();

            outputList.AddRange(primes);

            // Range [l,r]
            int l = root + 1;
            int r = l + root;


            while (l < n)
            {

                if (r >= n)
                    r = n;

                bool[] isPrime = new bool[r - l + 1];

                for (int i = 0; i < r - l + 1; i++)
                {
                    isPrime[i] = true;
                }

                for (int i = 0; i < primes.Count; i++)
                {
                    int prime = primes[i];

                    int @base = (l / prime) * prime;

                    if (@base < l)
                    {
                        @base = @base + prime;
                    }

                    for (int j = @base; j <= r; j += prime)
                    {
                        isPrime[j - l] = false;
                    }
                    if (@base == prime)
                    {
                        isPrime[@base - l] = true;
                    }
                }

                for (int i = 0; i < r - l + 1; i++)
                {
                    if (isPrime[i])
                    {
                        outputList.Add(i + l);
                    }
                }

                l = l + root + 1;
                r = r + root + 1;
            }

            return outputList;
        }


        /// <summary>
        /// Finds prime in the range <paramref name="left"/> and <paramref name="right"/>, both inclusive.
        /// The idea is to iterate primes in the 2 - √n and mark their multiples 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public List<int> FindPrimesInRange(int left, int right)
        {
            // Find primes from 2 to √n
            int root = (int)Math.Sqrt(right);
            List<int> primes = FindPrimes(root);

            int size = right - left + 1;

            // Create bool array 

            bool[] segment = new bool[size];

            // Populate with true 

            for (int i = 0; i < size; i++)
            {
                segment[i] = true;
            }

            // Iterate prime list
            for (int i = 0; i < primes.Count; i++)
            {
                // Get prime from prime list to start with

                int prime = primes[i];

                int @base = (left / prime) * prime;

                // Adjust base in case it's lower than left

                if (@base < left)
                {
                    @base = @base + prime;
                }

                // Map prime to segment array and set it's multiples to false

                for (int j = @base; j <= right; j = j + prime)
                {
                    segment[j - left] = false;
                }

                // If base is equal to prime, we reset is back to true since it's a prime

                if (@base == prime)
                {
                    segment[@base - left] = true;
                }
            }

            var output = new List<int>();
            for (int i = 0; i < size; i++)
            {
                if (segment[i])
                {
                    output.Add(i + left);
                }

            }
            return output;
        }
    }
}
