﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using SeaFightGame.Model;
using SeaFightGame.Algorithm;

namespace SeaFightGame.View
{
    public partial class ViewControler : UserControl
    {
        protected IField field;
        private IGameLogic game;
        private const int X = GameConstants.X;
        private const int Y = GameConstants.Y;
        private const int Shift = GameConstants.SHIFT;

        public IField Field
        {
            get
            {
                return field;
            }
            set
            {
                field = value;
                BindWithShips();
            }
        }

        public IGameLogic Game
        {
            get 
            {
                return game;
            }
            set
            {
                game = value;
                //if (game != null)
                //{
                //    game.PlayerShipSetupAlgorithm.DrawShip += new Action<IShip>(DrawShip);
                //    game.PlayerShipSetupAlgorithm.EraseShip += new Action<IShip>(EraseShip);
                //}
            }
        }

        public ViewControler()
        {
            InitializeComponent();
        }

        private void BindWithShips()
        {
            if (field != null)
            {
                field.CellFired += new Action<ICell>(DrawCell);
                field.ShipFired += new Action<IShip>(DrawShip);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawField();

            if (field != null)
            {
                foreach (ICell cell in field.GetCells())
                    DrawCell(cell, false, false);

                foreach (Ship ship in field.GetShips())
                    DrawShip(ship);
            }
        }

        protected void GetPoint(int x, int y, out int i, out int j)
        {
            int width = Width - 2 * Shift;
            int height = Height - 2 * Shift;
            int dx = width / X;
            int dy = height / Y;

            i = (x - Shift) / dx;
            j = (y - Shift) / dy;
        }

        protected bool IsInControlArea(int x, int y)
        {
            return (x > Shift && x < Width - Shift && y > Shift && y < Width - Shift);
        }

        private void DrawField()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Font font = new Font("Arial", 12);
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
            StringFormat format = new StringFormat { Alignment = StringAlignment.Far };

            int width = Width - 2 * Shift;
            int height = Height - 2 * Shift;
            int dx = width / X;
            int dy = height / Y;

            for (int y = 0; y < Y; y++)
                g.DrawString((y + 1).ToString(), font, brush, Shift, y * dy + Shift, format);

            string[] str = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            for (int x = 0; x < X; x++)
                g.DrawString(str[x], font, brush, x * dx + Shift + 10, 0);

            for (int y = 0; y <= Y; y++)
                g.DrawLine(pen, Shift, y * dy + Shift, width + Shift, y * dy + Shift);

            for (int x = 0; x <= X; x++)
                g.DrawLine(pen, x * dx + Shift, Shift, x * dx + Shift, height + Shift);
        }

        public void DrawShip(IShip ship)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            bool isShipSetuped = ship.GetCells().GetEnumerator().MoveNext();
            Brush brush = new SolidBrush(isShipSetuped ? Color.Black : Color.Gray);
            Pen pen = new Pen(brush);

            int width = Width - 2 * Shift;
            int height = Height - 2 * Shift;
            int dx = width / X;
            int dy = height / Y;

            int x = ship.X1 * dx + Shift;
            int y = ship.Y1 * dy + Shift;
            int w = (ship.X2 - ship.X1 + 1) * dx;
            int h = (ship.Y2 - ship.Y1 + 1) * dy;

            //foreach (ICell cell in ship.GetCells())
            //    DrawCell(cell, false, true);

            g.DrawRectangle(pen, x + 1, y + 1, w - 2, h - 2);
            if (ship.IsFired)
                g.FillRectangle(new SolidBrush(Color.LightGray), x + 2, y + 2, w - 3, h - 3);
        }

        public void EraseShip(IShip ship)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Brush brush = new SolidBrush(this.BackColor);
            Pen pen = new Pen(brush);

            int width = Width - 2 * Shift;
            int height = Height - 2 * Shift;
            int dx = width / X;
            int dy = height / Y;

            for (int i = ship.X1; i <= ship.X2; i++)
                for (int j = ship.Y1; j <= ship.Y2; j++)
                {
                    int x = i * dx + Shift;
                    int y = j * dy + Shift;
                    g.DrawRectangle(pen, x + 1, y + 1, dx - 2, dy - 2);
                }
        }

        private void DrawCell(ICell cell)
        {
            DrawCell(cell, true, false);
        }

        private void DrawCell(ICell cell, bool animation, bool hasShip)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Brush brush0 = new SolidBrush(this.BackColor);
            Brush brush1 = new SolidBrush(Color.IndianRed);
            Brush brush2 = new SolidBrush(Color.Gray);
            Brush brush3 = new SolidBrush(Color.Tomato);
            Pen pen1 = new Pen(brush1, 3);
            Pen pen2 = new Pen(brush2);

            int width = Width - 2 * Shift;
            int height = Height - 2 * Shift;
            int dx = width / X;
            int dy = height / Y;
            int i = cell.X;
            int j = cell.Y;
            int x, y;

            switch (cell.HasShip)
            {
                case null:
                    break;
                case false:
                    if (animation)
                    {
                        x = i * dx + Shift + 1;
                        y = j * dy + Shift + 1;
                        g.FillRectangle(brush3, x, y, dx - 1, dy - 1);
                        System.Threading.Thread.Sleep(50);
                        g.FillRectangle(brush0, x, y, dx - 1, dy - 1);
                    }
                    x = i * dx + dx / 2 + Shift - 2;
                    y = j * dy + dy / 2 + Shift - 2;
                    g.DrawEllipse(pen2, x, y, 4, 4);
                    g.FillEllipse(brush2, x, y, 4, 4);
                    break;
                case true:
                    g.DrawLine(pen1, i * dx + Shift + 3, j * dy + Shift + 3, (i + 1) * dx + Shift - 3, (j + 1) * dy + Shift - 3);
                    g.DrawLine(pen1, i * dx + Shift + 3, (j + 1) * dy + Shift - 3, (i + 1) * dx + Shift - 3, j * dy + Shift + 3);
                    break;
            }
        }
    }
}
