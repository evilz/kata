namespace FizzBuzz.Tests

open NUnit.Framework
open FsUnit
open FizzBuzz

[<TestFixture>]
type ``Given a fizz buzz object``() = 
    let kata = new FizzBuzzKata()
    
    let ``should be equal to fizz`` (n) = n |> kata.make |> should equal "fizz"
    let ``should be equal to buzz`` (n) = n |> kata.make |> should equal "buzz"  
    let ``should be equal to fizzbuzz`` (n) = n |> kata.make |> should equal "fizzbuzz"
    let ``should same as input`` (n) = n |> kata.make |> should equal (n.ToString())

    [<Test>]
    member x.``when number is divisible by three is replaced by word fizz``() = 
        [ 6; 9; 12 ] |> List.iter ``should be equal to fizz``
    
    [<Test>]
    member x.``when number is divisible by five is replaced by word buzz``() = 
        [ 5; 10 ] |> List.iter ``should be equal to buzz``
    
    [<Test>]
    member x.``when number is divisible by three and five is replaced by word fizzbuzz``() = 
        15 |> ``should be equal to fizzbuzz``
    
    [<Test>]
    member x.``when number is not divisible by three or five is not replaced``() = 
        [ 4; 7; 8; 11; 13; 14 ] |> List.iter ``should same as input`` 