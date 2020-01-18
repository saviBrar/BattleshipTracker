using System;
using System.Linq;
using BattleshipTracker.Exceptions;

namespace BattleshipTracker
{
    public class Attack : IAttack
    {
        public Attack()
        {
        }

        /// <summary>
        /// Perform an attack on the supplied board and return the outcome.
        /// </summary>
        /// <param name="board">The current board on which the attack will be performed.</param>
        /// <param name="cellToAttack">The board position on which the attack will be performed.</param>
        /// <returns>Outcome of the attack. Whether it is a Hit or a Miss.</returns>
        public AttackResult AttackShip(IBoard board, IBoardCell cellToAttack)
        {
            if (board == null)
            {
               throw new BoardNullException("The board is null and the attack cannot be completed.");
            }
            if (cellToAttack == null || cellToAttack.RowCoordinate <= 0 || cellToAttack.ColumnCoordinate <= 0)
            {
                throw new BoardCellNullException("The board cell is null and the attack cannot be completed.");
            }
            var attackedCell = board.BoardCells.Where(x => x.RowCoordinate == cellToAttack.RowCoordinate
                                                   && x.ColumnCoordinate == cellToAttack.ColumnCoordinate).FirstOrDefault();
            if (attackedCell != null && attackedCell.IsOccupied)
            {
                attackedCell.IsHit = true;
                return AttackResult.Hit;
            }

            return AttackResult.Miss;
        }
    }
}
