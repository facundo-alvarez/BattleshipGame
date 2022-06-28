using Core;
using Xunit;

namespace Tests
{
    public class GameTests
    {
        public GameTests()
        {
            game = new Game();
        }

        #region Fields

        Game game;

        #endregion

        #region Tests

        [Fact]
        public void Game_CanCreateGame()
        {
            //Assert
            Assert.True(game != null);
        }

        [Fact]
        public void Game_IsGameFinished_ReturnsFalseWhileExistsPlayersWithShipsRemaining()
        {
            //Assert
            Assert.False(game.IsGameFinished());
        }

        [Fact]
        public void Game_IsGameFinished_ReturnsTrueWhenPlayerNotHaveAnyShipsRemaining()
        {
            //Arrange
            int hits = 5;
            
            //Act
            foreach (var ship in game.Player.PlayerShips)
            {
                for (var hit = 1; hit <= hits; hit++)
                    ship.AddHit();
            }

            Assert.True(game.IsGameFinished());
        }

        #endregion
    }
}
