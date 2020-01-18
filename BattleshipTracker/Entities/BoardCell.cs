using System;
namespace BattleshipTracker
{
    //This class described one cell on the board.
    //Every cell should have an address defined by RowCoordinate and ColumnCoordinate
    //We need to serialize this object to save its state
    [Serializable]
    public class BoardCell : IBoardCell
    { 
        public int RowCoordinate { get; set; }
        public int ColumnCoordinate { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsHit { get; set; }
    }
}
