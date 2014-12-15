using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SeaFightGame.Model;

namespace SeaFightGame.Algorithm
{
    public class PlayerShipSetup: IPlayerShipSetup
    {
        #region Fields

        private bool newShipFlag = true;
        private IShip ship;
        private int deckNumber = 3;
        private int direction = 0;
        private int shipNumber = 0;

        private int prev_x, prev_y, prev_dir;

        private IField field;
        public event Action<IShip> DrawShip;
        public event Action<IShip> EraseShip;

        #endregion

        public PlayerShipSetup(IField field)
        {
            this.field = field;
        }

        public bool HasCompleted
        {
            get { return shipNumber >= ShipSetupUtils.ShipsStock.Length; }
        }

        public void Start()
        {
            shipNumber = 0;
            direction = 0;
            deckNumber = 3;
            newShipFlag = true;
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
                        if (ShipSetupUtils.HasShipContact(field, x1, y1, x2, y2))
                            return;

                        ship = field.GetShip(x1, y1, x2, y2);
                        //ship.Fired += DrawShip;
                        newShipFlag = false;

                        if (DrawShip != null)
                            DrawShip(ship);
                    }
                    else
                    {
                        field.AddShip(ship);
                        if (DrawShip != null)
                            DrawShip(ship);
                        newShipFlag = true;
                        shipNumber++;

                        if (HasCompleted)
                            return;

                        //if (shipNumber >= ShipSetupUtils.ShipsStock.Length)
                        //    shipNumber = ShipSetupUtils.ShipsStock.Length - 1;
                        deckNumber = ShipSetupUtils.ShipsStock[shipNumber] - 1;
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
                        return;
                    }
                    break;
            }
        }

        public void MoveNewShip(int i, int j)
        {
            if (i == prev_x && j == prev_y && direction == prev_dir)
                return;

            if (!newShipFlag)
            {
                int x1 = i, x2 = i;
                int y1 = j, y2 = j;
                ShipSetupUtils.GetShipTail(x1, y1, deckNumber, direction, out x2, out y2);

                if (ShipSetupUtils.HasShipContact(field, x1, y1, x2, y2))
                    return;


                if (!(x2 < 0 || x2 >= 10 || y2 < 0 || y2 >= 10))
                {
                    if (EraseShip != null)
                        EraseShip(ship);

                    field.UpdateShip(ship, x1, y1, x2, y2);

                    if (DrawShip != null)
                        DrawShip(ship);

                    prev_x = x1;
                    prev_y = y1;
                    prev_dir = direction;
                }
            }
        }
    }
}
