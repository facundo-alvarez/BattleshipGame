using Core.GamePiece;

namespace Core.GamePlayer
{
    public class Player
    {
        public Player(Settings gameSettings)
        {
            PlayerShips = new List<IShip>();
            battleshipFactory = new BattleshipFactory();
            destructorFactory = new DestructorFactory();

            foreach (var shipType in gameSettings.ShipsInGame)
            {
                if (shipType == ShipType.Destructor)
                    PlayerShips.Add(destructorFactory.CreateShip());

                if (shipType == ShipType.Battleship)
                    PlayerShips.Add(battleshipFactory.CreateShip());
            }
        }

        #region Fields

        IShipFactory battleshipFactory;
        IShipFactory destructorFactory;

        #endregion

        #region Properties

        public List<IShip> PlayerShips { get; }

        #endregion

        #region Methods

        public IShip GetShip(string shipId)
        {
            return PlayerShips.Find(p => p.Id == shipId);

        }
        public int GetShipsRemain()
        {
            int shipsRemain = 0;

            foreach (var ship in PlayerShips)
            {
                if (!ship.IsDestroyed())
                    shipsRemain++;
            }

            return shipsRemain;
        }

        #endregion

    }
}
