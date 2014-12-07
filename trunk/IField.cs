using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame
{
    public interface IField
    {
        void AddShip(Ship ship);
        void Clear();
        Cell GetCell(int i, int j);
        IEnumerable<Cell> GetCells();
        IEnumerable<Ship> GetShips();
        event Action<Cell> CellFired;
        event Action<Ship> ShipFired;
    }
}
