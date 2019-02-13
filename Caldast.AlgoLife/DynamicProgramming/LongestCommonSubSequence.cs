using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.DynamicProgramming
{
    public class LongestCommonSubSequence
    {
        public int FindLcsLength_Recursive(int[] A, int[] B)
        {
            return FindLcsLength_Recursive(A, B, 0, 0);
        }

        private int FindLcsLength_Recursive(int[] A, int[] B, int i, int j)
        {
            if (i == A.Length || j == B.Length)
                return 0;

            int inc = 0;
            if (A[i] == B[j])
            {
                inc = 1 + FindLcsLength_Recursive(A, B, i + 1, j + 1);
            }

            int exc = Math.Max(FindLcsLength_Recursive(A, B, i, j + 1), FindLcsLength_Recursive(A, B, i + 1, j));
            return Math.Max(inc, exc);
        }

        public int FindLcsLength_Memoized(int[] A, int[] B)
        {
            int [,] memo = new int[A.Length,B.Length];
            for (int i = 0; i < memo.GetLength(0); i++)
            {
                for (int j = 0; j < memo.GetLength(1); j++)
                {
                    memo[i, j] = -1;
                }
            }

            return FindLcsLength_MemoizedUtil(A, B, 0, 0,memo);
        }

        private int FindLcsLength_MemoizedUtil(int[] A, int[] B, int i, int j, int [,] memo)
        {
            if (i == A.Length || j == B.Length)
                return 0;

            if (memo[i, j] >= 0)
                return memo[i, j];

            int inc = 0;
            if (A[i] == B[j])
            {
                inc = 1 + FindLcsLength_MemoizedUtil(A, B, i + 1, j + 1,memo);
            }

            int exc = Math.Max(FindLcsLength_MemoizedUtil(A, B, i, j + 1, memo), FindLcsLength_MemoizedUtil(A, B, i + 1, j, memo));
            memo[i,j] = Math.Max(inc, exc);
            return memo[i, j];
        }

        public LCSResult FindLCS_BottomUp(int[] X, int[] Y)
        {
            int [,] B = new int[X.Length+1,Y.Length+1];
            char [,] C = new char[X.Length + 1, Y.Length + 1];

            for (int i = 1; i <= X.Length; i++)
            {
                for (int j = 1; j <= Y.Length; j++)
                {
                    if (X[i-1] == Y[j-1])
                    {
                        B[i, j] = 1 + B[i - 1, j - 1];
                        C[i, j] = '\\';
                    }
                    else if (B[i - 1, j] > B[i, j - 1])
                    {
                        B[i, j] = B[i - 1, j];
                        C[i, j] = '|';
                    }
                    else
                    {
                        B[i, j] = B[i, j - 1];
                        C[i, j] = '-';
                    }
                }
            }

            return new LCSResult(B, C);
        }

        public class LCSResult
        {
            public int[,] ValuesArray { get; set; }
            public char[,] SymbolArray { get; set; }

            public LCSResult(int[,] valuesArray, char[,] symbolArray)
            {
                ValuesArray = valuesArray;
                SymbolArray = symbolArray;
            }
        }

        public void GetLCS(char [,] symbolArr, int [] X, int i, int j, List<int> sequence)
        {
            if (i == 0 || j == 0)
            {
                return;
            }

            if (symbolArr[i,j] == '\\')
            {
                GetLCS(symbolArr,X,i-1,j-1,sequence);
                sequence.Add(X[i-1]);
            }
            else if (symbolArr[i,j] == '|')
            {
                GetLCS(symbolArr,X,i-1,j,sequence);
            }
            else
            {
              GetLCS(symbolArr,X,i,j-1,sequence);  
            }
        }

    }
}
