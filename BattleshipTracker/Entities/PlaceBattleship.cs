using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipTracker
{
    public class PlaceBattleship : IPlaceBattleship
    {
        public PlaceBattleship()
        {
        }

        public bool CanShipBePlaced(IBattleship ship, IBoardCell startingCell, IBoard board)
        {
            //If the ship width is less than one then an exception is thrown
            if (ship.Width < 1)
            {
                throw new ShipWidthCannotBeLessThanOneException("The ship width must be greater than 0");
            }

            if (ship.Orientation == OrientationType.Vertical &&
                (ship.Width + startingCell.RowCoordinate) > board.BoardCells.Max(x => x.RowCoordinate))
            {
                return false;
            }

            if (ship.Orientation == OrientationType.Horizontal &&
                (ship.Width + startingCell.ColumnCoordinate) > board.BoardCells.Max(x => x.ColumnCoordinate))
            {
                return false;
            }
            var listOfCellsAffected = ListOfCellsAffected(ship, startingCell, board);

            return !listOfCellsAffected.Any(x => x.IsOccupied);
        }

        public IList<IBoardCell> ListOfCellsAffected(IBattleship ship, IBoardCell startingCell, IBoard board)
        {
            switch (ship.Orientation)
            {
                case OrientationType.Vertical:
                    int numberOfCells = startingCell.RowCoordinate + ship.Width;
                    return board.BoardCells.Where(x => x.RowCoordinate >= startingCell.RowCoordinate &&
                                                        x.ColumnCoordinate >= startingCell.ColumnCoordinate &&
                                                        x.RowCoordinate < numberOfCells &&
                                                        x.ColumnCoordinate <= startingCell.ColumnCoordinate).ToList();
                case OrientationType.Horizontal:
                    numberOfCells = startingCell.ColumnCoordinate + ship.Width;
                    return board.BoardCells.Where(x => x.RowCoordinate >= startingCell.RowCoordinate &&
                                                        x.ColumnCoordinate >= startingCell.ColumnCoordinate &&
                                                        x.RowCoordinate <= startingCell.RowCoordinate &&
                                                        x.ColumnCoordinate < numberOfCells).ToList();
            }
            return null;
        }
    }
}
