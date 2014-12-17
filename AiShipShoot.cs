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

        public void GetShoot(out int i, out int j)
        {
            ICell cell = null;
            List<ICell> list;
            // З'ясовуємо, чи потрібно добивати
            // Отримуємо колекцію усіх комірок, які малються хрестиком
            IEnumerable<ICell> crossCells = field.GetCells().Where(c => c.HasShip == true && field.GetShip(c.X, c.Y) == null);
            //ICell cell = field.GetCell(i, j);
            //IShip ship = field.GetShip(i, j);
            //if (ship == null && cell.HasShip == true)
            switch (crossCells.Count())
            {
                case 1:
                    cell = GetCell(crossCells, 0);
                    i = cell.X;
                    j = cell.Y;
                    list = new List<ICell>();
                    AddCellToList(list, field.GetCell(i + 1, j));
                    AddCellToList(list, field.GetCell(i, j + 1));
                    AddCellToList(list, field.GetCell(i - 1, j));
                    AddCellToList(list, field.GetCell(i, j - 1));
                    cell = GetCell(list, r.Next(list.Count()));
                    i = cell.X;
                    j = cell.Y;
                    break;
                case 2:
                case 3:
                    ICell cell1 = GetCell(crossCells, 0);
                    ICell cell2 = GetCell(crossCells, crossCells.Count() - 1);
                    //Order(ref cell1, ref cell2);
                    list = new List<ICell>();
                    if (cell1.X - cell2.X == 0)
                    {
                        AddCellToList(list, field.GetCell(cell1.X, cell1.Y-1));
                        AddCellToList(list, field.GetCell(cell2.X, cell2.Y+1));
                    }
                    else
                    {
                        AddCellToList(list, field.GetCell(cell1.X - 1, cell1.Y));
                        AddCellToList(list, field.GetCell(cell2.X + 1, cell2.Y));
                    }
                    cell = GetCell(list, r.Next(list.Count()));
                    i = cell.X;
                    j = cell.Y;
                    break;
                case 0:
                default:
                    // Пошук нового корабля
                    IEnumerable<ICell> freeCells = field.GetCells().Where(c => c.HasShip == null);
                    cell = GetCell(freeCells, r.Next(freeCells.Count()));
                    i = cell.X;
                    j = cell.Y;
                    break;
            }
        }
    }
}
