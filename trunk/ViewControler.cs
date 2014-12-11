using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SeaFightGame
{
    public partial class ViewController : UserControl
    {
        private readonly IField field;
        private const int X = 10;
        private const int Y = 10;
        private const int D = 20;

        ManualShipsSetup manualShipsSetup;

        public ViewController(IField field)
        {
            InitializeComponent();
            this.field = field;
            manualShipsSetup = new ManualShipsSetup(field, DrawShip, EraseShip);

            foreach (ICell cell in field.GetCells())
                cell.Fired += new Action<ICell>(DrawCell);
        }

        public void AutoSetupShips(IShipsSetupAlgorithm algorithm)
        {
            field.Clear();
            algorithm.Setup(field);
            foreach (IShip ship in field.GetShips())
                ship.Fired += new Action<IShip>(DrawShip);
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawField();

            foreach (ICell cell in field.GetCells())
                DrawCell(cell);

            foreach (Ship ship in field.GetShips())
                DrawShip(ship);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int i, j;
            GetPoint(e.X, e.Y, out i, out j);

            if (manualShipsSetup.HasCompleted)
            {
                //game.Fire(e.Button, i, j);
            }
            else
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

        private void GetPoint(int x, int y, out int i, out int j)
        {
            int width = Width - 2 * D;
            int height = Height - 2 * D;
            int dx = width / X;
            int dy = height / Y;

            i = (x - D) / dx;
            j = (y - D) / dy;
        }

        private void DrawField()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Font font = new Font("Arial", 12);
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
            StringFormat format = new StringFormat { Alignment = StringAlignment.Far };

            int width = Width - 2 * D;
            int height = Height - 2 * D;
            int dx = width / X;
            int dy = height / Y;

            for (int y = 0; y < Y; y++)
                g.DrawString((y + 1).ToString(), font, brush, D, y * dy + D, format);

            string[] str = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            for (int x = 0; x < X; x++)
                g.DrawString(str[x], font, brush, x * dx + D + 10, 0);

            for (int y = 0; y <= Y; y++)
                g.DrawLine(pen, D, y * dy + D, width + D, y * dy + D);

            for (int x = 0; x <= X; x++)
                g.DrawLine(pen, x * dx + D, D, x * dx + D, height + D);
        }

        private void EraseShip(IShip ship)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Brush brush = new SolidBrush(this.BackColor);
            Pen pen = new Pen(brush);

            int width = Width - 2 * D;
            int height = Height - 2 * D;
            int dx = width / X;
            int dy = height / Y;

            for (int i = ship.X1; i <= ship.X2; i++)
                for (int j = ship.Y1; j <= ship.Y2; j++)
                {
                    int x = i * dx + D;
                    int y = j * dy + D;
                    g.DrawRectangle(pen, x + 1, y + 1, dx - 2, dy - 2);
                }
        }

        private void DrawShip(IShip ship)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);

            int width = Width - 2 * D;
            int height = Height - 2 * D;
            int dx = width / X;
            int dy = height / Y;

            int x = ship.X1 * dx + D;
            int y = ship.Y1 * dy + D;
            int w = (ship.X2 - ship.X1 + 1) * dx;
            int h = (ship.Y2 - ship.Y1 + 1) * dy;

            g.DrawRectangle(pen, x + 1, y + 1, w - 2, h - 2);
            if (ship.IsFired)
                g.FillRectangle(new SolidBrush(Color.LightGray), x + 2, y + 2, w - 3, h - 3);
        }

        private void DrawCell(ICell cell)
        {
            if (cell.IsFired)
            {
                Graphics g = Graphics.FromHwnd(this.Handle);
                Brush brush1 = new SolidBrush(Color.IndianRed);
                Brush brush2 = new SolidBrush(Color.Gray);
                Pen pen1 = new Pen(brush1, 3);
                Pen pen2 = new Pen(brush2);

                int width = Width - 2 * D;
                int height = Height - 2 * D;
                int dx = width / X;
                int dy = height / Y;

                if (cell.HasShip)
                {
                    int x = cell.X;
                    int y = cell.Y;
                    g.DrawLine(pen1, x * dx + D + 3, y * dy + D + 3, (x + 1) * dx + D - 3, (y + 1) * dy + D - 3);
                    g.DrawLine(pen1, x * dx + D + 3, (y + 1) * dy + D - 3, (x + 1) * dx + D - 3, y * dy + D + 3);
                    return;
                }
                else
                {
                    int x = cell.X * dx + dx / 2 - 2;
                    int y = cell.Y * dy + dy / 2 - 2;
                    g.DrawEllipse(pen2, x + D, y + D, 4, 4);
                    g.FillEllipse(brush2, x + D, y + D, 4, 4);
                }
            }
        }
    }
}
