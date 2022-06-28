namespace Core.GameBoard
{
    public static class RandomGenerator
    {
        #region Fields

        static Random random = new Random();

        #endregion

        #region Methods

        public static Coordinate ShipCoordinates(int maxRow, int maxColumn, int length, Direction direction)
        {
            if (direction == Direction.Horizontal)
            {
                return new Coordinate(random.Next(0, maxRow), random.Next(0, maxColumn - (length - 1)));
            }
            else
            {
                return new Coordinate(random.Next(0, maxRow - (length - 1)), random.Next(0, maxColumn));
            }
        }
        public static Direction ShipDirection()
        {
            return (Direction)random.Next(0, 2);
        }

        #endregion
    }
}
