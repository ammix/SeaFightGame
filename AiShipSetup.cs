using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeaFightGame.Model;

namespace SeaFightGame.Algorithm
{
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
