using System;
using System.Collections.Generic;
using SeaFightGame.Algorithm;
using SeaFightGame.Model;

namespace SeaFightGame.Algorithm
{
    public class GameLogic: IGameLogic
    {
        private IField field1;
        private IField field2;
        private IAiShipShoot ai;
        private IPlayerShipSetup playerShipSetup;
        private bool isRun = false;

        public GameLogic(IField field1, IField field2, IAiShipShoot ai, IPlayerShipSetup playerShipSetup)
        {
            this.field1 = field1;
            this.field2 = field2;
            this.ai = ai;
            this.playerShipSetup = playerShipSetup;
            field1.FieldFired += ShowLoser;
            field2.FieldFired += ShowWinner;
        }

        private void Initialize()
        {
            isRun = false;
            //playerShipSetup.Start();
        }

        private void ShowWinner(IField field)
        {
            Initialize();
            System.Windows.Forms.MessageBox.Show("GAME IS OVER! YOU WIN!");
        }

        private void ShowLoser(IField field)
        {
            Initialize();
            System.Windows.Forms.MessageBox.Show("GAME IS OVER! YOU LOSE!");
        }

        public IPlayerShipSetup PlayerShipSetupAlgorithm
        {
            get { return playerShipSetup; }
        }

        public void Fire(int i, int j)
        {
            if (!field2.Fire(i, j))
            {
                do
                {
                    if (!isRun)
                        break;
                    ai.GetShoot(out i, out j);
                }
                while (field1.Fire(i, j));
            }
        }

        public bool IsRun
        {
            get { return isRun; }
        }

        public void Start(bool flag)
        {
            isRun = flag;
            playerShipSetup.Start();
        }
    }
}
