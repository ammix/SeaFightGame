using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame.Model
{
    public class Cell: ICell
    {
        private bool isFired = false;

        public int X { get; set; }
        public int Y { get; set; }
        public Ship Ship { get; set; }
        public bool IsFired
        {
            get { return isFired; }
        }
        public bool HasShip
        {
            get { return Ship != null; }
        }

        public void Clear()
        {
            isFired = false;
        }

        public void Fire()
        {
            isFired = true;
            if (Fired != null)
                Fired(this);
            if (Ship != null)
                Ship.Fire();
        }

        public event Action<ICell> Fired;
    }
}
