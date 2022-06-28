using Core.GamePiece;

namespace Core.GameBoard
{
    public class Board
    {
        public Board(Settings gameSettings)
        {
            Grid = new string[gameSettings.RowsQuantity, gameSettings.ColumnsQuantity];
        }

        #region Properties

        public string?[,] Grid { get; }

        #endregion

        #region Public Methods

        public void AddShip(IShip ship)
        {
            Direction direction;
            bool valid = false;
            List<Coordinate> shipCoordinates = new List<Coordinate>();

            while (!valid)
            {
                direction = RandomGenerator.ShipDirection();
                Coordinate coordiante = RandomGenerator.ShipCoordinates(Grid.GetLength(0), Grid.GetLength(1), ship.Length, direction);
                shipCoordinates = ShipPositionOnGrid(coordiante, direction, ship.Length);
                valid = !ExistShipOnCoordinates(shipCoordinates);
            }

            AddShipToGrid(shipCoordinates, ship.Id);
        }
        public string? ShootTarget(Coordinate coordinate)
        {
            var target = Grid[coordinate.Row, coordinate.Column];

            if (target != null)
            {
                Grid[coordinate.Row, coordinate.Column] = null;
                return target;
            }

            return null;
        }

        #endregion

        #region Private Methods

        private List<Coordinate> ShipPositionOnGrid(Coordinate startCoordinate, Direction direction, int shipLength)
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            for (var index = 0; index < shipLength; index++)
            {
                if (direction == Direction.Horizontal)
                {
                    coordinates.Add(new Coordinate(startCoordinate.Row, startCoordinate.Column + index));
                }
                else
                {
                    coordinates.Add(new Coordinate(startCoordinate.Row + index, startCoordinate.Column));
                }
            }
            return coordinates;
        }
        private bool ExistShipOnCoordinates(List<Coordinate> shipCoordinates)
        {
            foreach (var coordinate in shipCoordinates)
            {
                if (Grid[coordinate.Row, coordinate.Column] != null)
                    return true;
            }
            return false;
        }
        private void AddShipToGrid(List<Coordinate> shipCoordinates, string shipId)
        {
            foreach (var coordinate in shipCoordinates)
            {
                Grid[coordinate.Row, coordinate.Column] = shipId;
            }
        }

        #endregion
    }
}