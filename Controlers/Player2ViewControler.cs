using System;
using System.Windows.Forms;
using SeaFightGame.Model;
using SeaFightGame.Algorithm;

namespace SeaFightGame.View
{
    public class Player2ViewControler : ViewControler
    {
        public Player2ViewControler(IField field, IGameLogic game)
            : base(field, game) { }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (game.IsRun)
                if (e.Button == MouseButtons.Left)
                {
                    int i, j;
                    GetPoint(e.X, e.Y, out i, out j);

                    game.Fire(i, j);
                }
        }
    }
}
