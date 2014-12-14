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
            //Func<int, int> sqr = delegate(int x) { return x*x; };
            //Func<bool, ICell> 

            //IEnumerable<ICell> cells = field.GetCells(delegate(ICell x) { return x.IsFired; }); //x-> x.IsFired
            //IEnumerable<ICell> cells = field.GetCells((ICell x) => { return x.IsFired; });

            IEnumerable<ICell> cells = field.GetCells(x => x.IsFired);
            //var q = cells.GetEnumerator();
            //q.MoveNext();
            ICell[] cellArray = cells.ToArray();
            ICell cell = cellArray[r.Next(cellArray.Length)];


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
