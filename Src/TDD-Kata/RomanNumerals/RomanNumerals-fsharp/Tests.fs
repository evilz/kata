module Tests

open RomanNumerals
open NUnit.Framework
open FsUnit


[<TestFixture>]
type ``Arabic to Roman``() = 
  
    [<TestCase(1, "I")>]
    [<TestCase(5, "V")>]
    [<TestCase(10, "X")>]
    [<TestCase(50, "L")>]
    [<TestCase(100, "C")>]
    [<TestCase(500, "D")>]
    [<TestCase(1000, "M")>]
    member x.``When an arabic number is passed, the correct Roman numeral is returned..``(arabic, roman) = 
        arabic 
        |> ToRoman 
        |> should equal roman

    