using System;

namespace SeaFightGame.Algorithm
{
    public interface IGameLogic
    {
        void Fire(int i, int j);
        bool IsRun { get; }
        void Start(bool flag);
        IPlayerShipSetup PlayerShipSetupAlgorithm { get; }
    }
}
