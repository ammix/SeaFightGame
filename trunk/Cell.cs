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
        public IShip Ship { get; set; }
        public bool IsFired
        {
            get { return isFired; }
        }

        public void Clear()
        {
            isFired = false;
        }

        public ShootResult Fire()
        {
            if (!isFired)
            {
                isFired = true;

                if (Ship != null)
                    return Ship.Fire();
            }

            return ShootResult.Miss;
        }
    }
}
