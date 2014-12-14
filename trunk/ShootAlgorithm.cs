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
            var firedCells = from x in field.GetCells()
                             where !x.IsFired
                             select x;
            var iterator = firedCells.GetEnumerator();
            int n = firedCells.Count();
            int next = r.Next(n);
            for (int k = 0; k <= next; k++)
                iterator.MoveNext();
            ICell cell = iterator.Current;

             //ICell[] cellArray = firedCells.ToArray();
             //ICell cell_ = cellArray[next];


            i = cell.X;
            j = cell.Y;

            //for (int i = 0; i < 10; i++)
            //    for (int j = 0; j < 10; j++)
            //    {
            //        if (!predicate(cells[i,j]) // !cells[i, j].IsFired)
            //            yield return cells[i, j];
            //    }
        }
    }
}
