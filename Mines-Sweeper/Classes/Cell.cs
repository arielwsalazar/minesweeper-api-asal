using System;
using System.Collections.Generic;
using Mines_Sweeper.Const;

namespace Mines_Sweeper.Classes
{
    public class Cell
    {
        public CellStatus Status { get; set; }
        public CellType Type { get; set; }
        public int Value { get; set; }
        public CellCoordinates Coordinates { get; set; }
        public List<int> AffectedCells { get; set; }

        public Cell()
        {
            Status = CellStatus.COVERED;
            Type = CellType.ZERO;
            Value = 0;
            Coordinates = new CellCoordinates();
            Coordinates.X = 0;
            Coordinates.Y = 0;
            AffectedCells = new List<int>();
        }
    }
}
