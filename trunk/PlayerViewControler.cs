using System;
using System.Drawing;
using System.Windows.Forms;
using SeaFightGame.Model;
using SeaFightGame.View;

namespace SeaFightGame
{
    public class PlayerViewControler : ViewController
    {
        private ManualShipsSetup manualShipsSetup;

        public PlayerViewControler(IField field, ManualShipsSetup manualShipsSetup)
            : base(field)
        {
            this.manualShipsSetup = manualShipsSetup;
            manualShipsSetup.DrawShip += new Action<IShip>(DrawShip);
            manualShipsSetup.EraseShip += new Action<IShip>(EraseShip);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int i, j;
            GetPoint(e.X, e.Y, out i, out j);

            if (!manualShipsSetup.HasCompleted)
            {
                manualShipsSetup.AddNewShip(e.Button, i, j);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!manualShipsSetup.HasCompleted)
            {
                int i, j;
                GetPoint(e.X, e.Y, out i, out j);

                manualShipsSetup.MoveNewShip(i, j);
            }
        }
    }
}
