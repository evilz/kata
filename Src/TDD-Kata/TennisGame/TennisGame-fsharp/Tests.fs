module Tests

open NUnit.Framework
open FsUnit
open Tennis
open TennisKata

[<TestFixture>]
type ``Given a starting tennis game between Julien and Vincent``() = 
    
    let player1 = "PlayerOne"
    let player2 = "PlayerTwo"

    let game = 
        { player1 = 
              { name = player1
                point = 0 }
          player2 = 
              { name = player2
                point = 0 } }
   
    [<Test>]
    member x.``When player one wins one point, the score is 'fifteen-love'.``() = 
        let newScore = wonPoint game player1
        newScore.player1.point |> should equal 1
        GetScoreTitle newScore |> should equal "Fifteen-Love"
    
    [<Test>]
    member x.``When player two wins one point, the score is 'Love-Fifteen'.``() = 
        let newScore = wonPoint game player2
        newScore.player2.point |> should equal 1
        GetScoreTitle newScore |> should equal "Love-Fifteen"
    
    [<Test>]
    member x.``When player one wins one point and player two wins one point, the score is 'fifteen-all'.``() = 
        let newScore = wonPoint game player1
        let newScore = wonPoint newScore player2
        newScore.player1.point |> should equal 1
        newScore.player2.point |> should equal 1
        GetScoreTitle newScore |> should equal "Fifteen-All"
    
    [<Test>]
    member x.``When player one wins two points and player two wins three points, the score is 'thirty-forty'.``() = 
        game.setPlayersScore 2 3
        |> GetScoreTitle
        |> should equal "Thirty-Forty"
    
    [<Test>]
    member x.``When player one wins no points and player two wins three points, the score is 'love-forty'.``() = 
        game.setPlayersScore 0 3
        |> GetScoreTitle
        |> should equal "Love-Forty"
    
    [<Test>]
    member x.``When player one wins three points and player two wins three points, the score is 'deuce'.``() = 
        game.setPlayersScore  3 3
        |> GetScoreTitle
        |> should equal "Deuce"
    
    [<Test>]
    member x.``When player one wins five points and player two wins five points, the score is 'deuce'.``() = 
        game.setPlayersScore  5 5
        |> GetScoreTitle
        |> should equal "Deuce"
    
    [<Test>]
    member x.``When player one wins four points and player two wins three points, the score is 'advantage player one'.``() = 
        game.setPlayersScore  4 3
        |> GetScoreTitle
        |> should equal "advantage PlayerOne"
    
    [<Test>]
    member x.``When player one wins four points and player two wins five points, the score is 'advantage player two'.``() = 
        game.setPlayersScore  4 5
        |> GetScoreTitle
        |>  should equal "advantage PlayerTwo"
    
    [<Test>]
    member x.``When player one wins four points, the score is 'player one wins'``() = 
        game.setPlayersScore  4 0
        |> GetScoreTitle
        |>  should equal "PlayerOne wins"
    
    [<Test>]
    member x.``When player one wins five points and player two wins three points, the score is 'player one wins'.``() = 
        game.setPlayersScore  5 3
        |> GetScoreTitle
        |>  should equal "PlayerOne wins"
    
    [<Test>]
    member x.``When player one wins six points and player two wins eight points, the score is 'player two wins'.``() = 
        game.setPlayersScore  6 8
        |> GetScoreTitle
        |>  should equal "PlayerTwo wins" 

