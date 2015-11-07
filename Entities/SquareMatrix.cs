using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SquareMatrix<T>: IEquatable<SquareMatrix<T>>
        where T: IEquatable<T>
    {
        protected const int DEFAULT_LENGTH = 3;
        protected T[] matrix;
        public int Width { get; protected set; }

        public SquareMatrix(int width)
            :this(default(T), width)
        {
        }

        public SquareMatrix()
            :this(default(T), DEFAULT_LENGTH)
        {
        }

        public SquareMatrix(T[] array, int width)
        {
            if (width < 0)
                throw new ArgumentException("Size of matrix cannot be less than zero");
            if (array == null)
                throw new ArgumentNullException("Cannot create matrix with array");
            if (array.Length != width * width)
                throw new ArgumentException("Cannot use this array with this length");

            matrix = new T[array.Length];
            Array.Copy(array, matrix, array.Length);
            Width = width;
        }

        public SquareMatrix(T item, int width)
        {
            if (width < 0)
                throw new ArgumentException("Size of matrix cannot be less than zero");
            Width = width;
            matrix = new T[width * width];
            for (int i = 0; i < matrix.Length; i++)
                matrix[i] = item;
        }

        public virtual T this[int i, int j]
        {
            get
            {
                if (i >= Width || j >= Width || i < 0 || j < 0)
                    throw new ArgumentException("Wrong indexes for matrix");
                return matrix[j * Width + i];
            }
            set
            {
                if (i > Width || j > Width || i < 0 || j < 0)
                    throw new ArgumentException("Wrong indexes for matrix");
                matrix[Width * j + i] = value;
                MatrixElementArgs<T> e = new MatrixElementArgs<T>(i, j, value);
                OnElementChanged(e);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this == obj)
                return true;
            SquareMatrix<T> matrix = obj as SquareMatrix<T>;
            if (matrix == null)
                return false;
            return this.Equals(matrix);

        }

        public bool Equals(SquareMatrix<T> other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (Width != other.Width)
                return false;

            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Width; j++)
                    if (!this[i, j].Equals(other[i, j]))
                        return false;
            
            return true;
        }

        public override int GetHashCode()
        {
            return matrix.GetHashCode() * 19;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Width; j++)
                    result.Append(this[i, j].ToString() + " ");
                result.Append("\n");
            }
            return result.ToString();
        }

        public event EventHandler<MatrixElementArgs<T>> ElementChanged;

        protected virtual void OnElementChanged(MatrixElementArgs<T> e)
        {
            EventHandler<MatrixElementArgs<T>> handler = ElementChanged;
            if (handler != null)
                handler(this, e);
        }
    }
}
