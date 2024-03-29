﻿using System;

namespace SeaFightGame.Model
{
    public interface ICell
    {
        int X { get; set; }
        int Y { get; set; }
        bool Fire();
        bool? HasShip { get; }
    }
}
