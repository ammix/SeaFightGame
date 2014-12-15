using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame.Model
{
    public interface IField
    {
        void AddShip(IShip ship);
        void UpdateShip(IShip ship, int x1, int y1, int x2, int y2);

        void Clear();
        ShootResult Fire(int i, int j);
        ICell GetCell(int i, int j);
        IShip GetShip(int i, int j);
        IShip GetShip(int x1, int y1, int x2, int y2);

        IEnumerable<ICell> GetCells();
        IEnumerable<IShip> GetShips();
    }
}
