﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame
{
    public interface IField
    {
        void AddShip(int x1, int y1, int x2, int y2);
        void Clear();
        void Fire(int i, int j);
        ICell GetCell(int i, int j);
        IShip GetShip(int i, int j);
        IEnumerable<ICell> GetCells();
        IEnumerable<IShip> GetShips();
    }
}
