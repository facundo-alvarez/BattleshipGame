namespace Core.GamePiece
{
    public class BattleshipFactory : IShipFactory
    {
        public Ship CreateShip()
        {
            return new Ship("Battleship" + Guid.NewGuid(), 5);
        }
    }
}
