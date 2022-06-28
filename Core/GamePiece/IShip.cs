namespace Core.GamePiece
{
    public interface IShip
    {
        #region Properties

        public string Id { get; }
        public int Length { get; }
        public int Hits { get; }

        #endregion

        #region Methods

        void AddHit();
        bool IsDestroyed();

        #endregion
    }
}