using System;

namespace Tennis
{
    class TennisGame1 : TennisGame
    {
        private int _score1;
        private int _score2;
        private readonly string _player1Name;
        private readonly string _player2Name;

        readonly string[] _scoreNames = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _score1 += 1;
            else
                _score2 += 1;
        }

        public string GetScore()
        {
           if (_score1 == _score2)
            {
                if (_score1 > 2) 
                    return "Deuce";
                
               return ScorePlayer1 + "-All";
            }
            
            if (_score1 >= 4 || _score2 >= 4)
            {
               var score = ScoreDiff == 1 ? "Advantage " : "Win for ";
               return score + BestPlayer;
            }
            
            return string.Format("{0}-{1}", ScorePlayer1, ScorePlayer2);
        }

        private string ScorePlayer2
        {
            get { return _scoreNames[_score2]; }
        }

        private string ScorePlayer1
        {
            get { return _scoreNames[_score1]; }
        }

        private int ScoreDiff
        {
            get { return Math.Abs(_score1 - _score2); }
        }

        public string BestPlayer
        {
            get { return _score1 >= _score2 ? _player1Name : _player2Name; }
        }
    }
}