using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame.Model
{
    public class GameLogic: IGameLogic
    {
        private IField field1;
        private IField field2;
        private IShootAlgorithm ai;
        private bool isRun = false;

        public GameLogic(IField field1, IField field2, IShootAlgorithm ai)
        {
            this.field1 = field1;
            this.field2 = field2;
            this.ai = ai;
        }

        public void Fire(int i, int j)
        {
            if (!field2.Fire(i, j))
            {
                do
                {
                    ai.Shoot(out i, out j);
                    if (MoveHasDone != null)
                        MoveHasDone(false);
                }
                while (field1.Fire(i, j));
            }
            if (MoveHasDone != null)
                MoveHasDone(true);
        }

        public bool IsRun
        {
            get { return isRun; }
        }

        public void Start()
        {
            isRun = true;
        }

        public event Action<bool> MoveHasDone;
    }
}
