using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class CellModel
    {
        // getting the three dimensions of a cell (rows, columns and state)
        public int Ren { get; set; }
        public int Col { get; set; }
        public bool State { get; set; }
    }
}
