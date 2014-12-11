using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SeaFightGame.Model;

namespace SeaFightGame
{
    public class ManualShipsSetup
    {
        private bool newShipFlag = true;
        private IShip ship;
        private int deckNumber = 3;
        private int direction = 0;
        private int shipNumber = 0;
        private int x = 0;
        private int y = 0;

        private IField field;
        public event Action<IShip> DrawShip;
        public event Action<IShip> EraseShip;

        public ManualShipsSetup(IField field)
        {
            this.field = field;
        }

        public bool HasCompleted
        {
            get { return shipNumber >= ShipSetupUtils.ShipsStock.Length; }
        }

        public void AddNewShip(MouseButtons buttons, int i, int j)
        {
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            switch (buttons)
            {
                case MouseButtons.Left:
                    if (newShipFlag)
                    {
                        x1 = i;
                        y1 = j;
                        x2 = i;
                        y2 = j;
                        ShipSetupUtils.GetShipTail(x1, y1, deckNumber, direction, out x2, out y2);
                        if (ShipHasNeighbours(x1, y1, x2, y2))
                            return;

                        ship = field.GetShip(x1, y1, x2, y2);
                        newShipFlag = false;
                    }
                    else
                    {
                        field.AddShip(ship);
                        newShipFlag = true;
                        int n = ++shipNumber;
                        if (n >= ShipSetupUtils.ShipsStock.Length)
                            n = ShipSetupUtils.ShipsStock.Length - 1;
                        deckNumber = ShipSetupUtils.ShipsStock[n] - 1;

                        if (DrawShip != null)
                            DrawShip(ship);
                    }
                    break;
                case MouseButtons.Right:
                    if (ship == null)
                        return;

                    int tmp = direction;
                    direction += 1;

                    if (direction == 2)
                        direction = 0;

                    x1 = ship.X1;
                    y1 = ship.Y1;
                    x2 = ship.X2;
                    y2 = ship.Y2;
                    ShipSetupUtils.GetShipTail(x1, y1, deckNumber, direction, out x2, out y2);
                    if (x2 < 0 || x2 >= 10 || y2 < 0 || y2 >= 10)
                    {
                        direction = tmp;
                    }
                    break;
            }
        }

        public void MoveNewShip(int i, int j)
        {
            if (x == i && y == j)
                return;

            if (!newShipFlag)
            {
                int x1 = i, x2 = i;
                int y1 = j, y2 = j;
                ShipSetupUtils.GetShipTail(x1, y1, deckNumber, direction, out x2, out y2);

                if (ShipHasNeighbours(x1, y1, x2, y2))
                    return;

                if (EraseShip != null)
                    EraseShip(ship);

                if (!(x2 < 0 || x2 >= 10 || y2 < 0 || y2 >= 10))
                {
                    field.UpdateShip(ship, x1, y1, x2, y2);
                }

                if (DrawShip != null)
                    DrawShip(ship);

                x = x1;
                y = y1;
            }
        }

        private bool ShipHasNeighbours(int x1, int y1, int x2, int y2)
        {
            for (int x = x1 - 1; x <= x2 + 1; x++)
                for (int y = y1 - 1; y <= y2 + 1; y++)
                {
                    ICell cell = field.GetCell(x, y);
                    if (cell != null && cell.HasShip)
                        return true;
                }
            return false;
        }
    }
}
