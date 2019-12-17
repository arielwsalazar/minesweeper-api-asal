using System;
using Mines_Sweeper.Dao;

namespace Mines_Sweeper.Core
{
    public interface IMineSweeper
    {
        public MineMatrix Create(int height,int width,int bomb);
    }
}
