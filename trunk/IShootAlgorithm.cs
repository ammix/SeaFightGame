using SeaFightGame.Model;

namespace SeaFightGame.Algorithm
{
    public interface IShootAlgorithm
    {
        void Shoot(ShootResult shootResult, out int i, out int j);
    }
}
