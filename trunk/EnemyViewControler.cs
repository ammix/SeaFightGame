using System;
using System.Windows.Forms;
using SeaFightGame.Model;

namespace SeaFightGame.View
{
    public class EnemyViewControler : ViewController
    {
        public EnemyViewControler(IField field)
            : base(field)
        { }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int i, j;
            GetPoint(e.X, e.Y, out i, out j);

            field.Fire(i, j);
        }
    }
}
