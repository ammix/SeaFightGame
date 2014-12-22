using System;
using System.Collections.Generic;
using SeaFightGame.Algorithm;
using SeaFightGame.Model;

namespace SeaFightGame.Algorithm
{
    public class GameLogic : IGameLogic
    {
        private IField field1;
        private IField field2;
        private IAiShipShoot ai;
        private IAiShipSetup aiShipSetup;
        private IPlayerShipSetup playerShipSetup;
        private bool isRun = false;

        public GameLogic(IField field1, IField field2, IPlayerShipSetup playerShipSetup, IAiShipSetup aiShipSetup, IAiShipShoot ai)
        {
            this.field1 = field1;
            this.field2 = field2;
            this.ai = ai;
            this.playerShipSetup = playerShipSetup;
            this.aiShipSetup = aiShipSetup;
            field1.FieldFired += GameOver;
            field2.FieldFired += GameOver;
        }

        private void Initialize()
        {
            isRun = false;
            //playerShipSetup.Start();
        }

        private void GameOver(IField field)
        {
            if (GameOvered != null)
                GameOvered(field);
            Initialize();

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

        public void Start(bool aiShipSetupFlag)
        {
            field1.Clear();
            field2.Clear();

            if (aiShipSetupFlag)
                aiShipSetup.Setup(field1);
            aiShipSetup.Setup(field2);

            isRun = aiShipSetupFlag;
            playerShipSetup.Start();
        }


        public event Action<IField> GameOvered;
    }
}
