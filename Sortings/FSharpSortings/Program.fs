// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open sortfuncs


//Test
let mutable testArr1 = [|3;5;10;1;4|]
printfn "%A" testArr1
insertSort testArr1
    |>ignore
printfn "%A" testArr1

//Test
let mutable testArr2 = [|3;5;10;1;4|]
printfn "%A" testArr2
insertSort2 testArr2
    |>ignore
printfn "%A" testArr2

//Test
let mutable testArr3 = [|3;5;10;1;4|]
printfn "%A" testArr3
choiceSort testArr3
    |>ignore
printfn "%A" testArr3

//Test
let mutable testArr4 = [|3;5;10;1;4|]
printfn "%A" testArr4
bubbleSort testArr4
    |>ignore
printfn "%A" testArr4

//Test
let mutable testArr5 = [|3;5;10;1;4|]
printfn "%A" testArr5
qsort testArr5
    |>ignore
printfn "%A" testArr5

//Test
let mutable testArr6 = [|3;5;10;1;4|]
printfn "%A" testArr6
mergeSort testArr6
    |>ignore
printfn "%A" testArr6