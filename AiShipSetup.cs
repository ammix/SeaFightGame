using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeaFightGame.Model;

namespace SeaFightGame.Algorithm
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

        public static bool ShipHasContact(IField field, int x1, int y1, int x2, int y2)
        {
            // x2 >= x1, y2 >= y1 <- ця умова не виконується в загальному випадку, потрібна додаткова логіка.

            if (field.GetCell(x1, y1) == null)
                return true;

            if (field.GetCell(x2, y2) == null)
                return true;

            for (int i = x1 - 1; i <= x2 + 1; i++)
                for (int j = y1 - 1; j <= y2 + 1; j++)
                {
                    if (field.GetShip(i, j) != null)
                        return true;
                }
            return false;
        }

        public static int[] ShipsStock = new int[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
    }

    public class AiShipSetup: IAiShipSetup
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
                while (ShipSetupUtils.ShipHasContact(field, x1, y1, x1, y1));
                //while(!ShipSetupUtils.IsCellFree(x1, y1, field));

                do
                {
                    ShipSetupUtils.GetShipTail(x1, y1, deckNumber, r.Next(4), out x2, out y2);
                    counter++;
                    if (counter > 10) goto Start;
                }
                while (ShipSetupUtils.ShipHasContact(field, x2, y2, x2, y2));
                //while(!ShipSetupUtils.IsCellFree(x2, y2, field));

                field.AddShip(field.GetShip(x1, y1, x2, y2));
            }


        }
    }
}
