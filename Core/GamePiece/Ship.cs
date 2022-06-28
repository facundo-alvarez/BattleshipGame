namespace Core.GamePiece
{
    public class Ship : IShip
    {
        public Ship(string id, int length)
        {
            Id = id;
            Length = length;
        }

        #region Properties

        public string Id { get; }
        public int Length { get; }
        public int Hits { get; private set; }

        #endregion

        #region Methods

        public void AddHit() => Hits++;
        public bool IsDestroyed() => Hits >= Length ? true : false;

        #endregion
    }
}
