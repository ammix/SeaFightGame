using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame
{
    //class CellCollection: IEnumerable<Cell>
    //{
    //    private Cell[,] _cells;

    //    public CellCollection()
    //    {
    //        _cells = new Cell[10, 10];
    //        for (int i = 0; i < 10; i++)
    //            for (int j = 0; j < 10; j++)
    //                _cells[i, j] = new Cell { X = i, Y = j, IsFired = false };

    //        _cells[2, 2].IsFired = true;
    //        _cells[2, 2].Ship = new Ship();
    //    }

    //    public IEnumerator<Cell> GetEnumerator()
    //    {
    //        for (int i = 0; i < 10; i++)
    //            for (int j = 0; j < 10; j++)
    //                yield return _cells[i, j];
    //    }

    //    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Cell GetCell(int x, int y)
    //    {
    //        return _cells[x, y];
    //    }
    //}
}
