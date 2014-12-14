using System;
using System.Collections.Generic;
using SeaFightGame.Algorithm;

namespace SeaFightGame.Model
{
    public class Field : IField
    {
        public static int X = 10;
        public static int Y = 10;

        private List<Ship>  ships;
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
            return i >= 0 && i < X && j >= 0 && j < Y ? cells[i, j] : null;
        }

        public IEnumerable<ICell> GetCells()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    yield return cells[i, j];
        }

        public IEnumerable<ICell> GetCells(Func<ICell, bool> predicate)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (!predicate(cells[i,j]))
                        yield return cells[i, j];
                }
        }

        public IEnumerable<IShip> GetShips()
        {
            return ships;
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

        //public void SetupShips(ICpuShipSetup algorithm)
        //{
        //    algorithm.Setup(this);
        //}

        public bool Fire(int x, int y)
        {
            Cell cell = (Cell)GetCell(x, y);
            if (cell != null && !cell.IsFired)
            {
                /*bool isHit = */cell.Fire();
                if (cell.HasShip && cell.Ship.IsFired)
                {
                    int x1 = cell.Ship.X1;
                    int x2 = cell.Ship.X2;
                    int y1 = cell.Ship.Y1;
                    int y2 = cell.Ship.Y2;
                    for (int i = x1 - 1; i <= x2 + 1; i++)
                        for (int j = y1 - 1; j <= y2 + 1; j++)
                        {
                            cell = (Cell)GetCell(i, j);
                            if (cell != null && !cell.IsFired)
                                cell.Fire();
                        }
                }
            }
            return (GetCell(x, y) as Cell).HasShip;
        }

        //public IShip GetShip(int i, int j)
        //{
        //    return (GetCell(i, j) as Cell).Ship;
        //}

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
    }
}
