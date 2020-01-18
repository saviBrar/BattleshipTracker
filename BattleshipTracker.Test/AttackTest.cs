using System;
using BattleshipTracker.Exceptions;
using NUnit.Framework;

namespace BattleshipTracker.Test
{
    [TestFixture]
    public class AttackTest
    {
        private readonly IAttack _attack;
        public AttackTest()
        {
            _attack = new Attack();
        }

        //Tests that Board Null exception is thrown when an empty board is passed
        [Test]
        public void _board_null_exception_thrown()
        {
            //Arrange
            IBoard board = null;
            IBoardCell cellToAttack = new BoardCell
            {
                RowCoordinate = 1,
                ColumnCoordinate = 1,
                IsHit = false,
                IsOccupied = false
            };


            //Assert
            Assert.Throws<BoardNullException>(() => _attack.AttackShip(board, cellToAttack));
        }

        //Tests that Board Cell Null exception is thrown when an empty board is passed
        [Test]
        public void _board_cell_null_exception_thrown()
        {
            //Arrange
            ICreateBoard createBoard = new CreateNewBoard();
            var board = createBoard.CreateBoard();
            IBoardCell cellToAttack = null;


            //Act and Assert
            Assert.Throws<BoardCellNullException>(() => _attack.AttackShip(board, cellToAttack));
        }


        //Tests that a hit is recorded
        [Test]
        public void _hit_is_recorded()
        {
            //Arrange
            ICreateBoard createBoard = new CreateNewBoard();
            var board = createBoard.CreateBoard();

            //Assuming the first cell is occupied
            foreach(var cells in board.BoardCells)
            {
                cells.IsOccupied = true;
                break;
            }


            IBoardCell cellToAttack = new BoardCell
            {
                RowCoordinate = 1,
                ColumnCoordinate = 1,
                IsHit = false,
                IsOccupied = false
            };

            //Act
            var result = _attack.AttackShip(board, cellToAttack);

            //Assert
            Assert.AreEqual(AttackResult.Hit, result);
            
        }

        //Tests that a miss is recorded
        [Test]
        public void _miss_is_recorded()
        {
            //Arrange
            ICreateBoard createBoard = new CreateNewBoard();
            var board = createBoard.CreateBoard();
            IBoardCell cellToAttack = new BoardCell
            {
                RowCoordinate = 1,
                ColumnCoordinate = 1,
                IsHit = false,
                IsOccupied = false
            };

            //Act
            var result = _attack.AttackShip(board, cellToAttack);

            //Assert
            Assert.AreEqual(AttackResult.Miss, result);

        }
    }

}
