using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MatrixElementArgs<T>: EventArgs
    {
        public int IndexI { get; private set; }
        public int IndexJ { get; private set; }
        public T NewValue { get; private set; }

        public MatrixElementArgs(int i, int j, T value)
        {
            IndexI = i;
            IndexJ = j;
            NewValue = value;
        }
    }
}
