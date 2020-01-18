using System;
using System.Linq;
using BattleshipTracker.Exceptions;

namespace BattleshipTracker
{
    public class BattleshipGame : IBattleshipGame
    {
        private readonly ICreateBoard _createBoard;
        private readonly IPlaceBattleship _placeBattleship;
        private readonly IAttack _attack;

        public BattleshipGame(ICreateBoard createBoard, IPlaceBattleship placeBattleship, IAttack attack)
        {
            _createBoard = createBoard;
            _placeBattleship = placeBattleship;
            _attack = attack;
        }

        /// Add a battleship to the board at a specified position.
        public bool AddBattleship(IBoard board, IBoardCell startCell, IBattleship ship)
        {
            if (board == null || startCell == null || ship == null)
            {
                return false;
            }

            var startingCell = board.BoardCells.Where(x => x.RowCoordinate == startCell.RowCoordinate
                                                    && x.ColumnCoordinate == startCell.ColumnCoordinate).FirstOrDefault();
            if (startingCell == null)
            {
                return false;
            }

            if (_placeBattleship.CanShipBePlaced(ship, startCell, board))
            {
                _placeBattleship.ListOfCellsAffected(ship, startCell, board).ToList().ForEach(x => x.IsOccupied = true);
                return true;
            }

            return false;
        }

        /// Perform a specified attack on the board
        public AttackResult Attack(IBoard board, IBoardCell cellToAttack)
        {
            if (board == null)
            {
                throw new BoardNullException("The board is null and the attack cannot be completed.");
            }
            if (cellToAttack == null || cellToAttack.RowCoordinate <= 0 || cellToAttack.ColumnCoordinate <= 0)
            {
                throw new BoardCellNullException("The board is null and the attack cannot be completed.");
            }
            return _attack.AttackShip(board, cellToAttack);
        }

        /// Return 10X10 empty board
        public IBoard CreateBoard()
        {
            return _createBoard.CreateBoard();
        }
    }
}
