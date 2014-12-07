using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame
{
    public class Cell
    {
        private bool isFired = false;

        public IField Field { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsFired
        {
            get
            { 
                return isFired;
            }
            set
            {
                isFired = value;
                Field.Fire(this);
            }
        }
        public Ship Ship { get; set; }
    }
}
