using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TicTacToe
{
    class TicTacToe : Application
    {
        readonly TicTacToeGame _game = new TicTacToeGame();
        
        [STAThread]
        static void Main()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.Run(ticTacToe.CreateMainWindow());
        }

        public Window CreateMainWindow()
        {
            var window = new Window
            {
                Height = 300,
                Width = 300,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                WindowStyle = WindowStyle.ToolWindow,
                Title = "Tic Tac Toe TDD KATA by Evilz"
            };

            CreateMainLayout(window);


            return window;
        }

        private void CreateMainLayout(Window window)
        {

            var mainLayout = new Grid();
            mainLayout.ColumnDefinitions.Add(new ColumnDefinition());
            mainLayout.ColumnDefinitions.Add(new ColumnDefinition());
            mainLayout.ColumnDefinitions.Add(new ColumnDefinition());

            mainLayout.RowDefinitions.Add(new RowDefinition());
            mainLayout.RowDefinitions.Add(new RowDefinition());
            mainLayout.RowDefinitions.Add(new RowDefinition());
            mainLayout.Background = new SolidColorBrush(Color.FromRgb(58, 128, 74));

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    CreateLabel(mainLayout, i, j);
                }
            }

            window.Content = mainLayout;

        }

        private void ClearBoard()
        {
           var mainLayout = (Grid)MainWindow.Content;
            foreach (var child in mainLayout.Children)
            {
                var label = (Label)child;
                label.Content = string.Empty;
            }
        }

        private void CreateLabel(Grid parent, int x, int y)
        {
            var label = new Label
            {
                Background = new SolidColorBrush(Color.FromRgb(79, 177, 104)),
                FontSize = 50,
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(2)
            };
            label.SetValue(Grid.ColumnProperty, x);
            label.SetValue(Grid.RowProperty, y);
            label.MouseLeftButtonUp += CellClicked;

            parent.Children.Add(label);
        }

        private void CellClicked(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var label = (Label)sender;
            uint x = Convert.ToUInt32((int)label.GetValue(Grid.ColumnProperty));
            uint y = Convert.ToUInt32((int)label.GetValue(Grid.RowProperty));
            try
            {
                var player = _game.CurrentPlayer;
                var win = _game.Play(x, y);
                label.Content = player.ToString();
                if (win)
                {
                    ShowWinMessage(player);
                }
            }
            catch (TicTacToeEndGameException)
            {
                ShowDrawMessage();
            }
            catch (Exception e)
            {
                ShowErrorMessage(e.Message);
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(MainWindow, "Error: " + message);
        }

        private void ShowWinMessage(Players player)
        {
            var result = MessageBox.Show(MainWindow, "Player: " + player + " has WIN !");
            if (result == MessageBoxResult.OK)
            {
                _game.StartNew();
                ClearBoard();
            }
        }

        private void ShowDrawMessage()
        {
            var result = MessageBox.Show(MainWindow, "Nobody wins try again!");
            if (result == MessageBoxResult.OK)
            {
                _game.StartNew();
                ClearBoard();
            }
        }
    }
}
