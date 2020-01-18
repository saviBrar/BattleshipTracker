using System;
using NUnit.Framework;

namespace BattleshipTracker.Test
{
    [TestFixture]
    public class PlaceShipTest
    {
        private readonly IPlaceBattleship _placeBattleship;
        public PlaceShipTest()
        {
            _placeBattleship = new PlaceBattleship();
        }

        [Test]
        public void _ship_width_less_than_one_exception()
        {
            //Arrange
            ICreateBoard createBoard = new CreateNewBoard();
            var board = createBoard.CreateBoard();

            //Creating a ship with 0 width
            IBattleship battleShip = new Battleship
            {
                Width = 0,
                Orientation = OrientationType.Horizontal
            };

            IBoardCell firstCell = new BoardCell
            {
                RowCoordinate = 1,
                ColumnCoordinate = 1
            };

            //Act and Assert
            Assert.Throws<ShipWidthCannotBeLessThanOneException>(() => _placeBattleship.CanShipBePlaced(battleShip,firstCell,board));
        }

        [Test]
        public void place_battleship_return_true()
        {
            //Arrange
            ICreateBoard createBoard = new CreateNewBoard();
            var board = createBoard.CreateBoard();

            //Creating a ship with 0 width
            IBattleship battleShip = new Battleship
            {
                Width = 3,
                Orientation = OrientationType.Horizontal
            };

            IBoardCell firstCell = new BoardCell
            {
                RowCoordinate = 1,
                ColumnCoordinate = 1
            };

            //Act
            var result = _placeBattleship.CanShipBePlaced(battleShip, firstCell, board);

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void place_battleship_return_false()
        {
            //Arrange
            ICreateBoard createBoard = new CreateNewBoard();
            var board = createBoard.CreateBoard();

            //Assuming the first cell is occupied
            foreach (var cells in board.BoardCells)
            {
                cells.IsOccupied = true;
                break;
            }

            //Creating a ship with 0 width
            IBattleship battleShip = new Battleship
            {
                Width = 5,
                Orientation = OrientationType.Horizontal
            };

            IBoardCell firstCell = new BoardCell
            {
                RowCoordinate = 1,
                ColumnCoordinate = 1
            };

            //Act
            var result = _placeBattleship.CanShipBePlaced(battleShip, firstCell, board);

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
