using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Task1.Logic
{
    public static class MatrixOperations
    {
        public static SquareMatrix<T> CalculateOperation<T>(this SquareMatrix<T> first, SquareMatrix<T> second, Func<T, T, T> operation)
            where T: IEquatable<T>
        {
            if (operation == null)
                throw new ArgumentNullException("Operation for matrixes is not specified");
            if (first == null || second == null)
                throw new ArgumentNullException("Matrix is null");
            if (first.Width != second.Width)
                throw new InvalidOperationException("Cannot add matrixes with different dimensions");

            for (int i = 0; i < first.Width; i++)
                for (int j = 0; j < first.Width; j++)
                    first[i, j] = operation(first[i, j], second[i, j]);

            return first;
        }
    }
}
