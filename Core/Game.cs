using Core.GameBoard;
using Core.GamePlayer;

namespace Core
{
    public class Game
    {
        public Game()
        {
            Settings settings = new Settings();

            Player = new Player(settings);
            Board = new Board(settings);

            foreach (var ship in Player.PlayerShips)
            {
                Board.AddShip(ship);
            }
        }

        #region Properties

        public Player Player { get; }
        public Board Board { get; }

        #endregion

        #region Methods

        public bool IsGameFinished() => Player.GetShipsRemain() > 0 ? false : true;

        #endregion
    }
}
