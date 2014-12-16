using System;
using System.Collections.Generic;

namespace SeaFightGame.Model
{
    public class Cell: ICell
    {
        private ShootResult state = ShootResult.Free;

        public int X { get; set; }
        public int Y { get; set; }
        public IShip Ship { get; set; }
        public ShootResult State
        {
            get { return state; }
        }

        public void Clear()
        {
            state = ShootResult.Free;
        }

        public ShootResult Fire()
        {
            if (state == ShootResult.Free)
            {
                state = Ship != null ? ShootResult.Hurt : ShootResult.Miss;

                //state = ShootResult.Miss;
                //if (Ship != null)
                //{
                //    state = Ship.IsFired ? ShootResult.Ruin : ShootResult.Hurt;
                //}

                //state = Ship != null ? Ship.Fire() : ShootResult.Miss;

                //return IsFired ? ShootResult.Ruin : ShootResult.Hurt;
                //bool flag = cells.Count != 0;
                //foreach (Cell cell in cells)
                //    flag = flag && cell.State != ShootResult.Free;
            }

            return state;
        }
    }
}
