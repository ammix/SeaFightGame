using System;
using System.Collections.Generic;

namespace SeaFightGame
{
    public class Ship: IShip
    {
        private int x1 = 0;
        private int x2 = 0;
        private int y1 = 0;
        private int y2 = 0;
        private List<Cell> _cells= new List<Cell>();

        public Ship(int x1, int y1, int x2, int y2)
        {
            this.x1 = Math.Min(x1, x2);
            this.y1 = Math.Min(y1, y2);
            this.x2 = Math.Max(x1, x2);
            this.y2 = Math.Max(y1, y2);
        }

        public int X1
        {
            get { return x1; }
        }
        public int X2
        {
            get { return x2; }
        }
        public int Y1
        {
            get { return y1; }
        }
        public int Y2
        {
            get { return y2; }
        }

        public void BindWithCell(Cell cell)
        {
            _cells.Add(cell);
        }

        public bool IsFired
        {
            get
            {
                bool flag= true;
                foreach (Cell cell in _cells)
                    flag = flag && cell.IsFired;

                return flag;
            }
        }

        public void Fire()
        {
            if (Fired != null)
                if (IsFired)
                    Fired(this);
        }

        public event Action<IShip> Fired;
    }
}
