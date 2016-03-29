using System;

namespace Tennis
{
  public class TennisGame2 : TennisGame
  {
    public int P1Point = 0;
    public int P2Point = 0;
    
    private string _player1Name;
    private string _player2Name;

    private readonly string[] _scoreName = {"Love", "Fifteen", "Thirty", "Forty"};

    public TennisGame2 (string player1Name, string player2Name)
    {
      _player1Name = player1Name;
      _player2Name = player2Name;
    }


    public string GetScore(){
     
      if (P1Point == P2Point)
      {
          if (P1Point < 3)
          {
              return _scoreName[P1Point] + "-All";
          }
         return "Deuce";
      }

      if (P1Point >= 4 || P2Point >= 4)
      {
          string score = ScoreDiff < 2 ? "Advantage ": "Win for ";
          return score + BestPlayer;
      }
      
       return P1Res + "-" + P2Res;
    }

      private int ScoreDiff
      {
          get { return Math.Abs(P1Point - P2Point); }
      }

      public string BestPlayer { get { return P1Point >= P2Point ? _player1Name : _player2Name; } }

      private string P2Res
      {
          get { return _scoreName[P2Point]; }
      }

      private string P1Res
      {
          get { return _scoreName[P1Point]; }
      }

      public void WonPoint(string player) {
      if (player == _player1Name)
          P1Point++;
      else
          P2Point++;
    }
  }
}