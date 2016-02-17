# TennisGame

Tennis has a rather quirky scoring system, and to newcomers it can be a little difficult to keep track of. The Tennis Society has contracted you to build a scoreboard to display the current score during tennis games. The umpire will have a handset with two buttons labelled “player 1 scores” and “player 2 scores”, which he or she will press when the respective players score 
a point. When this happens, a big scoreboard display should update to show the current 
score. (When you first switch on the scoreboard, both players are assumed to have no 
points). When one of the players has won, the scoreboard should display which one. Your 
task is to write a “TennisGame” class containing the logic which outputs the correct score as 
a string for display on the scoreboard. You can assume that the umpire pressing the button 
“player 1 scores” will result in a method “WonPoint(“player1”)” being called on your class, 
and similarly WonPoint(“player2”) for the other button. Afterwards, you will get a call “Score” 
from the scoreboard asking what it should display. This property should return a string with 
the current score.

1. A game is won by the first player to have won at least four points in total and at least two 
points more than the opponent. The score is then “Win for player1” or “Win for player2”

2. The running score of each game is described in a manner peculiar to tennis: scores from 
zero to three points are described as “Love”, “Fifteen”, “Thirty”, and “Forty” respectively.

3. If at least three points have been scored by each player, and the scores are equal, the 
score is “Deuce”. 

4. If at least three points have been scored by each side and a player has one more point 
than his opponent, the score of the game is “Advantage player1” or “Advantage player2”.

