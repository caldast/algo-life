namespace Caldast.AlgoLife
{
    class MatrixMultiplication
    {

        public void TestSubMatrix() {

            Matrix a = new Matrix(4);
            var x = new int[4, 4];
            x[0, 0] = 3;
            x[0, 1] = 4;
            x[0, 2] = 5;
            x[0, 3] = 6;

            x[1, 0] = 7;
            x[1, 1] = 8;
            x[1, 2] = 9;
            x[1, 3] = 10;


            x[2, 0] = 11;
            x[2, 1] = 12;
            x[2, 2] = 13;
            x[2, 3] = 14;


            x[3, 0] = 15;
            x[3, 1] = 16;
            x[3, 2] = 17;
            x[3, 3] = 18;

            int half = 2;

            Matrix A11 = GetSubMatrix(a, 0, 0, half);
            Matrix A12 = GetSubMatrix(a, 0, 1, half);
            Matrix A21 = GetSubMatrix(a, 1, 0, half);
            Matrix A22 = GetSubMatrix(a, 1, 1, half);
        }

        public void StrassenMatrixMultiplication(Matrix a, Matrix b, Matrix c)
        {
            int n = a.Size;
            int half = n / 2;
            if (n == 1)
            {
                SetValue(c, 0, 0, GetValue(a, a.x, a.y) * GetValue(b, b.x, b.y));
                //c.Data[0, 0] = a.Data[0, 0] * b.Data[0, 0];
            }
            else
            {
              

                Matrix A11 = GetSubMatrix(a, 0, 0, half);
                Matrix A12 = GetSubMatrix(a, 0, 1, half);
                Matrix A21 = GetSubMatrix(a, 1, 0, half);
                Matrix A22 = GetSubMatrix(a, 1, 1, half);

                Matrix B11 = GetSubMatrix(b, 0, 0, half);
                Matrix B12 = GetSubMatrix(b, 0, 1, half);
                Matrix B21 = GetSubMatrix(b, 1, 0, half);
                Matrix B22 = GetSubMatrix(b, 1, 1, half);

                Matrix S1 = MatrixSubtract(B12, B22, half);
                Matrix S2 = MatrixAdd(A11, A12, half);
                Matrix S3 = MatrixAdd(A21, A22, half);
                Matrix S4 = MatrixSubtract(B21, B11, half);
                Matrix S5 = MatrixAdd(A11, A22, half);
                Matrix S6 = MatrixAdd(B11, B22, half);
                Matrix S7 = MatrixSubtract(A12, A22, half);
                Matrix S8 = MatrixAdd(B21, B22, half);
                Matrix S9 = MatrixSubtract(A11, A21, half);
                Matrix S10 = MatrixAdd(B11, B12, half);

                Matrix P1 = new Matrix(half);
                Matrix P2 = new Matrix(half);
                Matrix P3 = new Matrix(half);
                Matrix P4 = new Matrix(half);
                Matrix P5 = new Matrix(half);
                Matrix P6 = new Matrix(half);
                Matrix P7 = new Matrix(half);

                StrassenMatrixMultiplication(A11, S1, P1);
                StrassenMatrixMultiplication(S2, B22, P2);
                StrassenMatrixMultiplication(S3, B11, P3);
                StrassenMatrixMultiplication(A22, S4, P4);
                StrassenMatrixMultiplication(S5, S6, P5);
                StrassenMatrixMultiplication(S7, S8, P6);
                StrassenMatrixMultiplication(S9, S10, P7);

                if (half == 2)
                {
                    var t = 0;
                }
                // C11
                var c11addpart1 = MatrixAdd(P5, P4, half);
                var c11addpart2 = MatrixSubtract(c11addpart1, P2, half);
                var c11Value = MatrixAdd(c11addpart2, P6, half);

                 
                SetMatrixValue(c, c11Value, 0, 0);
               
                //SetValue(c, 0, 0, GetValue(c11Value,0,0));
                //SetValue(c, 0, 1, GetValue(MatrixAdd(P1, P2, half), 0, 0));
                SetMatrixValue(c, MatrixAdd(P1, P2, half), 0, half);
                //SetValue(c, 1, 0, GetValue(MatrixAdd(P3, P4, half), 0, 0));

                SetMatrixValue(c, MatrixAdd(P3, P4, half), half, 0);

                var c22addpart = MatrixAdd(P5, P1, half);
                var c22SubtractPart1 = MatrixSubtract(c22addpart, P3, half);
                var c22Value = MatrixSubtract(c22SubtractPart1, P7, half);

                //SetValue(c, 1, 1, GetValue(c22Value, 0, 0));   
                SetMatrixValue(c, MatrixAdd(P3, P4, half), half, half);
            }
        }

        public void SetMatrixValue(Matrix m, Matrix n, int x, int y)
        {
            var size = n.Size;
            for (int i = x; i < x + size; i++) {
                for (int j = y; j < y + size; j++) {
                    m.Data[i, j] = n.Data[i - x, j - y];
                }
            }
        }

        public void SetValue(Matrix m, int x, int y, int value) {
            m.Data[x, y] = value;
        }
        public int GetValue(Matrix m, int x, int y) {
            return m.Data[x, y];
        }
        public Matrix MatrixSubtract(Matrix a, Matrix b, int size)
        {
            Matrix c = new Matrix(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    c.Data[i, j] = GetValue(a,i + a.x,j + a.y) - GetValue(b,i + b.x, j + b.y);
                }
            }
            return c;
        }
        public Matrix MatrixAdd(Matrix a, Matrix b, int size)
        {
            Matrix c = new Matrix(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    c.Data[i, j] = GetValue(a, i + a.x, j + a.y) + GetValue(b, i + b.x, j + b.y);
                }
            }
            return c;
        }
        public Matrix GetSubMatrix(Matrix m, int x, int y, int size) {
            var matrix = new Matrix(size);
            matrix.x = x* size;
            matrix.y = y * size;
            matrix.Data = m.Data;
            return matrix;
        }
    }
    struct Matrix {
        public int x;
        public int y;
        public int Size;
        public int[,] Data;

        public Matrix(int size) {
            x = 0;
            y = 0;
            Size = size;
            Data = new int[size, size];

        }
    }
}
