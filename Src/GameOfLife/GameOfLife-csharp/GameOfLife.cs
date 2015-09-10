using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GameOfLife
{
    class GameOfLife: Application
    {
        private Life _game;
        private Grid _board;
        private readonly SolidColorBrush _deadColor = new SolidColorBrush(Color.FromRgb(79, 177, 104));
        private readonly SolidColorBrush _livingColor = new SolidColorBrush(Color.FromRgb(65, 150, 90));
        private bool _isStopped = true;

        [STAThread]
        static void Main()
        {
            var gameOfLife = new GameOfLife();
            gameOfLife.Run(gameOfLife.CreateMainWindow());

        }

        public Window CreateMainWindow()
        {
            var window = new Window
            {
                Height = 740,
                Width = 816,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                WindowStyle = WindowStyle.ToolWindow,
                Title = "Game of Live TDD KATA by Evilz"
            };

            CreateMainLayout(window);

            return window;
        }

        private void CreateMainLayout(Window window)
        {
            var stack = new StackPanel();
            stack.Background = new SolidColorBrush(Colors.WhiteSmoke);
            stack.Orientation = Orientation.Vertical;

            //menu
            var menuGrid = new Grid();
            menuGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            menuGrid.VerticalAlignment = VerticalAlignment.Stretch;
            menuGrid.Height = 100;

            // play button
            var playBtn = new Button();
            playBtn.Content = "|>";
            playBtn.Command = new RelayCommand(_ => Play(), _ => _isStopped );
            playBtn.SetValue(Grid.ColumnProperty, 0);
            playBtn.SetValue(Grid.RowProperty, 0);
            menuGrid.Children.Add(playBtn);

            for (int i = 0; i < 4; i++)
                menuGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Pixel) });
                
            // board
            _board = new Grid();
            _board.Background = new SolidColorBrush(Color.FromRgb(58, 128, 74));
            _board.HorizontalAlignment = HorizontalAlignment.Stretch;
            _board.VerticalAlignment = VerticalAlignment.Stretch;

            for (int i = 0; i < 8; i++)
            {
                _board.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Pixel) });
                for (int j = 0; j < 6; j++)
                {
                    if(i == 0)
                        _board.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Pixel) });
                    CreateLabel(_board, i, j);
                }
            }


            stack.Children.Add(menuGrid);
            stack.Children.Add(_board);


            window.Content = stack;

        }

        private void CreateLabel(Grid parent, int x, int y)
        {
            
            var label = new Label
            {
                Background = _deadColor,
                FontSize = 50,
                Foreground = new SolidColorBrush(Colors.White),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(2),
                Content = string.Empty
            };
            label.SetValue(Grid.ColumnProperty, x);
            label.SetValue(Grid.RowProperty, y);
            label.MouseLeftButtonUp += CellClicked;

            parent.Children.Add(label);
        }

        private void CellClicked(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var cell = sender as Label;
            
            cell.Background = _livingColor;

        }

        private void Play()
        {
            _isStopped = false;
            DispatcherTimer timer = new DispatcherTimer();

            var initGrid = GetBoardGrid();
            _game = new Life(initGrid);
            BoardEvolve();
            timer.Interval = TimeSpan.FromMilliseconds(5000);
            timer.Tick += (sender, args) =>
            {
                BoardEvolve();
            };
            timer.Start();
        }

        private void BoardEvolve()
        {
            _game.Evolve();
            RefreshBoard();
        }

        private bool[,] GetBoardGrid()
        {
            bool[,] initGrid = new bool[_board.RowDefinitions.Count, _board.ColumnDefinitions.Count];

            for (int x = 0; x < _board.ColumnDefinitions.Count; x++)
            {
                for (int y = 0; y < _board.RowDefinitions.Count; y++)
                {
                    var cell = _board.Children[x*y] as Label;
                    initGrid[y, x] = cell.Background == _livingColor;
                }
            }
            return initGrid;
        }

        private void RefreshBoard()
        {
            int childIndex = 0;
            for (int x = 0; x < _game.CurrentGrid.GetLength(0); x++)
            {
                 for (int y = 0; y < _game.CurrentGrid.GetLength(1); y++)
                 {
                     var cell = _board.Children[childIndex++] as Label;
                     if (_game.CurrentGrid[x, y])
                     {
                         cell.Background = _livingColor;
                     }
                     else
                     {
                         cell.Background = _deadColor;
                     }
                 }
            }
            _board.UpdateLayout();

        }
    }

    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #region Constructors

        public RelayCommand(Action<object> execute) : this(execute, null) {}

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion // ICommand Members
    }
    
}
