using System;
using System.Windows.Forms;
using SeaFightGame.Model;
using SeaFightGame.Algorithm;

namespace SeaFightGame.View
{
    public class Player2ViewControler : ViewControler
    {
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (IsInControlArea(e.X, e.Y))
            {
                if (Game.IsRun)
                    if (e.Button == MouseButtons.Left)
                    {
                        int i, j;
                        GetPoint(e.X, e.Y, out i, out j);
                        Game.Fire(i, j);
                    }
            }
        }
    }
}
