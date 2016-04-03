using System.Collections.Generic;

namespace Trivia_csharp.Completed
{
    public interface IGameRenderer
    {
        void ShowQuestion(string question);
        void ShowQuestionCategory(QuestionCategories questionCategories);
        void ShowPlayerCount(IList<Player> players);
        void ShowRolled(int roll);
        void ShowAddPlayer(string playerName);
        void ShowAnswerCorrect();
        void ShowIncorrectAnswer();

        void ShowNewPlace(Player currentPlayer);
        void ShowGettingOut(Player currentPlayer);
        void ShowPlayerPurses(Player currentPlayer);
        void ShowSentPlayerToPenality(Player currentPlayer);
        void ShowCurrentPlayer(Player currentPlayer);
    }
}