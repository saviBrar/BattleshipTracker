using System;
namespace BattleshipTracker
{
    public interface IBoardCell
    {
        int RowCoordinate { get; set; }
        int ColumnCoordinate { get; set; }
        bool IsOccupied { get; set; }
        bool IsHit { get; set; }
    }
}
