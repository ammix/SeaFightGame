using System;

namespace SeaFightGame.Model
{
    public interface ICell
    {
        int X { get; set; }
        int Y { get; set; }
        bool HasShip { get; }
        bool IsFired { get; }
        event Action<ICell> Fired;
    }
}
