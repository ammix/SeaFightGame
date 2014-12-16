using System;
using System.Collections.Generic;

namespace SeaFightGame.Model
{
    public class Cell: ICell
    {
        private bool? hasShip = null;

        public int X { get; set; }
        public int Y { get; set; }
        public IShip Ship { get; set; }
        public bool? HasShip
        {
            get { return hasShip; }
        }

        public void Clear()
        {
            hasShip = null;
        }

        public bool Fire()
        {
            if (hasShip == null)
                hasShip = Ship != null ? true : false;

            return (bool)hasShip;
        }
    }
}
