using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame
{
    public static class ShipSetupUtils
    {
        public static void GetShipTail(int x1, int y1, int deckNumber, int direction, out int x2, out int y2)
        {
            switch (direction)
            {
                case 0:
                    x2 = x1 + deckNumber;
                    y2 = y1;
                    break;
                case 1:
                    x2 = x1;
                    y2 = y1 + deckNumber;
                    break;
                case 2:
                    x2 = x1 - deckNumber;
                    y2 = y1;
                    break;
                case 3:
                    x2 = x1;
                    y2 = y1 - deckNumber;
                    break;
                default:
                    x2 = x1;
                    y2 = y1;
                    break;
            }
        }

        public static bool IsCellFree(int x, int y, IField field)
        {
            if (field.GetCell(x, y) == null)
                return false;

            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                {
                    ICell cell = field.GetCell(i, j);
                    if (cell != null)
                    {
                        if (cell.HasShip)
                            return false;
                    }
                }

            return true;
        }

        public static int[] ShipsStock = new int[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
    }

    public class AutoShipsSetup: IShipsSetupAlgorithm
    {
        private static Random r = new Random(DateTime.Now.Millisecond);

        public void Setup(IField field)
        {
            for (int i = 0; i < ShipSetupUtils.ShipsStock.Length; i++)
            {
            Start:
                int deckNumber = ShipSetupUtils.ShipsStock[i] - 1;
                int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
                int counter = 0;

                do
                {
                    x1 = r.Next(10);
                    y1 = r.Next(10);
                }
                while (!ShipSetupUtils.IsCellFree(x1, y1, field));

                do
                {
                    ShipSetupUtils.GetShipTail(x1, y1, deckNumber, r.Next(4), out x2, out y2);
                    counter++;
                    if (counter > 10) goto Start;
                }
                while (!ShipSetupUtils.IsCellFree(x2, y2, field));

                field.AddShip(field.GetShip(x1, y1, x2, y2));
            }


        }
    }
}
