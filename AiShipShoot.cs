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
        private IField field;
        private int i=0;
        private int j=0;
        private bool budemDobivati = false;

        public AiShipShoot(IField field)
        {
            this.field = field;
        }

        public void Shoot(out int i, out int j)
        {
            ICell cell = null;
            ICell[] neighborsCells = new ICell[4];
            // З'ясовуємо, чи потрібно добивати
            // Отримуємо колекцію усіх комірок, які малються хрестиком
            IEnumerable<ICell> crossCells = field.GetCells().Where(c=>c.HasShip == true);
            switch (crossCells.Count())
            {
                case 0:
                    // Пошук нового корабля
                    IEnumerable<ICell> notShootedCells = field.GetCells().Where(c => c.HasShip == null);
                    //List<ICell> list = new List<ICell>(
                    //notShootedCells.Find


                    var iterator = notShootedCells.GetEnumerator();
                    int n = notShootedCells.Count();
                    int next = r.Next(n);
                    for (int k = 0; k <= next; k++)
                        iterator.MoveNext();
                    cell = iterator.Current;

                    //ICell[] array = firedCells.ToArray();
                    //ICell c = array[next];

                    i = cell.X;
                    j = cell.Y;
                    break;
                case 1:
                    crossCells.GetEnumerator().MoveNext();
                    cell = crossCells.GetEnumerator().Current;
                    i = cell.X;
                    j = cell.Y;
                    neighborsCells[0] = field.GetCell(i + 1, j);
                    neighborsCells[0] = field.GetCell(i, j + 1);
                    neighborsCells[0] = field.GetCell(i - 1, j);
                    neighborsCells[0] = field.GetCell(i, j - 1);
                    int direction = r.Next(4);
                    //ShipSetupUtils.GetShipTail(x1, y1, deckNumber, r.Next(4), out x2, out y2);
                    break;
                case 2:
                case 3:
                    break;
            }

            i = 0;
            j = 0;

            //if (crossCells.Count() != null)
            //{

            //}
            //else
            //{
            //    //ICell cell = field.GetCell(i, j);
            //    //IShip ship = field.GetShip(i, j);

            //    //if (ship == null && cell.HasShip == true)
            //    //{
            //    //    // тут логіка добивання
            //    //    budemDobivati = true;
            //    //}

            //}
        }
    }
}
