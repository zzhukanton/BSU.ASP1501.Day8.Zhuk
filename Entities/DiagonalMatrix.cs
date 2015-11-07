using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DiagonalMatrix<T>: SquareMatrix<T> where T: IEquatable<T>
    {
        public DiagonalMatrix(T diagonalElement, int width)
        {
            if (width < 0)
                throw new ArgumentException("Size of matrix cannot be less than zero");

            this.matrix = new T[width];
            Width = width;
            for (int i = 0; i < Width; i++)
                matrix[i] = diagonalElement;
        }

        public DiagonalMatrix()
            :this(default(T), DEFAULT_LENGTH)
        {
        }

        public DiagonalMatrix(int width)
            :this(default(T), width)
        {
        }

        public DiagonalMatrix(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException("Cannot create matrix with this array");

            Width = array.Length;
            matrix = new T[Width];
            Array.Copy(array, matrix, Width);
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i >= Width || j >= Width || i < 0 || j < 0)
                    throw new ArgumentException("Wrong indexes");

                if (i == j)
                    return matrix[i];

                return default(T);
            }
            set
            {
                if (j != i)
                {
                    throw new ArgumentException("Cannot change non-diagonal element");
                }
                matrix[i] = value;
                MatrixElementArgs<T> e = new MatrixElementArgs<T>(i, j, value);
                base.OnElementChanged(e);
            }
        }
    }
}
