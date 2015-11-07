using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Task1.Logic;

namespace Task1.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[4] { 1, 2, 3, 4 };
            SquareMatrix<int> m = new SquareMatrix<int>();
            m.ElementChanged += m_ElementChanged;
            Console.WriteLine(m.ToString());
            m[1, 1] = 5;
            Console.WriteLine(m.ToString());

            SymmetricalMatrix<int> s = new SymmetricalMatrix<int>(new int[] {1, 2, 3, 4, 5, 6}, 3);
            Console.WriteLine(s.ToString());
            s.ElementChanged += m_ElementChanged;
            s[1, 2] = 60;
            Console.WriteLine(s.ToString());

            SquareMatrix<int> m1 = new SquareMatrix<int>(new int[] { 1, 4, 5, 7 }, 2);
            SquareMatrix<int> m2 = new SquareMatrix<int>(new int[] { 1, 4, 5, 8 }, 2);
            Console.WriteLine(m1.CalculateOperation(m2, (a, b) => a + b));

            Console.ReadLine();
        }

        static void m_ElementChanged(object sender, MatrixElementArgs<int> e)
        {
            Console.WriteLine("Element with indexes [{0}, {1}] was changed, new value - {2}", e.IndexI, e.IndexJ, e.NewValue);
        }
    }
}
