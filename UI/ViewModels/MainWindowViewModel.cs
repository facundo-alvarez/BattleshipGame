using Core;
using Core.GameBoard;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace UI.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Game = new Game();
            HitCommand = new RelayCommand<Coordinate>(HitTarget);
        }

        #region Properties

        public ICommand HitCommand { get; }
        public Game Game { get; }
        public string ShootResult { get; private set; }
        public bool IsGameFinished { get; private set; }

        #endregion

        #region Methods

        private void HitTarget(Coordinate shootCoordinate)
        {
            var shootResult = Game.Board.ShootTarget(shootCoordinate);

            if (shootResult != null)
            {
                var ship = Game.Player.GetShip(shootResult);
                ship.AddHit();

                if (ship.IsDestroyed())
                    ShootResult = "Ship sunk!"; 
                else
                    ShootResult = "Hit!";

                IsGameFinished = Game.IsGameFinished();
            }
            else
            {
                ShootResult = "Miss";
            }
        }

        #endregion
    }
}
