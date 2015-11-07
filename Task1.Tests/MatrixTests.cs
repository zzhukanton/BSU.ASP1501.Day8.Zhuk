using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Entities;

namespace Task1.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [TestCase(new int[4] {1, 3, 6, 9}, 2, 0, 0, Result = 1)]
        [TestCase(new int[4] { 1, 3, 6, 9 }, 2, 1, 0, Result = 3)]
        [TestCase(new int[4] { 1, 3, 6, 9 }, 2, 4, 4, ExpectedException = typeof(ArgumentException))]
        [TestCase(new int[4] { 1, 3, 6, 9 }, 2, -1, 0, ExpectedException = typeof(ArgumentException))]
        public int IndexatorTest_Int_SquareMatrix(int[] array, int length, int i, int j)
        {
            SquareMatrix<int> m = new SquareMatrix<int>(array, length);
 
            return m[i, j];
        }

        [TestCase(new int[4] { 1, 3, 6, 9 }, 2, 2, Result = 6)]
        [TestCase(new int[4] { 1, 3, 6, 9 }, 3, 0, Result = 0)]
        [TestCase(new int[4] { 1, 3, 6, 9 }, 6, 4, ExpectedException = typeof(ArgumentException))]
        [TestCase(new int[4] { 1, 3, 6, 9 }, -1, 0, ExpectedException = typeof(ArgumentException))]
        public int IndexatorTest_Int_DiagonalMatrix(int[] array, int i, int j)
        {
            DiagonalMatrix<int> m = new DiagonalMatrix<int>(array);

            return m[i, j];
        }

        [TestCase(new int[6] { 1, 3, 6, 9, 8, 1 }, 3, 2, 2, Result = 1)]
        [TestCase(new int[4] { 1, 2, 3, 4}, 4, 1, 1, ExpectedException = typeof(ArgumentException))]
        [TestCase(null, 3, 1, 1, ExpectedException = typeof(ArgumentNullException))]
        [TestCase(new int[6] {1, 2, 3, 4, 5, 6}, 4, 1, 1, ExpectedException = typeof(ArgumentException))]
        [TestCase(new int[6] { 1, 3, 6, 9, 5, 2 }, 3, 7,  4, ExpectedException = typeof(ArgumentException))]
        [TestCase(new int[6] { 1, 3, 6, 9, 8, 1 }, 3, -2, 0, ExpectedException = typeof(ArgumentException))]
        public int IndexatorTest_Int_SymmetricalMatrix(int[] array, int length, int i, int j)
        {
            SymmetricalMatrix<int> m = new SymmetricalMatrix<int>(array, length);

            return m[i, j];
        }
    }
}
