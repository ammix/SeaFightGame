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
        private IField field1;
        private IField field2;
        private IField obfuscatedField2;

        IAiShipSetup aiShipSetup;
        IGameLogic gameLogic;

        private ViewControler field1View;
        private ViewControler field2View;

        public GameWindow()
        {
            InitializeComponent();

            field1 = new Field();
            field2 = new Field();
            obfuscatedField2 = new ObfuscatedField(field2);

            aiShipSetup = new AiShipSetup();
            IPlayerShipSetup playerShipSetup = new PlayerShipSetup(field1);
            IAiShipShoot shootAlgorithm = new AiShipShoot(field1.GetCells());
            gameLogic = new GameLogic(field1, obfuscatedField2, shootAlgorithm, playerShipSetup);

            field1View = new Player1ViewControler(field1, gameLogic);
            field2View = new Player2ViewControler(obfuscatedField2, gameLogic);

            this.field1View.Location = new System.Drawing.Point(12, 50);
            this.field1View.Size = new System.Drawing.Size(300, 300);
            this.Controls.Add(field1View);

            this.field2View.Location = new System.Drawing.Point(348, 50);
            this.field2View.Size = new System.Drawing.Size(300, 300);
            this.Controls.Add(field2View);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rectangle r = button1.ClientRectangle;
            int delta = (gameMenu.ClientRectangle.Width - r.Width) / 2;
            gameMenu.Show(button1.PointToScreen(new Point(r.Left - delta, r.Bottom)));
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGameDialog newGameDialog = new NewGameDialog();
            if (newGameDialog.ShowDialog() == DialogResult.OK)
            {
                field1.Clear();
                field2.Clear();

                aiShipSetup.Setup(field2);
                if (newGameDialog.AiShipSetup)
                    aiShipSetup.Setup(field1);
                gameLogic.Start(newGameDialog.AiShipSetup);

                field1View.Refresh();
                field2View.Refresh();

                // field2View.AutoSetupShips(algorithm);
                // AutoSetupShips(ICpuShipSetup algorithm)
            }
        }
    }
}
