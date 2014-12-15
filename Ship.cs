using System;
using System.Collections.Generic;

namespace SeaFightGame.Model
{
    public class Ship: IShip
    {
        private int x1 = 0;
        private int x2 = 0;
        private int y1 = 0;
        private int y2 = 0;
        private IList<Cell> cells= new List<Cell>();

        //public IEnumerable<ICell> GetCells()
        //{
        //    return cells;
        //}

        public Ship(int x1, int y1, int x2, int y2)
        {
            this.x1 = Math.Min(x1, x2);
            this.y1 = Math.Min(y1, y2);
            this.x2 = Math.Max(x1, x2);
            this.y2 = Math.Max(y1, y2);
            if (this.x2 >= Field.X)
            {
                this.x1 = 9 - (this.x2 - this.x1);
                this.x2 = 9;
            }
            if (this.y2 >= Field.Y)
            {
                this.y1 = 9 - (this.y2 - this.y1);
                this.y2 = 9;
            }
        }

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
            cell.Ship = this;
            cells.Add(cell);
            if (Fired != null)
                Fired(this);
        }

        public void FreeCells()
        {
            cells.Clear();
        }

        public bool IsFired
        {
            get
            {
                bool flag = cells.Count != 0;
                foreach (Cell cell in cells)
                    flag = flag && cell.IsFired;

                return flag;
            }
        }

        public ShootResult Fire()
        {
            if (Fired != null)
                Fired(this);

            return IsFired ? ShootResult.Ruin : ShootResult.Hurt;
        }

        public event Action<IShip> Fired;


        public IEnumerable<ICell> GetCells()
        {
            return cells;
        }
    }
}
