using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame
{
    public class DataField : IDataField
    {
        private List<Ship> _ships;
        private Cell[,] _cells;

        public DataField()
        {
            _cells = new Cell[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    _cells[i, j] = new Cell { X = i, Y = j, IsFired = false };

            _ships = new List<Ship>();
        }

        public Cell GetCell(int i, int j)
        {
            return _cells[i, j];
        }

        public IEnumerable<Cell> GetCells()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    yield return _cells[i, j];
        }

        public IEnumerable<Ship> GetShips()
        {
            return _ships;
        }

        public void AddShip(Ship ship)
        {
            _ships.Add(ship);
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (ship.X1 <= i && i <= ship.X2 && ship.Y1 <= j && j <= ship.Y2)
                    {
                        _cells[i, j].Ship = ship;
                        ship.BindWithCell(_cells[i, j]);
                    }
        }
    }
}
