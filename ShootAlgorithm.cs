using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaFightGame.Model
{
    public class ShootAlgorithm: IShootAlgorithm
    {
        private static Random r = new Random(DateTime.Now.Millisecond);

        public void Shoot(out int i, out int j)
        {
            i = r.Next(10);
            j = r.Next(10);
        }
    }
}
