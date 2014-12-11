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
        private IGameLogic game;

        public PlayerViewControler(IField field, IGameLogic game, ManualShipsSetup manualShipsSetup)
            : base(field)
        {
            this.manualShipsSetup = manualShipsSetup;
            this.game = game;
            manualShipsSetup.DrawShip += new Action<IShip>(DrawShip);
            manualShipsSetup.EraseShip += new Action<IShip>(EraseShip);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!game.IsRun)
            {
                if (!manualShipsSetup.HasCompleted)
                {
                    int i, j;
                    GetPoint(e.X, e.Y, out i, out j);

                    manualShipsSetup.AddNewShip(e.Button, i, j);
                }
                else
                {
                    game.Start();
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!game.IsRun)
                if (!manualShipsSetup.HasCompleted)
                {
                    int i, j;
                    GetPoint(e.X, e.Y, out i, out j);

                    manualShipsSetup.MoveNewShip(i, j);
                }
        }
    }
}
