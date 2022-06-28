using Core.GamePiece;

namespace Core
{
    public class Settings
    {
        public Settings()
        {
            RowsQuantity = 10;
            ColumnsQuantity = 10;
            ShipsInGame = new List<ShipType>
            {
                ShipType.Destructor,
                ShipType.Destructor,
                ShipType.Battleship
            };
        }

        #region Properties

        public int RowsQuantity { get; }
        public int ColumnsQuantity { get; }
        public List<ShipType> ShipsInGame { get; }

        #endregion
    }
}
