namespace Caldast.AlgoLife
{
    class MaxContiniousSubArray
    {

        public dynamic FindUsingBruteForce(int[] a) {
            int n = a.Length;
            int maxSum = n > 0 ? int.MinValue : 0;
            int sum = 0;
            int leftStart = 0;
            int rightEnd = 0;

            for (int i = 0; i < n; i++) {
                sum = a[i];
                if (sum > maxSum) {
                    maxSum = sum;
                }
                for (int j = i + 1; j < n; j++) {
                    sum = sum + a[j];
                    if (sum > maxSum) {
                        maxSum = sum;
                        leftStart = i;
                        rightEnd = j;
                    }
                }
            }
            return new { MaxSum = maxSum, LeftIndex = leftStart, RightIndex = rightEnd };
        }

        public dynamic Find(int[] a) {
            int n = a.Length;
            int maxSum = n > 0 ? int.MinValue : 0;
            int result = 0;
            int leftStart = 0;
            int rightEnd = 0;
            int tempPointer = 0;
            for (int i = 0; i < n; i++) {
                result = result + a[i];
                if (result > maxSum) {
                    maxSum = result;  
                    leftStart = tempPointer;
                    rightEnd = i;
                }
                if (result < 0) {
                    result = 0;
                    tempPointer = i + 1;
                }
            }
            return new { MaxSum = maxSum, LeftIndex = leftStart, RightIndex = rightEnd };
        }
    }
}
