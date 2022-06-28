using Core;
using Core.GameBoard;
using Core.GamePiece;
using Xunit;

namespace Tests
{
    public class GameBoardTests
    {
        public GameBoardTests()
        {
            gameBoard = new Board(new Settings());
            destroyerFactory = new DestructorFactory();
            bettleshipFactory = new BattleshipFactory();
            ship = destroyerFactory.CreateShip();
            ship2 = bettleshipFactory.CreateShip();
        }

        #region Fields

        const int rows = 10;
        const int columns = 10;
        IShipFactory destroyerFactory;
        IShipFactory bettleshipFactory;
        IShip ship;
        IShip ship2;
        Board gameBoard;

        #endregion

        #region Tests

        [Fact]
        public void GameBoard_CanCreateGrid_ReturnsNotNullGrid()
        {
            //Assert
            Assert.True(gameBoard.Grid != null);
        }

        [Theory]
        [InlineData(4, Direction.Horizontal)]
        [InlineData(4, Direction.Vertical)]
        [InlineData(5, Direction.Horizontal)]
        [InlineData(5, Direction.Vertical)]
        public void GameBoard_GenerateValidCoordinates_ReturnsCoordinatesInsideGridConsideringShipLengthAndDirection(int shipLength, Direction direction)
        {
            //Arrange
            int MaxRow = rows;
            int MaxColumn = columns;

            //Act
            Coordinate coordinate = RandomGenerator.ShipCoordinates(MaxRow, MaxColumn, shipLength, direction);

            //Assert
            if (direction == Direction.Horizontal)
                Assert.InRange(coordinate.Column, 0, MaxColumn - (shipLength));
            else
                Assert.InRange(coordinate.Row, 0, MaxRow - (shipLength));
        }

        [Fact]
        public void GameBoard_AddShip_AddShipToGridWithPreviousShipsWhithoutOverlapping()
        {
            //Arrange
            int counter = 0;

            //Act
            gameBoard.AddShip(ship);
            gameBoard.AddShip(ship2);

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    if (gameBoard.Grid[row, column] != null)
                        counter++;
                }
            }

            //Assert
            Assert.Equal(ship.Length + ship2.Length, counter);
        }

        [Fact]
        public void GameBoard_RemoveShip_ReturnsNullOnTheShipGridWithNonNullTarget()
        {
            //Arrange
            int rowShoot = 2;
            int columnShoot = 2;
            gameBoard.Grid[2, 2] = "Test";

            //Act
            gameBoard.ShootTarget(new Coordinate(rowShoot, columnShoot));

            //Assert
            Assert.Null(gameBoard.Grid[rowShoot, columnShoot]);
        }

        #endregion
    }
}