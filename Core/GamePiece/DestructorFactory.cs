namespace Core.GamePiece
{
    public class DestructorFactory : IShipFactory
    {
        public Ship CreateShip()
        {
            return new Ship("Destructor" + Guid.NewGuid(), 4);
        }
    }
}
