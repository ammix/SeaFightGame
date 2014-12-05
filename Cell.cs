using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsFired { get; set; }
        public Ship Ship { get; set; }
    }
}
