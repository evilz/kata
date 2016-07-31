using System.Collections.Generic;
using System.IO;

namespace Trivia_csharp.Completed
{
    public class TextRenderer : IGameRenderer
    {
        private readonly TextWriter _writer;

        public TextRenderer(TextWriter writer)
        {
            _writer = writer;
        }

        public  void ShowQuestionCategory(QuestionCategories questionCategories)
        {
            _writer.WriteLine($"The category is {questionCategories}");
        }

        public  void ShowRolled(int roll)
        {
            _writer.WriteLine($"They have rolled a {roll}");
        }

        public  void ShowAddPlayer(string playerName)
        {
            _writer.WriteLine($"{playerName} was added");
        }

        public  void ShowAnswerCorrect()
        {
            _writer.WriteLine("Answer was correct!!!!");
        }

        public  void ShowIncorrectAnswer()
        {
            _writer.WriteLine("Question was incorrectly answered");
        }

        public  void ShowNewPlace(Player currentPlayer)
        {
            _writer.WriteLine($"{currentPlayer}'s new location is {currentPlayer.Place}");
        }

        public  void ShowGettingOut(Player currentPlayer)
        {
            _writer.WriteLine(currentPlayer.IsGettingOutOfPenaltyBox
                ? $"{currentPlayer} is getting out of the penalty box"
                : $"{currentPlayer} is not getting out of the penalty box");
        }

        public  void ShowCurrentPlayer(Player currentPlayer)
        {
            _writer.WriteLine($"{currentPlayer} is the current player");
        }

        public  void ShowPlayerCount(IList<Player> players)
        {
            _writer.WriteLine($"They are player number {players.Count}");
        }

        public  void ShowQuestion(string question)
        {
            _writer.WriteLine(question);
        }

        public  void ShowPlayerPurses(Player currentPlayer)
        {
            _writer.WriteLine($"{currentPlayer} now has {currentPlayer.Purse} Gold Coins.");
        }

        public  void ShowSentPlayerToPenality(Player currentPlayer)
        {
            _writer.WriteLine($"{currentPlayer} was sent to the penalty box");
        }
    }
}