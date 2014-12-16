using System;
using System.Collections.Generic;
using System.Linq;

namespace SeaFightGame.Model
{
    public class ObfuscatedField : IField
    {
        private IField field;

        public ObfuscatedField(IField field)
        {
            this.field = field;
        }

        public IEnumerable<IShip> GetShips()
        {
            return field.GetShips().Where(ship => ship.IsFired);
        }

        public IShip GetShip(int i, int j)
        {
            return null;
        }

        public void AddShip(IShip ship)
        {
            field.AddShip(ship);
        }

        public void UpdateShip(IShip ship, int x1, int y1, int x2, int y2)
        {
            field.UpdateShip(ship, x1, y1, x2, y2);
        }

        public void Clear()
        {
            field.Clear();
        }

        public bool Fire(int i, int j)
        {
            return field.Fire(i, j);
        }

        public ICell GetCell(int i, int j)
        {
            return field.GetCell(i, j);
        }

        public IShip GetShip(int x1, int y1, int x2, int y2)
        {
            return field.GetShip(x1, y1, x2, y2);
        }

        public IEnumerable<ICell> GetCells()
        {
            return field.GetCells();
        }

        public event Action<ICell> CellFired
        {
            add { field.CellFired += value; }
            remove { field.CellFired -= value; }
        }
        public event Action<IShip> ShipFired
        {
            add { field.ShipFired += value; }
            remove { field.ShipFired -= value; }
        }
}
}
