﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeaFightGame.Model;

namespace SeaFightGame.Algorithm
{
    public class AiShipShoot: IAiShipShoot
    {
        private static Random r = new Random(DateTime.Now.Millisecond);
        private IEnumerable<ICell> cells;

        public AiShipShoot(IEnumerable<ICell> cells)
        {
            this.cells = cells;
        }

        public void Shoot(ShootResult prevShootResult, out int i, out int j)
        {
            var notShootedCells = from icell in cells
                             where (icell.State == ShootResult.Free)
                             select icell;
            var iterator = notShootedCells.GetEnumerator();
            int n = notShootedCells.Count();
            int next = r.Next(n);
            for (int k = 0; k <= next; k++)
                iterator.MoveNext();
            ICell cell = iterator.Current;

            //ICell[] array = firedCells.ToArray();
            //ICell c = array[next];

            i = cell.X;
            j = cell.Y;
        }
    }
}
