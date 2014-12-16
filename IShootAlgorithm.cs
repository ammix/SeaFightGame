using SeaFightGame.Model;

namespace SeaFightGame.Algorithm
{
    public interface IAiShipShoot
    {
        void Shoot(ShootResult shootResult, out int i, out int j);
    }
}
