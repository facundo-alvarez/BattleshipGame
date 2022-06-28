using Core.GamePiece;
using Xunit;

namespace Tests
{
    public class ShipTests
    {
        public ShipTests()
        {
            destructorFactory = new DestructorFactory();
            ship = destructorFactory.CreateShip();
        }

        #region Fields

        IShip ship;
        IShipFactory destructorFactory;

        #endregion

        #region Tests

        [Fact]
        public void Ship_CanCreateGrid_ReturnsNotNullShip()
        {
            //Assert
            Assert.True(ship != null);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        public void Ship_IsShipDestroyed_RetrunsBoolTrueOrFalse(int hits, bool expected)
        {
            //Act
            for (var hit = 1; hit <= hits; hit++)
            {
                ship.AddHit();
            }

            //Assert
            Assert.Equal(expected, ship.IsDestroyed());
        }

        #endregion
    }
}
