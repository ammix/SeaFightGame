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

        //private ViewControler field1View;
        //private ViewControler field2View;

        public GameWindow()
        {
            InitializeComponent();

            field1 = new Field();
            field2 = new Field();
            obfuscatedField1 = new ObfuscatedField(field1);
            obfuscatedField2 = new ObfuscatedField(field2);
            aiShipSetup = new AiShipSetup();

            IPlayerShipSetup playerShipSetup = new PlayerShipSetup(field1);
            IAiShipShoot shootAlgorithm = new AiShipShoot(obfuscatedField1);
            gameLogic = new GameLogic(field1, field2, playerShipSetup, new AiShipSetup(), shootAlgorithm);

            //field1View = new Player1ViewControler(); //(field1, gameLogic);
            player1ViewControler.Field = field1;
            player1ViewControler.Game = gameLogic;
            //field2View = new Player2ViewControler(); //(obfuscatedField2, gameLogic);
            player2ViewControler.Field = obfuscatedField2;
            player2ViewControler.Game = gameLogic;

            //this.field1View.Location = new System.Drawing.Point(12, 50);
            //this.field1View.Size = new System.Drawing.Size(300, 300);
            //this.Controls.Add(field1View);

            //this.field2View.Location = new System.Drawing.Point(348, 50);
            //this.field2View.Size = new System.Drawing.Size(300, 300);
            //this.Controls.Add(field2View);
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
