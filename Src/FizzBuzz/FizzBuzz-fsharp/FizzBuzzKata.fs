namespace FizzBuzz


type FizzBuzzKata() = 
    member this.make (x:int) = 
        match (x % 3, x % 5) with
        | (0,0) -> "fizzbuzz"
        | (0,_) -> "fizz"
        | (_,0) -> "buzz"
        | _ -> x.ToString()



   
    
 