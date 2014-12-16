using System;
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
}
