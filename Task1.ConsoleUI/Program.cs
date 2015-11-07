using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

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
            
            Console.ReadLine();
        }

        static void m_ElementChanged(object sender, MatrixElementArgs<int> e)
        {
            Console.WriteLine("Element with indexes [{0}, {1}] was changed, new value - {2}", e.IndexI, e.IndexJ, e.NewValue);
        }
    }
}
