using System;

namespace Caldast.AlgoLife.BitManipulation
{
    public class BitManipulation
    {

        public int Add(int x, int y)
        {
            // Iterate till there is no carry   
            while (y != 0)
            {
                // carry now contains common  
                //set bits of x and y 
                int carry = x & y;

                // Sum of bits of x and y where at  
                //least one of the bits is not set 
                x = x ^ y;

                // Carry is shifted by one so that adding 
                // it to x gives the required sum 
                y = carry << 1;
            }
            return x;
        }

        public int Subtract(int x, int y)
        {
            while (y != 0)
            {
                int borrow = (~x) & y;               
                x = x ^ y;
                y = borrow << 1;
            }

            return x;
        }

        public long Divide(int dividend, int divisor)
        {
            
            if (divisor == 0) return int.MaxValue;
            if (dividend == int.MinValue && divisor == -1) return int.MaxValue;
            if (divisor == 1) return dividend;

            int sign = ((dividend < 0) ^ (divisor < 0)) ? -1 : 1;
            long dvd = Math.Abs(dividend);
            int dvs = Math.Abs(divisor);
            int res = 0;

            long temp = 1;
            int multiple = 0;
            while (dvd >= dvs)
            {
                temp = dvs;
                multiple = 1;
                while (dvd >= (temp << 1))
                {
                    temp <<= 1;
                    multiple <<= 1;
                }
                dvd -= temp;
                res += multiple;
            }
            return sign == 1 ? res : -res;
        }
    }
}
