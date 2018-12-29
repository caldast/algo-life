using System;

namespace Caldast.AlgoLife
{
    class MongeArray
    {
        public void DivideAndConquereMonge(int[][] matrizMonge, int[] leftmost, int rows, int factor, int column)
        {

            if (rows == 1)
                leftmost[0] = FindMin(matrizMonge[0], 0, column);
            else
            {

                int mid = (int)  Math.Ceiling(rows/2.0);
                DivideAndConquereMonge(matrizMonge, leftmost, mid, 2 * factor, column);

                for (int i = 1; i < rows - 1; i += 2)
                {
                    int dev = factor * i, end = leftmost[dev + factor] + 1;
                    leftmost[dev] = FindMin(matrizMonge[dev], leftmost[dev - factor], end);
                }

                if (rows % 2 == 0)
                {
                    int dev = factor * (rows - 1);
                    leftmost[dev] = FindMin(matrizMonge[dev], leftmost[dev - factor], column);
                }
            }
        }
        int FindMin(int[] array, int init, int finale)
        {
            int index = 0;

            for (int min = int.MaxValue; init < finale; ++init)
            {
                if (min > array[init])
                {
                    min = array[init];
                    index = init;
                }
            }
            return index;
        }

    }
}
