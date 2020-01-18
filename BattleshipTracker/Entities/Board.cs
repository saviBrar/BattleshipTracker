using System;
using System.Collections.Generic;

namespace BattleshipTracker
{
    [Serializable]
    public class Board : IBoard
    {
        public IList<IBoardCell> BoardCells { get; set; }
    }
}
