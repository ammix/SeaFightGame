﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame.Model
{
    public interface IField
    {
        string PlayerName { get; }

        void AddShip(IShip ship);
        void UpdateShip(IShip ship, int x1, int y1, int x2, int y2);

        void Clear();
        bool Fire(int i, int j);
        ICell GetCell(int i, int j);
        IShip GetShip(int i, int j);
        IShip GetShip(int x1, int y1, int x2, int y2);

        IEnumerable<ICell> GetCells();
        IEnumerable<IShip> GetShips();

        event Action<ICell> CellFired;
        event Action<IShip> ShipFired;
        event Action<IField> FieldFired;
    }
}
