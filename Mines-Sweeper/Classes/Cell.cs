using System;
using Mines_Sweeper.Const;

namespace Mines_Sweeper.Classes
{
    public class Cell
    {
        public CellStatus Status;
        public CellType Type;
        public int Value;
        public CellCoordinates Coordinates;

        public Cell()
        {
            Status = CellStatus.COVERED;
            Type = CellType.ZERO;
            Value = 0;
            Coordinates = new CellCoordinates();
            Coordinates.X = 0;
            Coordinates.Y = 0;
        }
    }
}
