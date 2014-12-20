using System;
using System.Collections.Generic;
using SeaFightGame.Algorithm;
using System.Linq;

namespace SeaFightGame.Model
{
    public class Field : IField
    {
        protected List<Ship> ships;
        private Cell[,] cells;

        public Field()
        {
            cells = new Cell[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    cells[i, j] = new Cell { X = i, Y = j };
                }

            ships = new List<Ship>();
        }

        public ICell GetCell(int i, int j)
        {
            //if (!(i >= 0 && i < X && j >= 0 && j < Y))
            //    throw new ArgumentOutOfRangeException(string.Format("i={0}, j={1}", i, j));

            return i >= 0 && i < GameConstants.X && j >= 0 && j < GameConstants.Y ? cells[i, j] : null;
        }

        public IEnumerable<ICell> GetCells()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    yield return cells[i, j];
        }

        public IEnumerable<IShip> GetShips()
        {
            return ships;
        }

        public IShip GetShip(int i, int j)
        {
            Cell cell = (Cell)GetCell(i, j);
            return cell != null ? cell.Ship : null;
        }

        public IShip GetShip(int x1, int y1, int x2, int y2)
        {
            Ship ship = new Ship(x1, y1, x2, y2);
            ships.Add(ship);
            return ship;
        }

        public void AddShip(IShip iShip)
        {
            Ship ship = (Ship)iShip;
            //ships.Add(ship);

            //for (int i = 0; i < 10; i++)
            //    for (int j = 0; j < 10; j++)
            //        if (ship.X1 <= i && i <= ship.X2 && ship.Y1 <= j && j <= ship.Y2)
            //        {
            //            cells[i, j].Ship = ship;
            //            ship.BindWithCell(cells[i, j]);
            //        }

            for (int i = ship.X1; i <= ship.X2; i++)
                for (int j = ship.Y1; j <= ship.Y2; j++)
                {
                    ship.BindWithCell(cells[i, j]);
                }
        }

        public void Clear()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    cells[i, j].Clear(); // IsFired = false;
                    cells[i, j].Ship = null;
                }

            ships.Clear();
        }

        public bool Fire(int i, int j)
        {
            bool shootResult = false;
            ICell cell = GetCell(i, j);
            if (cell != null && cell.HasShip == null)
            {
                shootResult = cell.Fire();

                if (CellFired != null)
                    CellFired(cell);

                IShip ship = (cell as Cell).Ship;
                if (ship != null && ship.IsFired)
                {
                    for (i = ship.X1 - 1; i <= ship.X2 + 1; i++)
                        for (j = ship.Y1 - 1; j <= ship.Y2 + 1; j++)
                        {
                            Fire(i, j);
                        }

                    if (ShipFired != null)
                        ShipFired(ship);

                    if (FieldFired != null)
                    {
                        IEnumerable<IShip> freeShips = GetShips().Where(s => !s.IsFired);
                        if (freeShips.Count() == 0)
                            FieldFired(this);
                    }
                }
            }
            return shootResult;
        }

        public void UpdateShip(IShip iShip, int x1, int y1, int x2, int y2)
        {
            Ship ship = (Ship)iShip;
            ship.X1 = x1;
            ship.Y1 = y1;
            ship.X2 = x2;
            ship.Y2 = y2;

            //foreach (Cell cell in ship.GetCells())
            //    cell.Ship = null;
            //ship.FreeCells();
            //for (int i = x1; i <= x2; i++)
            //    for (int j = y1; j <= y2; j++)
            //    {
            //        cells[i, j].Ship = ship;
            //        ship.BindWithCell(cells[i, j]);
            //    }
        }

        public event Action<ICell> CellFired;
        public event Action<IShip> ShipFired;
        public event Action<IField> FieldFired;
    }
}
