using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame
{
    public class Ship
    {
        private int x1 = 0;
        private int x2 = 0;
        private int y1 = 0;
        private int y2 = 0;
        private List<Cell> _cells= new List<Cell>();

        public int X1
        {
            get { return x1; }
            set { x1 = value; }
        }
        public int X2
        {
            get { return x2; }
            set { x2 = value; }
        }
        public int Y1
        {
            get { return y1; }
            set { y1 = value; }
        }
        public int Y2
        {
            get { return y2; }
            set { y2 = value; }
        }

        public void BindWithCell(Cell cell)
        {
            _cells.Add(cell);
        }
    }
}
