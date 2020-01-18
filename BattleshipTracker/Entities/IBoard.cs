using System;
using System.Collections.Generic;

namespace BattleshipTracker
{
    public interface IBoard
    {
        IList<IBoardCell> BoardCells { get; set; }
    }
}
