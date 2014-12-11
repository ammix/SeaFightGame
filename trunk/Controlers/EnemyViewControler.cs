using System;
using System.Windows.Forms;
using SeaFightGame.Model;

namespace SeaFightGame.View
{
    public class EnemyViewControler : ViewController
    {
        private IGameLogic game;

        public EnemyViewControler(IField field, IGameLogic game)
            : base(field)
        {
            this.game = game;
        }

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
