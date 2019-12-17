using System;
using Mines_Sweeper.Const;

namespace Mines_Sweeper.Classes
{
    public class Cell
    {
        public CellStatus Status;
        public CellType Type;
        public int Value;
        public CellCoordinates coordinates;
    }
}
