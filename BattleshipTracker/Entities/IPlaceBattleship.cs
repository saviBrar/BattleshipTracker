using System;
using System.Collections.Generic;

namespace BattleshipTracker
{
    public interface IPlaceBattleship
    {
        bool CanShipBePlaced(IBattleship ship, IBoardCell startingCell, IBoard board);
        IList<IBoardCell> ListOfCellsAffected(IBattleship ship, IBoardCell startingCell, IBoard board);
    }
}
