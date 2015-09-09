using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    public class TicTacToeTests
    {
        private TicTacToeGame _game;

        [SetUp]
        public void Setup()
        {
            _game = new TicTacToeGame();
        }

        [Test]
        public void Board_Sould_BeEmpty_When_InitializeNewGame()
        {
            Assert.That(_game.Board,Is.EquivalentTo(new [,]
                {
                    { BoardCellState.Empty, BoardCellState.Empty, BoardCellState.Empty }, 
                    { BoardCellState.Empty, BoardCellState.Empty, BoardCellState.Empty },
                    { BoardCellState.Empty, BoardCellState.Empty, BoardCellState.Empty }
                }));
        }

        [Test]
        public void Board_Sould_BeEmpty_When_StartNewGame()
        {
            _game.StartNew();
            Assert.That(_game.Board, Is.EquivalentTo(new[,]
                {
                    { BoardCellState.Empty, BoardCellState.Empty, BoardCellState.Empty }, 
                    { BoardCellState.Empty, BoardCellState.Empty, BoardCellState.Empty },
                    { BoardCellState.Empty, BoardCellState.Empty, BoardCellState.Empty }
                }));
        }

        [Test]
        public void XPlayer_Sould_StartPlaying()
        {
             _game = new TicTacToeGame();
             _game.StartNew();

            Assert.AreEqual(Players.X, _game.CurrentPlayer);

        }

        [Test]
        public void Play_Sould_SetCurrentPlayerSymbolInGrid()
        {
            _game = new TicTacToeGame();
            _game.StartNew();
            _game.Play(0, 0);

            Assert.That(_game.Board, Is.EquivalentTo(new[,]
                {
                    { BoardCellState.X, BoardCellState.Empty, BoardCellState.Empty }, 
                    { BoardCellState.Empty, BoardCellState.Empty, BoardCellState.Empty },
                    { BoardCellState.Empty, BoardCellState.Empty, BoardCellState.Empty }
                }));

        }

        [Test]
        public void Play_Sould_SetCurrentPlayerSymbolInGridBis()
        {
            _game = new TicTacToeGame();
            _game.StartNew();
            _game.Play(1, 2);

            Assert.That(_game.Board, Is.EquivalentTo(new[,]
                {
                    { BoardCellState.Empty, BoardCellState.Empty, BoardCellState.Empty }, 
                    { BoardCellState.Empty, BoardCellState.Empty, BoardCellState.Empty },
                    { BoardCellState.Empty, BoardCellState.X, BoardCellState.Empty }
                }));

        }


        [Test]
        public void Play_Sould_ChangeCurrentPlayer()
        {
            _game = new TicTacToeGame();
            _game.StartNew();
            _game.Play(1, 2);

            Assert.AreEqual(Players.O, _game.CurrentPlayer);
        }

        [Test]
        public void Play_Sould_ThrowException_When_TryPlayingOnNotEmptyCell()
        {
            _game = new TicTacToeGame();
            _game.StartNew();
            _game.Play(1, 2);

            Assert.Throws<TicTacToeException>(() => _game.Play(1, 2));
            Assert.AreEqual(Players.O, _game.CurrentPlayer);
        }

        [Test]
        public void Play_Sould_ThrowException_When_TryPlayingOutOfBoard()
        {
            _game = new TicTacToeGame();
            _game.StartNew();
            
            Assert.Throws<TicTacToeException>(() => _game.Play(4, 2));
            Assert.AreEqual(Players.X, _game.CurrentPlayer);
        }

        [Test]
        public void Play_Sould_ReturnTrue_When_PlayerWin()
        {
            var hasWinner = false;
            _game = new TicTacToeGame();
            _game.StartNew();
            
            // X | O | O
            //   | X |
            //   |   | X
            
           hasWinner = _game.Play(1,1);
           Assert.IsFalse(hasWinner);
           hasWinner = _game.Play(1, 0);
           Assert.IsFalse(hasWinner);
           hasWinner = _game.Play(0, 0);
           Assert.IsFalse(hasWinner);
           hasWinner = _game.Play(0, 2);
           Assert.IsFalse(hasWinner);
           hasWinner = _game.Play(2, 2);
           Assert.IsTrue(hasWinner);
            Assert.AreEqual(Players.X,_game.CurrentPlayer);
        }

        [Test]
        public void Play_Sould_ThrowException_When_BoardIsFull()
        {
            // X | O | X
            // X | O | O
            // O | X | X

            _game = new TicTacToeGame();
            _game.StartNew();
            _game.Play(0, 0);//X
            _game.Play(1, 0);
            _game.Play(2, 0);//X
            _game.Play(2, 1);
            _game.Play(0, 1);//X
            _game.Play(1, 1);
            _game.Play(2, 2);//X
            _game.Play(0, 2);
            

            Assert.Throws<TicTacToeEndGameException>(() => _game.Play(1, 2));
        }
    }
}
