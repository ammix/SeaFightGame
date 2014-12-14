using System;
using System.Drawing;
using System.Windows.Forms;
using SeaFightGame.Model;
using SeaFightGame.View;
using SeaFightGame.Algorithm;

namespace SeaFightGame.View
{
    public class Player1ViewControler : ViewControler
    {
        public Player1ViewControler(IField field, IGameLogic game)
            : base(field, game)
        {
            game.PlayerShipSetupAlgorithm.DrawShip += new Action<IShip>(DrawShip);
            game.PlayerShipSetupAlgorithm.EraseShip += new Action<IShip>(EraseShip);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!game.IsRun)
            {
                if (!game.PlayerShipSetupAlgorithm.HasCompleted)
                {
                    int i, j;
                    GetPoint(e.X, e.Y, out i, out j);

                    game.PlayerShipSetupAlgorithm.AddNewShip(e.Button, i, j);
                    if (game.PlayerShipSetupAlgorithm.HasCompleted)
                    {
                        game.Start(true);
                        BindWithShips();
                    }
                }
                //else
                //{
                //    game.Start();
                //}
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!game.IsRun)
                if (!game.PlayerShipSetupAlgorithm.HasCompleted)
                {
                    int i, j;
                    GetPoint(e.X, e.Y, out i, out j);

                    game.PlayerShipSetupAlgorithm.MoveNewShip(i, j);
                }
        }
    }
}
