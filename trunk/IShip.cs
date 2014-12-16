using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame.Model
{
    public interface IShip
    {
        int X1 { get; }
        int X2 { get; }
        int Y1 { get; }
        int Y2 { get; }
        bool IsFired { get; }
        ShootResult Fire();
        IEnumerable<ICell> GetCells();
    }
}
