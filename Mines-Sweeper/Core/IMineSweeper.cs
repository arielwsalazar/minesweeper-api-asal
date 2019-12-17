using System;
using Mines_Sweeper.Classes;
using Mines_Sweeper.Dao;

namespace Mines_Sweeper.Core
{
    public interface IMineSweeper
    {
        public Cell GetCell(int x, int y);
        public bool IsGameOver();
        public void GameOver();
        public Cell ProcessPoint(int x, int y);
    }
}
