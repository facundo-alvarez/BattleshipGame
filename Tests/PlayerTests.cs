using Core;
using Core.GamePlayer;
using Xunit;

namespace Tests
{
    public class PlayerTests
    {
        public PlayerTests()
        {
            player = new Player(new Settings());
        }

        #region Fields

        Player player;

        #endregion

        #region Tests

        [Fact]
        public void Player_CanCreatePlayer()
        {
            //Assert
            Assert.True(player != null);
        }

        [Fact]
        public void Player_GetShipsRemain_ReturnsThree()
        {
            //Assert
            Assert.Equal(3, player.GetShipsRemain());
        }

        [Theory]
        [InlineData(5)]
        public void Player_GetShipsReamin_ReturnsTwoAfterOneDestroyed(int hits)
        {
            //Act
            for (var hit = 1; hit <= hits; hit++)
                player.PlayerShips[0].AddHit();

            //Assert
            Assert.Equal(2, player.GetShipsRemain());
        }

        public void Player_GetShip_ReturnsShipThatMatchTheId()
        {
            //Arrange
            var shipId = player.PlayerShips[0].Id;

            //Act
            var playerShip = player.GetShip(shipId);

            //Assert
            Assert.Equal(shipId, playerShip.Id);
        }

        #endregion
    }
}
