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
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (IsInControlArea(e.X, e.Y))
            {
                if (!Game.IsRun)
                {
                    if (!Game.PlayerShipSetupAlgorithm.HasCompleted)
                    {
                        int i, j;
                        GetPoint(e.X, e.Y, out i, out j);

                        Game.PlayerShipSetupAlgorithm.AddNewShip(e.Button, i, j);
                        if (Game.PlayerShipSetupAlgorithm.HasCompleted)
                        {
                            Game.Start(true);
                        }
                    }
                    //else
                    //{
                    //    game.Start();
                    //}
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!Game.IsRun)
                if (!Game.PlayerShipSetupAlgorithm.HasCompleted)
                {
                    int i, j;
                    GetPoint(e.X, e.Y, out i, out j);

                    Game.PlayerShipSetupAlgorithm.MoveNewShip(i, j);
                }
        }
    }
}
