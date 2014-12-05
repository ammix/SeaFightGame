using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame
{
    public interface IDataField
    {
        Cell GetCell(int i, int j);
        IEnumerable<Cell> GetCells();
        IEnumerable<Ship> GetShips();
    }
}
