namespace Caldast.AlgoLife
{
    public class NumMatrix
    {
        int[,] A = null;
        public NumMatrix(int[][] matrix)
        {
            if (matrix == null || matrix[0].Length == 0)
                return;

            A = new int[matrix.Length + 1, matrix[0].Length + 1]; 
            
            for (int i = 1; i < A.GetLength(0); i++)
            {
                for (int j = 1; j < A.GetLength(1); j++)
                {
                    A[i,j] = matrix[i - 1][j - 1] + A[i,j - 1] + A[i - 1,j] - A[i - 1,j - 1];
                }
            }

        }

       

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            if (A == null)
            {
                throw new System.Exception("matrix is null");
            }
            ++row1;
            ++row2;
            ++col1;
            ++col2;
            return A[row2,col2] - A[row2,col1 - 1] - A[row1 - 1,col2] + A[row1 - 1,col1 - 1];
        }
    }
    public class NumArray
    {
        int[] A = null;
        public NumArray(int[] nums)
        {

            if (nums == null || nums.Length == 0)
                return;

            A = new int[nums.Length + 1];

            for (int i = 1; i < A.Length; i++)
            {
                A[i] = A[i - 1] + nums[i - 1];
            }
        }

        public int SumRange(int i, int j)
        {
            i++;
            j++;
            return A[j] - A[i - 1];
        }
    }
}
