using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Matrix
{
    public class Matrix<T>
        where T : struct, IComparable<T>, IComparable, IEquatable<T>, IConvertible, IFormattable
    {
        private int rows;
        private int cols;
        private const int defaultRows = 4;
        private const int defaultCols = 4;
        private T[,] elements;

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            elements = new T[rows, cols];
        }

        public Matrix()
            : this(defaultRows, defaultCols)
        {
        }

        public int Rows
        {
            get { return this.rows; }
        }

        public int Cols
        {
            get { return this.cols; }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= this.rows || col < 0 || col >= this.cols)
                {
                    throw new IndexOutOfRangeException("You are trying to take an element, that doesn't exist!");
                }
                return this.elements[row, col];
            }
            set { this.elements[row, col] = value; }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.rows != m2.rows || m1.cols != m2.cols)
            {
                throw new ArgumentException("The matrixes are not of the same size and they can't be added to each other.");
            }
            Matrix<T> newMatrix = new Matrix<T>(m1.rows, m1.cols);
            for (int i = 0; i < m1.rows; i++)
            {
                for (int k = 0; k < m1.cols; k++)
                {
                    newMatrix[i, k] = (T)Convert.ChangeType(Convert.ToDecimal(m1[i, k]) + Convert.ToDecimal(m2[i, k]), typeof(T));
                }
            }
            return newMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.rows != m2.rows || m1.cols != m2.cols)
            {
                throw new ArgumentException("The matrixes are not of the same size and they can't be subtracted from each other.");
            }
            Matrix<T> newMatrix = new Matrix<T>(m1.rows, m1.cols);
            for (int i = 0; i < m1.rows; i++)
            {
                for (int k = 0; k < m1.cols; k++)
                {
                    newMatrix[i, k] = (T)Convert.ChangeType(Convert.ToDecimal(m1[i, k]) - Convert.ToDecimal(m2[i, k]), typeof(T));
                }
            }
            return newMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.cols != m2.rows)
            {
                throw new ArgumentException("The matrixes are not of the right size and they can't be multiplied to each other. The number of colomns of the first should be equal to the number of the rows of the second matrix.");
            }
            Matrix<T> newMatrix = new Matrix<T>(m1.rows, m2.cols);
            T currSum = default(T);
            for (int row = 0; row < m1.rows; row++)
            {
                for (int col = 0; col < m2.cols; col++)
                {
                    newMatrix[row, col] = default(T);
                    for (int i = 0; i < m1.cols; i++)
                    {
                        newMatrix[row, col] += (dynamic)m1[row, i] * m2[i, col];
                    }
                }
            }
            return newMatrix;
        }

        public static bool operator true(Matrix<T> m)
        {
            if (m == null || m.cols == 0 || m.rows == 0)
            {
                return false;
            }
            for (int i = 0; i < m.rows; i++)
            {
                for (int k = 0; k < m.cols; k++)
                {
                    if (!m[i, k].Equals(default(T)))  //there is at least one real number in the matrix
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> m)
        {
            if (m == null || m.cols == 0 || m.rows == 0)
            {
                return true; //it's true, that it's false
            }
            for (int i = 0; i < m.rows; i++)
            {
                for (int k = 0; k < m.cols; k++)
                {
                    if (!m[i, k].Equals(default(T)))  //there is at least one real number in the matrix
                    {
                        return false;
                    }
                }
            }

            return true;
        }



    }
}
