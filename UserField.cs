using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SeaFightGame
{
    public partial class VisualField : UserControl
    {
        private /*readonly*/ IDataField field;
        private readonly Brush brush;
        private readonly Pen pen;
        //private Graphics g;
        private const int X = 10;
        private const int Y = 10;
        private int width;
        private int height;
        private int dx;
        private int dy;

        public VisualField()
        {
            InitializeComponent();

            brush = new SolidBrush(Color.Black);
            pen = new Pen(brush);
        }

        public IDataField DataField
        {
            get { return field; }
            set { field = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = userFild.Width;
            int height = userFild.Height;

            for (int y = 0; y < Y; y++)
                g.DrawString((y + 1).ToString(), new Font("Arial", 12), brush, 20, y * height / Y + 20, new StringFormat { Alignment = StringAlignment.Far });
            string[] str = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            for (int x = 0; x < X; x++)
                g.DrawString(str[x], new Font("Arial", 12), brush, x * width / X + 30, 0);

            base.OnPaint(e);
        }

        private void userFiled_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            width = userFild.Width - 3;
            height = userFild.Height - 3;
            dx = width / X;
            dy = height / Y;

            for (int y = 0; y <= Y; y++)
                g.DrawLine(pen, 0, y * dy, width, y * dy);

            for (int x = 0; x <= X; x++)
                g.DrawLine(pen, x * dx, 0, x * dx, height);

            foreach (Cell cell in field.GetCells())
                DrawCell(g, cell);

            foreach (Ship ship in field.GetShips())
                DrawShip(g, ship);
        }

        private void DrawShip(Graphics g, Ship ship)
        {
            int x = ship.X1 * dx;
            int y = ship.Y1 * dy;
            int w = (ship.X2 - ship.X1 + 1) * dx ;
            int h = (ship.Y2 - ship.Y1 + 1) * dy ;

            g.DrawRectangle(pen, x+1, y+1, w-2, h-2);
        }

        private void DrawCell(Graphics g, Cell cell)
        {
            Pen pen = new Pen(new SolidBrush(Color.IndianRed), 3);

            if (!cell.IsFired)
                return;

            if (cell.Ship != null)
            {
                g.DrawLine(pen, cell.X * dx + 3, cell.Y * dy + 3, (cell.X + 1) * dx - 3, (cell.Y + 1) * dy - 3);
                g.DrawLine(pen, cell.X * dx + 3, (cell.Y + 1) * dy - 3, (cell.X + 1) * dx - 3, cell.Y * dy + 3);
                return;
            }

            pen = new Pen(new SolidBrush(Color.Gray));
            int x = cell.X * dx + dx / 2 - 2;
            int y = cell.Y * dy + dy / 2 - 2;
            g.DrawEllipse(pen, x, y, 4, 4);
            g.FillEllipse(new SolidBrush(Color.Gray), x, y, 4, 4);
        }

        private void userFild_MouseClick(object sender, MouseEventArgs e)
        {
            field.GetCell(e.X / dx, e.Y / dy).IsFired = true;

            int x = (e.X / dx) * dx;
            int y = (e.Y / dy) * dy;
            ((Panel)sender).Invalidate(new Rectangle(x, y, dx, dy), true);
        }
    }
}
