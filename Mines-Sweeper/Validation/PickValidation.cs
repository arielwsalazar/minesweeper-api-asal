using System;
using Mines_Sweeper.Classes;

namespace Mines_Sweeper.Validation
{
    static public class PickValidation
    {
        static public bool IsPickValid(CellCoordinates cellCoordinates)
        {
            return cellCoordinates.X >= 0 && cellCoordinates.Y >= 0;
        }
    }
}
