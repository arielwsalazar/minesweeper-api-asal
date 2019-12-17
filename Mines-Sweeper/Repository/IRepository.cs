using System;
using Mines_Sweeper.Dao;

namespace Mines_Sweeper.Repository
{
    public interface IRepository
    {
        public int Save(MineMatrix matrix);
        public MineMatrix Load(string token);
    }
}
