namespace Core.GameBoard
{
    public class Coordinate
    {
        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
        
        #region Properties

        public int Row { get; }
        public int Column { get; }

        #endregion
    }
}