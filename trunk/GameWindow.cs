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
        private IField obfuscatedField1;
        private IField obfuscatedField2;

        IAiShipSetup aiShipSetup;
        IGameLogic gameLogic;

        public GameWindow()
        {
            InitializeComponent();

            field1 = new Field("Player1");
            field2 = new Field("Player2");
            obfuscatedField1 = new ObfuscatedField(field1);
            obfuscatedField2 = new ObfuscatedField(field2);
            aiShipSetup = new AiShipSetup();

            IPlayerShipSetup playerShipSetup = new PlayerShipSetup(field1);
            playerShipSetup.DrawShip += player1ViewControler.DrawShip;
            playerShipSetup.EraseShip += player1ViewControler.EraseShip;
            IAiShipShoot shootAlgorithm = new AiShipShoot(obfuscatedField1);
            gameLogic = new GameLogic(field1, field2, playerShipSetup, new AiShipSetup(), shootAlgorithm);
            gameLogic.GameOvered += GameOver;

            player1ViewControler.Field = field1;
            player1ViewControler.Game = gameLogic;

            player2ViewControler.Field = obfuscatedField2;
            player2ViewControler.Game = gameLogic;
        }

        private void GameOver(IField obj)
        {
            switch (obj.PlayerName)
            {
                case "Player1":
                    MessageBox.Show("GAME IS OVER! YOU LOSE!");
                    break;
                case "Player2":
                    MessageBox.Show("GAME IS OVER! YOU WIN!");
                    break;
            }
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
                gameLogic.Start(newGameDialog.AiShipSetup);

                player1ViewControler.Refresh();
                player2ViewControler.Refresh();
            }
        }

        private void показатиКорабліToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if ((sender as ToolStripMenuItem).Checked)
            {
                player2ViewControler.Field = field2;
                player2ViewControler.Refresh();
                //(sender as ToolStripMenuItem).Checked = false;
            }
        }
    }
}
