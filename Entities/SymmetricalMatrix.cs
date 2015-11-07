using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SymmetricalMatrix<T>: SquareMatrix<T> where T: IEquatable<T>
    {
        public SymmetricalMatrix(int width, T value)
        {
            if (width < 0)
                throw new ArgumentException("Matrix length cannot be less than zero");

            Width = width;
            matrix = new T[CalculateArrayLength(Width)];
            for (int i = 0; i < matrix.Length; i++)
                matrix[i] = value;
        }

        public SymmetricalMatrix(T[] array, int width)
        {
            if (array == null)
                throw new ArgumentNullException("Cannot create matrix with this array");
            if (!(array.Length == CalculateArrayLength(width)))
                throw new ArgumentException("Cannot create matrix: wrong array length");
            Width = width;
            Array.Copy(array, matrix, array.Length);
        }

        public SymmetricalMatrix(int width)
            : this(width, default(T))
        {
        }

        public SymmetricalMatrix()
            : this(DEFAULT_LENGTH)
        {
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i >= Width || j >= Width || i < 0 || i < 0)
                    throw new ArgumentException("Cannot get element: wrong indexes");

                if (j >= i)
                    return matrix[CalculateArrayLength(j) + i];
                else
                    return matrix[CalculateArrayLength(i) + j];
            }
            set
            {
                if (j >= i)
                    matrix[CalculateArrayLength(j) + i] = value;
                else
                    matrix[CalculateArrayLength(i) + j] = value;

                MatrixElementArgs<T> e = new MatrixElementArgs<T>(i, j, value);
                base.OnElementChanged(e);
            }
        }

        private int CalculateArrayLength(int width)
        {
            if (width == 1)
                return 1;

            int result = 0;
            for (int i = width; i != 0; i--)
                result += i;

            return result;
        }
    }
}
