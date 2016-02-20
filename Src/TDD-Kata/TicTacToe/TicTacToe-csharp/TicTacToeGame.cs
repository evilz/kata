
namespace TicTacToe
{
    public class TicTacToeGame
    {
        public TicTacToeGame()
        {
            StartNew();
        }

        public void StartNew()
        {
            Board = new BoardCellState[3, 3];
            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    Board[i, j] = BoardCellState.Empty;

            CurrentPlayer = Players.X;
        }
        public BoardCellState[,] Board { get; set; }
        public Players CurrentPlayer { get;private set; }

        public bool Play(uint x,uint y)
        {
            GuardMove(x,y);
            SetBoardCell( x, y);
            if (CheckWin(x,y)) return true;            
            ToggleCurrentPlayer();
            GuardEndGame();
            return false;
        }

        private void GuardEndGame()
        {
            bool full = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] == BoardCellState.Empty)
                    {
                        full = false;break;
                    }
                }
            }

            if(full) 
                throw new TicTacToeEndGameException("End");
        }

        private bool CheckWin(uint x, uint y)
        {
            return CheckDiag(x, y) || CheckLines(x, y);
           
        }

        private bool CheckLines(uint x, uint y)
        {
            if (CheckHorizontalLine(y)) return true;
            if (CheckVerticalLine(x)) return true;

            return false;
        }

        private bool CheckHorizontalLine( uint y)
        {
            return (Board[y, 0] != BoardCellState.Empty && Board[y, 0] == Board[y, 1] && Board[y, 1] == Board[y, 2]);
        }
        private bool CheckVerticalLine(uint x)
        {
            return (Board[0, x] != BoardCellState.Empty &&  Board[0, x] == Board[1, x] && Board[1, x] == Board[2, x]);
        }

        private bool CheckDiag(uint x, uint y)
        {
            return (Board[0, 0] != BoardCellState.Empty && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
                       || (Board[0, 2] != BoardCellState.Empty && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0]);
        }

        private void GuardMove(uint x, uint y)
        {
            if(x > 2 || y > 2)
                throw new TicTacToeException("The board is 3x3 !");

            if(Board[y,x] != BoardCellState.Empty)
                throw new TicTacToeException("Cell not empty");
        }

        private void ToggleCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == Players.X ? Players.O : Players.X;
        }

        private void SetBoardCell( uint x, uint y)
        {
            var state = BoardCellState.Empty;
            switch (CurrentPlayer)
            {
                case Players.X:
                    state = BoardCellState.X;
                    break;
                case Players.O:
                    state = BoardCellState.O;
                    break;
            }
            Board[y, x] = state;
        }
    }
}