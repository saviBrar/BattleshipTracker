using System;
using BattleshipTracker.Exceptions;
using NUnit.Framework;

namespace BattleshipTracker.Test
{
    [TestFixture]
    public class CreateBoardTest
    {
        private readonly ICreateBoard _createBoard;
        public CreateBoardTest()
        {
            _createBoard = new CreateNewBoard();

        }

        [Test]
        public void _return_new_board()
        {
            //Act
            var newBoard = _createBoard.CreateBoard();

            //Asserting that a 10X10 board has been created
            Assert.AreEqual(10 * 10, newBoard.BoardCells.Count);
        }

    }
}
