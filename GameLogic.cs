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
        private IShootAlgorithm ai;
        private IPlayerShipSetup playerShipSetup;
        private bool isRun = false;

        public GameLogic(IField field1, IField field2, IShootAlgorithm ai, IPlayerShipSetup playerShipSetup)
        {
            this.field1 = field1;
            this.field2 = field2;
            this.ai = ai;
            this.playerShipSetup = playerShipSetup;
        }

        public IPlayerShipSetup PlayerShipSetupAlgorithm
        {
            get { return playerShipSetup; }
        }

        public void Fire(int i, int j)
        {
            ShootResult shootResult = field2.Fire(i, j);
            if (shootResult == ShootResult.Miss)
            {
                do
                {
                    ai.Shoot(shootResult, out i, out j);
                    //if (field1.GetCell(i,j).IsFired)
                    //    throw new ApplicationException();
                    shootResult = field1.Fire(i, j);
                }
                while (shootResult== ShootResult.Hurt || shootResult == ShootResult.Ruin);
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

        //public event Action<bool> Shooted;
    }
}
