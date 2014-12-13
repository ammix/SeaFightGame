using System;
using System.Windows.Forms;
using SeaFightGame.Model;

namespace SeaFightGame.Algorithm
{
    public interface IPlayerShipSetup
    {
        void AddNewShip(MouseButtons buttons, int i, int j);
        void MoveNewShip(int i, int j);
        bool HasCompleted { get; }
        void Start();
        event Action<IShip> DrawShip;
        event Action<IShip> EraseShip;
    }
}
