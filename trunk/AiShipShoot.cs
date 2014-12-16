using System;
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

        public void Shoot(out int i, out int j)
        {
            var notShootedCells = cells.Where(cell => cell.HasShip == null);

            var iterator = notShootedCells.GetEnumerator();
            int n = notShootedCells.Count();
            int next = r.Next(n);
            for (int k = 0; k <= next; k++)
                iterator.MoveNext();
            ICell celka = iterator.Current;

            //ICell[] array = firedCells.ToArray();
            //ICell c = array[next];

            i = celka.X;
            j = celka.Y;
        }
    }
}
