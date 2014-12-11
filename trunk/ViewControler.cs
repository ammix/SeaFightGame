using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using SeaFightGame.Model;

namespace SeaFightGame.View
{
    public partial class ViewController : UserControl
    {
        protected readonly IField field;
        protected const int X = 10;
        protected const int Y = 10;
        protected const int CellSize = 20;

        public ViewController(IField field)
        {
            InitializeComponent();
            this.field = field;

            foreach (ICell cell in field.GetCells())
                cell.Fired += new Action<ICell>(DrawCell);
        }

        public void AutoSetupShips(IShipsSetupAlgorithm algorithm)
        {
            field.Clear();
            algorithm.Setup(field);
            foreach (IShip ship in field.GetShips())
                ship.StateChanged += new Action<IShip>(DrawShip);
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

        protected void GetPoint(int x, int y, out int i, out int j)
        {
            int width = Width - 2 * CellSize;
            int height = Height - 2 * CellSize;
            int dx = width / X;
            int dy = height / Y;

            i = (x - CellSize) / dx;
            j = (y - CellSize) / dy;
        }

        private void DrawField()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Font font = new Font("Arial", 12);
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
            StringFormat format = new StringFormat { Alignment = StringAlignment.Far };

            int width = Width - 2 * CellSize;
            int height = Height - 2 * CellSize;
            int dx = width / X;
            int dy = height / Y;

            for (int y = 0; y < Y; y++)
                g.DrawString((y + 1).ToString(), font, brush, CellSize, y * dy + CellSize, format);

            string[] str = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            for (int x = 0; x < X; x++)
                g.DrawString(str[x], font, brush, x * dx + CellSize + 10, 0);

            for (int y = 0; y <= Y; y++)
                g.DrawLine(pen, CellSize, y * dy + CellSize, width + CellSize, y * dy + CellSize);

            for (int x = 0; x <= X; x++)
                g.DrawLine(pen, x * dx + CellSize, CellSize, x * dx + CellSize, height + CellSize);
        }

        protected void DrawShip(IShip ship)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            bool isShipSetuped = field.GetCell(ship.X1, ship.Y1).HasShip;
            Brush brush = new SolidBrush(isShipSetuped ? Color.Black : Color.Gray);
            Pen pen = new Pen(brush);

            int width = Width - 2 * CellSize;
            int height = Height - 2 * CellSize;
            int dx = width / X;
            int dy = height / Y;

            int x = ship.X1 * dx + CellSize;
            int y = ship.Y1 * dy + CellSize;
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

                int width = Width - 2 * CellSize;
                int height = Height - 2 * CellSize;
                int dx = width / X;
                int dy = height / Y;

                if (cell.HasShip)
                {
                    int x = cell.X;
                    int y = cell.Y;
                    g.DrawLine(pen1, x * dx + CellSize + 3, y * dy + CellSize + 3, (x + 1) * dx + CellSize - 3, (y + 1) * dy + CellSize - 3);
                    g.DrawLine(pen1, x * dx + CellSize + 3, (y + 1) * dy + CellSize - 3, (x + 1) * dx + CellSize - 3, y * dy + CellSize + 3);
                    return;
                }
                else
                {
                    int x = cell.X * dx + dx / 2 - 2;
                    int y = cell.Y * dy + dy / 2 - 2;
                    g.DrawEllipse(pen2, x + CellSize, y + CellSize, 4, 4);
                    g.FillEllipse(brush2, x + CellSize, y + CellSize, 4, 4);
                }
            }
        }
    }
}
