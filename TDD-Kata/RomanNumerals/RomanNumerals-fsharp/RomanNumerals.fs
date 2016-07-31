module RomanNumerals

open System

type RomanMapping = { Symbol:string; Threshold:int }

let Thresholds = [
    { Symbol = "M" ; Threshold = 1000 };
    { Symbol = "CM" ; Threshold = 900 };
    { Symbol = "D" ; Threshold = 500 };
    { Symbol = "CD" ; Threshold = 400 };
    { Symbol = "C" ; Threshold = 100 };
    { Symbol = "XC" ; Threshold = 90 };
    { Symbol = "L" ; Threshold = 50 };
    { Symbol = "XL" ; Threshold = 40 };
    { Symbol = "X" ; Threshold = 10 };
    { Symbol = "IX" ; Threshold = 9 };
    { Symbol = "V" ; Threshold = 5 };
    { Symbol = "IV" ; Threshold = 4 };
    { Symbol = "I" ; Threshold = 1 }
]

let Decrement a b = a - b

let (|MatchSymbol|_|) value =
    Thresholds
    |> Seq.tryFind (fun x -> x.Threshold <= value)


let TranslateAndDecrement n m =
    let decrementedValue = Decrement n m.Threshold
    Some((decrementedValue, m))

let ToRoman arabic =

    let rec Romanize n =
        let next =
            match n with
            | MatchSymbol m -> TranslateAndDecrement n m
            | _ -> None
        if next.IsNone then "" else snd(next.Value).Symbol + (Romanize (fst next.Value))

    Romanize arabic
