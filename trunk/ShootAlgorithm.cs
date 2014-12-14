using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeaFightGame.Model;

namespace SeaFightGame.Algorithm
{
    public class ShootAlgorithm: IShootAlgorithm
    {
        private static Random r = new Random(DateTime.Now.Millisecond);
        private IField field;

        public ShootAlgorithm(IField field)
        {
            this.field = field;
        }

        public void Shoot(out int i, out int j)
        {
            IEnumerable<ICell> cells = field.GetNotFiredCells();
            ICell[] cellArray = cells.ToArray();
            ICell cell = cellArray[r.Next(cellArray.Length)];

            i = cell.X;
            j = cell.Y;
        }
    }
}
