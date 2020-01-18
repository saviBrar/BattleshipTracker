using System;
using System.Collections.Generic;
using BattleshipTracker.Exceptions;

namespace BattleshipTracker
{
    public class CreateNewBoard : ICreateBoard
    {
       public IBoard CreateBoard()
        {
            //We are creating a default 10X10 board. This can also be made generic by passing in the number of rows and columns
            IList<IBoardCell> boardCells = new List<IBoardCell>();
            for (int row = 1; row <= 10; row++)
            {
                for (int column = 1; column <= 10; column++)
                {
                    boardCells.Add(new BoardCell() { RowCoordinate = row, ColumnCoordinate = column, IsOccupied = false, IsHit = false });
                }
            }

            return new Board { BoardCells = boardCells };
        }
    }
}
