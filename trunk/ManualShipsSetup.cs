using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeaFightGame
{
    public class ManualShipsSetup
    {
        private bool newShipFlag = true;
        private IShip ship;
        private int deckNumber = 3;
        private int direction = 0;
        private int shipNumber = 0;

        private IField field;
        private Action<IShip> drawShip;
        private Action<IShip> eraseShip;

        public ManualShipsSetup(IField field, Action<IShip> drawShip, Action<IShip> eraseShip)
        {
            this.field = field;
            this.drawShip = drawShip;
            this.eraseShip = eraseShip;
        }
        public bool HasCompleted { get; set; }
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
                        drawShip(ship);
                        newShipFlag = false;
                    }
                    else
                    {
                        field.AddShip(ship);
                        newShipFlag = true;
                        deckNumber = ShipSetupUtils.ShipsStock[++shipNumber] - 1;
                    }
                    break;
                case MouseButtons.Right:
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
            //ship.Fired += new Action<IShip>(drawShip);
        }
        public void MoveNewShip(int i, int j)
        {
            if (!newShipFlag)
            {
                int x1 = i, x2 = i;
                int y1 = j, y2 = j;
                ShipSetupUtils.GetShipTail(x1, y1, deckNumber, direction, out x2, out y2);

                if (ShipHasNeighbours(x1, y1, x2, y2))
                    return;

                eraseShip(ship);
                if (!(x2 < 0 || x2 >= 10 || y2 < 0 || y2 >= 10))
                {
                    field.UpdateShip(ship, x1, y1, x2, y2);
                }
                drawShip(ship);
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
