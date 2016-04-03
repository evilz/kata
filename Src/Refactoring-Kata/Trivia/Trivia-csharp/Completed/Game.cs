using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia_csharp.Completed
{
    public class Game
    {
        private readonly IGameRenderer _renderer;
        private readonly List<Player> _players = new List<Player>();
        private Player _currentPlayer;
        
        private readonly IDictionary<QuestionCategories, Queue<string>> _questions = new Dictionary<QuestionCategories, Queue<string>>();

        public Game() : this(new TextRenderer(Console.Out)) {}

        public Game(IGameRenderer renderer)
        {
            _renderer = renderer;
            CreateQuestions();
        }
        
        public bool IsPlayable => _players.Count >= 2;

        public bool Add(string playerName)
        {
            var newPllayer = new Player(playerName, _renderer);
            _players.Add(newPllayer);
            
            if (_currentPlayer == null) { _currentPlayer = _players[0]; }

            _renderer.ShowAddPlayer(playerName);
            _renderer.ShowPlayerCount(_players);
            return true;
        }

        public bool WasCorrectlyAnswered()
        {
            if (_currentPlayer.InPenaltyBox && !_currentPlayer.IsGettingOutOfPenaltyBox)
            {
                ChangePlayer();
                return true;
            }

            _renderer.ShowAnswerCorrect();
            _currentPlayer.Purse++;
            ChangePlayer();

            return DidPlayerWin;
        }

        public void Roll(int roll)
        {
            _renderer.ShowCurrentPlayer(_currentPlayer);
            _renderer.ShowRolled(roll);

            if (_currentPlayer.InPenaltyBox)
            {
                _currentPlayer.IsGettingOutOfPenaltyBox = IsGettingOutOfPenaltyBox(roll);
                if (!_currentPlayer.IsGettingOutOfPenaltyBox) return;
            }

            _currentPlayer.MoveOf(roll);
         
            _renderer.ShowQuestionCategory(CurrentCategory);
            _renderer.ShowQuestion(GetNextQuestion());
        }

        private static bool IsGettingOutOfPenaltyBox(int roll)
        {
            return roll % 2 != 0;
        }

        private void CreateQuestions()
        {
            var allQuestionCategories = Enum.GetValues(typeof(QuestionCategories)).Cast<QuestionCategories>().ToList();
            foreach (var category in allQuestionCategories)
            {
                _questions.Add(category, new Queue<string>(Enumerable.Range(0, 50).Select(i => category + " Question " + i)));
            }
        }
        
        private string GetNextQuestion()
        {
            return _questions[CurrentCategory].Dequeue();
        }

        private QuestionCategories CurrentCategory => (QuestionCategories)(_currentPlayer.Place % 4);

        private void ChangePlayer()
        {
            var index = _players.IndexOf(_currentPlayer) + 1;
            _currentPlayer = _players[index % _players.Count];
        }

        public bool WrongAnswer()
        {
            _renderer.ShowIncorrectAnswer();
            _currentPlayer.InPenaltyBox = true;
            ChangePlayer();
            return true;
        }
        
        private bool DidPlayerWin => _currentPlayer.Purse != 6;
        
    }
}
