using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator
{
    class Cell
    {
        public int x, y;
        public bool starter = false;
        public bool visited = false;
        public bool deadEnd = false;

        public bool[] walls = { true, true, true, true };

        public Cell() { }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


    }
}
