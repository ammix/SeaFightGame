using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame
{
    public static class ShipsSetupAlgorithm
    {
        private static Random r = new Random(DateTime.Now.Millisecond);

        public static void Setup(IField field)
        {
            int[] ships = new int[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            for (int i = 0; i < ships.Length; i++)
            {
            Start:
                int deckNumber = ships[i] - 1;
                int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
                int counter = 0;

                do
                {
                    x1 = r.Next(10);
                    y1 = r.Next(10);
                }
                while (!IsCellFree(x1, y1, field));

                do
                {
                    int z = r.Next(4);
                    switch (z)
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
                    }
                    counter++;
                    if (counter > 10) goto Start;
                }
                while (!IsCellFree(x2, y2, field));

                field.AddShip(new Ship(x1, y1, x2, y2));
            }


        }

        private static bool IsCellFree(int x, int y, IField field)
        {
            if (field.GetCell(x, y) == null)
                return false;

            for(int i=x-1; i<=x+1; i++)
                for (int j = y-1; j <= y+1; j++)
                {
                    Cell cell = field.GetCell(i, j);
                    if (cell != null)
                    {
                        if (cell.Ship != null)
                            return false;
                    }
                }

            return true;
        }
    }
}
