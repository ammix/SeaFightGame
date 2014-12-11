using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SeaFightGame.Model;
using SeaFightGame.View;

namespace SeaFightGame
{
    public partial class MainWindow : Form
    {
        private ViewController field1View;
        private ViewController field2View;
        private IShipsSetupAlgorithm algorithm;

        public MainWindow()
        {
            InitializeComponent();

            Field field1 = new Field();
            Field field2 = new Field();
            algorithm = new AutoShipsSetup();
            IShootAlgorithm ai = new ShootAlgorithm();
            IGameLogic gameLogic = new GameLogic(field1, field2, ai);
            gameLogic.MoveHasDone += DrawArrow;
            ManualShipsSetup shipsSetupLogic = new ManualShipsSetup(field1);

            field1View = new PlayerViewControler(field1, gameLogic, shipsSetupLogic);
            field2View = new EnemyViewControler(field2, gameLogic);

            this.field1View.Location = new System.Drawing.Point(12, 50);
            this.field1View.Size = new System.Drawing.Size(300, 300);
            this.Controls.Add(field1View);

            this.field2View.Location = new System.Drawing.Point(348, 50);
            this.field2View.Size = new System.Drawing.Size(300, 300);
            this.Controls.Add(field2View);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //field2View.AutoSetupShips(algorithm);

            Rectangle r = button1.ClientRectangle;
            int delta = (contextMenuStrip1.ClientRectangle.Width - r.Width) / 2;
            contextMenuStrip1.Show(button1.PointToScreen(new Point(r.Left - delta, r.Bottom)));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawArrow(false);
        }

        //private void DrawArrow(bool playerFlag)
        //{
        //    Graphics g = Graphics.FromHwnd(this.Handle);
        //}

        private void DrawArrow(bool direction)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Color color;
            Point p1, p2, p3;
            if (!direction)
            {
                color = Color.Red;
                p1 = new Point(315, 175);
                p2 = new Point(315, 225);
                p3 = new Point(345, 200);
            }
            else
            {
                color = Color.LawnGreen;
                p1 = new Point(345, 175);
                p2 = new Point(345, 225);
                p3 = new Point(315, 200);
            }
            g.FillPolygon(new SolidBrush(color), new Point[] { p1, p2, p3 });
        }
    }
}
