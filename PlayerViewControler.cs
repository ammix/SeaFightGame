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

        public PlayerViewControler(IField field)
            : base(field)
        {
            manualShipsSetup = new ManualShipsSetup(field, DrawShip, EraseShip);
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

        private void EraseShip(IShip ship)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Brush brush = new SolidBrush(this.BackColor);
            Pen pen = new Pen(brush);

            int width = Width - 2 * CellSize;
            int height = Height - 2 * CellSize;
            int dx = width / X;
            int dy = height / Y;

            for (int i = ship.X1; i <= ship.X2; i++)
                for (int j = ship.Y1; j <= ship.Y2; j++)
                {
                    int x = i * dx + CellSize;
                    int y = j * dy + CellSize;
                    g.DrawRectangle(pen, x + 1, y + 1, dx - 2, dy - 2);
                }
        }
    }
}
