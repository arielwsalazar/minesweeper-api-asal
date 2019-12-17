using System;
using System.Collections.Generic;
using System.Linq;
using Mines_Sweeper.Classes;
using Mines_Sweeper.Dao;

namespace Mines_Sweeper.Core
{
    public class MineSweeper : IMineSweeper
    {
        MineMatrix _mineMatrix;
        public MineSweeper(MineMatrix mineMatrix)
        {
            _mineMatrix = mineMatrix;
        }

        public void GameOver()
        {
            foreach (var item in _mineMatrix.Matrix)
            {
                item.Value.Status = Const.CellStatus.UNCOVERED;
            }
        }

        public Cell GetCell(int x, int y)
        {
            int newx = row(x);
            
            int position = _mineMatrix.Width * newx + y;

            return _mineMatrix.Matrix[position];
        }

        private int row (int x)
        {
            int newx = 0;
            if (x > 0)
            {
                newx = x - 1;
            }
            return newx;
        }

        public bool IsGameOver()
        {
            IEnumerable<Cell> values = _mineMatrix.Matrix.Values;
            if (values.Any(x => x.Status == Const.CellStatus.UNCOVERED))
            {
                return false;
            }

            return true;
        }

        public Cell ProcessPoint(int x, int y)
        {
            int newx = row(x);
            int position = _mineMatrix.Width * newx + y;

            Cell cell = _mineMatrix.Matrix[position];

            if (cell.Type == Const.CellType.BOMB)
            {
                GameOver();
            }

            return cell;
        }

    }
}
