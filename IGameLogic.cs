using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame.Algorithm
{
    public interface IGameLogic
    {
        void Fire(int i, int j);
        bool IsRun { get; }
        void Start();
        event Action<bool> MoveHasDone;
    }
}
