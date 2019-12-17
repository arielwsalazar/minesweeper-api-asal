using System;
using System.Collections.Generic;
using Mines_Sweeper.Classes;
using Mines_Sweeper.Const;

namespace Mines_Sweeper.Dao
{
    public class MineMatrix
    {
        public GameStatus Status;
        public string Token;
        public int Bombs;
        public int Height;
        public int Width;
        public Dictionary<int, Cell> Matrix;
    }
}
