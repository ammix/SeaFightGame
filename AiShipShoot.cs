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

        private static void AddCellToList(List<ICell> list, ICell cell)
        {
            if (cell != null && cell.HasShip == null)
                list.Add(cell);
        }

        private ICell GetCell(IEnumerable<ICell> collection, int n)
        {
            IEnumerator<ICell> iterator = collection.GetEnumerator();
            for (int i = 0; i <= n; i++)
                iterator.MoveNext();
            return iterator.Current;
        }

        public void Shoot(out int i, out int j)
        {
            ICell cell = null;
            // З'ясовуємо, чи потрібно добивати
            // Отримуємо колекцію усіх комірок, які малються хрестиком
            IEnumerable<ICell> crossCells = field.GetCells().Where(c => c.HasShip == true && field.GetShip(c.X, c.Y) == null);
            switch (crossCells.Count())
            {
                case 0:
                    // Пошук нового корабля
                    IEnumerable<ICell> freeCells = field.GetCells().Where(c => c.HasShip == null);
                    cell = GetCell(freeCells, r.Next(freeCells.Count()));
                    i = cell.X;
                    j = cell.Y;
                    break;
                case 1:
                    cell = GetCell(crossCells, 0);
                    i = cell.X;
                    j = cell.Y;
                    List<ICell> list = new List<ICell>();
                    AddCellToList(list, field.GetCell(i + 1, j));
                    AddCellToList(list, field.GetCell(i, j + 1));
                    AddCellToList(list, field.GetCell(i - 1, j));
                    AddCellToList(list, field.GetCell(i, j - 1));
                    cell = GetCell(list, r.Next(list.Count()));
                    i = cell.X;
                    j = cell.Y;

                    //crossCells.GetEnumerator().MoveNext();
                    //cell = crossCells.GetEnumerator().Current;
                    //ShipSetupUtils.GetShipTail(x1, y1, deckNumber, r.Next(4), out x2, out y2);
                    break;
                case 2:
                case 3:
                    i = 0;
                    j = 0;
                    break;
                default:
                    i = 0;
                    j = 0;
                    break;
            }


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
