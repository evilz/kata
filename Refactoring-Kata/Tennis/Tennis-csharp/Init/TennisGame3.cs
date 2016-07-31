using System;

namespace Tennis
{
    public class TennisGame3 : TennisGame
    {
        private int _player2Score;
        private int _player1Score;
        private readonly string _player1Name;
        private readonly string _player2Name;

        readonly string[] _scoreNames = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public string GetScore()
        {

            if ((_player1Score >= 4 || _player2Score >= 4) || (_player1Score + _player2Score >= 6))
            {
                if (_player1Score == _player2Score)
                    return "Deuce";

                return ScoreDiff == 1
                    ? "Advantage " + BestPlayer
                    : "Win for " + BestPlayer;
            }

            return (_player1Score == _player2Score) ? ScoreNamePlayer1 + "-All" : ScoreNamePlayer1 + "-" + ScoreNamePlayer2;
        }

        private int ScoreDiff
        {
            get { return Math.Abs(_player1Score - _player2Score); }
        }

        private string BestPlayer
        {
            get { return _player1Score > _player2Score ? _player1Name : _player2Name; }
        }
        
        private string ScoreNamePlayer2
        {
            get { return _scoreNames[_player2Score]; }
        }

        private string ScoreNamePlayer1
        {
            get { return _scoreNames[_player1Score]; }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _player1Score++;
            else
                _player2Score++;
        }
    }
}

