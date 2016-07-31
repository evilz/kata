namespace Tennis

type point = int
type PlayerScore = {name:string ; point:point  }

type TennisGame = {player1:PlayerScore; player2:PlayerScore} with

    member x.setPlayersScore p1Points p2Points =
        {
            player1 = {name = x.player1.name; point = p1Points } ; 
            player2 = { name = x.player2.name; point = p2Points }
        }

    member x.setPlayer1Score point = x.setPlayersScore point x.player2.point
       
    member x.setPlayer2Score point = x.setPlayersScore x.player1.point point
        
    member x.player1ScoreInc = x.setPlayer1Score (x.player1.point + 1)

    member x.player2ScoreInc = x.setPlayer2Score (x.player2.point + 1)

    member x.leader =  
        match x with
        | { TennisGame.player1 = p1; TennisGame.player2 = p2 } when p1.point > p2.point -> Some(p1)
        | { TennisGame.player1 = p1; TennisGame.player2 = p2 }  when p1.point < p2.point -> Some(p2)
        | _ -> None

    member x.hasWinner = 
        (x.player1.point >= 4 || x.player2.point >= 4) && (abs(x.player1.point - x.player2.point) >= 2)

    member x.isUpperForty = 
        (x.player1.point >= 3 && x.player2.point >= 3)

    member x.isDeuce = 
        x.isUpperForty && x.leader.IsNone

    member x.hasAvantage = 
        x.isUpperForty && x.leader.IsSome

module TennisKata =

    // ==== active pattern =====
    let (|HasWinner|IsDeuce|HasAvantage|Equality|Nothing|) (game:TennisGame) =
        if game.hasWinner then HasWinner
        elif game.isDeuce then IsDeuce
        elif game.hasAvantage then HasAvantage
        elif game.leader.IsNone then Equality
        else Nothing

    let wonPoint game playerName =
        match game with
        | { TennisGame.player1 = p1 } when p1.name = playerName -> game.player1ScoreInc 
        | { TennisGame.player2 = p2 } when p2.name = playerName -> game.player2ScoreInc
        | _ -> game

    let GetScoreTitle game = 
        let labelScore = [|"Love";"Fifteen";"Thirty";"Forty";|]
        match game with
        | HasWinner   -> game.leader.Value.name + " wins"
        | IsDeuce     -> "Deuce"
        | HasAvantage -> "advantage " + game.leader.Value.name  
        | Equality    -> labelScore.[game.player1.point] + "-All"
        | _           -> labelScore.[game.player1.point] + "-" + labelScore.[game.player2.point]

