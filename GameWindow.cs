using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SeaFightGame.Model;
using SeaFightGame.View;
using SeaFightGame.Algorithm;

namespace SeaFightGame
{
    public partial class GameWindow : Form
    {
        private Field field1;
        private Field field2;

        ICpuShipSetup cpuShipSetup;

        private ViewController field1View;
        private ViewController field2View;

        public GameWindow()
        {
            InitializeComponent();

            field1 = new Field();
            field2 = new Field();

            cpuShipSetup = new CpuShipSetup();
            IPlayerShipSetup playerShipSetup = new PlayerShipSetup(field1);
            IShootAlgorithm shootAlgorithm = new ShootAlgorithm();

            IGameLogic gameLogic = new GameLogic(field1, field2, shootAlgorithm);

            field1View = new PlayerViewControler(field1, gameLogic, playerShipSetup);
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
            int delta = (gameMenu.ClientRectangle.Width - r.Width) / 2;
            gameMenu.Show(button1.PointToScreen(new Point(r.Left - delta, r.Bottom)));
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGameDialog newGameWindow = new NewGameDialog();
            if (newGameWindow.ShowDialog() == DialogResult.OK)
            {
                //System.Windows.Forms.CommonDialog
            }

            cpuShipSetup.Setup(field1);
            field1View.Refresh();

            // AutoSetupShips(ICpuShipSetup algorithm)
        }
    }
}
