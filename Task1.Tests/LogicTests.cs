using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1.Logic;
using Entities;

namespace Task1.Tests
{
    [TestFixture]
    public class LogicTests
    {
        [TestCase(new int[4] {1, 3, 5, 9}, new int[4] { 2, 5, 1, 8}, 2, Result = new int[4] {3, 6, 8, 17})]
        [TestCase(null, null, 3, ExpectedException = typeof(ArgumentNullException))]
        [TestCase(new int[1] {3}, new int[1] {6}, 1, Result = new int[1] {9})]
        [TestCase(new int[1] { 3 }, new int[1] { 6 }, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(new int[5] {1, 2, 3, 4, 5}, new int[4] {1, 2, 3, 4}, 4, ExpectedException = typeof(ArgumentException))]
        public int[] AddTest_SquareMatrix_Ints(int[] first, int[] second, int length)
        {
            SquareMatrix<int> firstMatrix = new SquareMatrix<int>(first, length);
            SquareMatrix<int> secondMatrix = new SquareMatrix<int>(second, length);
            int[] result = new int[length * length];

            firstMatrix.CalculateOperation(secondMatrix, (a, b) => a + b);

            int k = 0;
            for (int i = 0; i < firstMatrix.Width; i++)
                for (int j = 0; j < firstMatrix.Width; j++)
                {
                    result[k++] = firstMatrix[i, j];
                }

            return result;
        }
    }
}
