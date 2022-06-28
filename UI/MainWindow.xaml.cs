using Core.GameBoard;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UI.ViewModels;

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            viewModel = new MainWindowViewModel();
            this.DataContext = viewModel;

            InitializeComponent();
            GenerateGrid();
        }

        #region Fields

        MainWindowViewModel viewModel;

        #endregion

        #region Events

        private void GridMouse_Click(object sender, RoutedEventArgs e)
        {
            var button = (sender as Button);
            var tag = button.Tag.ToString().Split(',');
            var row = Int32.Parse(tag[0]);
            var column = Int32.Parse(tag[1]);

            HitActionStart(button, row, column);
        }
        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            var row = rowCoordinate.SelectedIndex;
            var column = columnCoordinate.SelectedIndex;
            var tag = row + "," + column;
            var button = targetGrid.Children.OfType<Button>().Where(t => t.Tag.ToString() == tag).FirstOrDefault();

            HitActionStart(button, row, column);
        }

        #endregion

        #region Methods

        private void GenerateGrid()
        {
            var rowLength = viewModel.Game.Board.Grid.GetLength(0);
            var columnLength = viewModel.Game.Board.Grid.GetLength(1);

            for (var row = 0; row < rowLength; row++)
            {
                for (var column = 0; column < columnLength; column++)
                {
                    Button btn = new Button()
                    {
                        Tag = row + "," + column,
                        Width = 40,
                        Height = 40,
                        Margin = new Thickness(5),
                    };

                    targetGrid.Children.Add(btn);
                    btn.Click += GridMouse_Click;
                }
            }
        }
        private void HitActionStart(Button? button, int row, int column)
        {
            Coordinate hitCoordinate = new Coordinate(row, column);

            viewModel.HitCommand.Execute(hitCoordinate);
            ShootResultDialog(button);
            GameFinishChecker();
        }
        private void ShootResultDialog(Button? button)
        {
            if (viewModel.ShootResult != "Miss")
            {
                MessageBox.Show(viewModel.ShootResult);
                button.Content = "H";
                button.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Miss");
                button.Content = "M";
                button.IsEnabled = false;
            }
        }
        private void GameFinishChecker()
        {
            if (viewModel.IsGameFinished == true)
            {
                MessageBox.Show("All the ships are sunk!");
                this.Close();
            }
        }

        #endregion
    }
}
