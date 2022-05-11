﻿// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let arrSwap i j (arr:int[]) = 
    let temp = arr.[i]
    arr.[i] <- arr.[j]
    arr.[j] <- temp
    ()

//Квадратичные сортировки
//Ок, F# очень сложно вкуривать, когда писал всю жизнь на ОО-языках
//Попробуем переходить плавно, сначала просто переписать чтобы работало, без особой функциональщины
let insertSort (arr:int[])=
    for i = 1 to arr.Length - 1 do //i - инвариант, количество отсортированных элементов в массиве
        for j = i downto 1 do  //Каждый элемент сравниваем с предыдущими 
            if arr.[j] < arr.[j-1] then
                arrSwap j (j-1) arr
                //Здесь будут лишние итерации поскольку в F# нет break!=)

//Test
let mutable testArr1 = [|3;5;10;1;4|]
printfn "%A" testArr1
insertSort testArr1
    |>ignore
printfn "%A" testArr1

let insertSort2 (arr:int[])=
    for i = 1 to arr.Length - 1 do //i - инвариант, количество отсортированных элементов в массиве
        let mutable j = i
        while j > 0 && arr.[j] < arr.[j-1] do //Запихивая условие в while, убираем лишние лупы
            arrSwap j (j-1) arr
            j <- j-1
        
//Test
let mutable testArr2 = [|3;5;10;1;4|]
printfn "%A" testArr2
insertSort2 testArr2
    |>ignore
printfn "%A" testArr2


let choiceSort (arr:int[]) =
    for i = 0 to arr.Length-2 do
        let mutable min = arr.[i]
        let mutable minIndex = i
        for j = i+1 to arr.Length-1 do
            if arr.[j] < min then
                min <- arr.[j]
                minIndex <- j
        if min <> arr.[i] then
            arrSwap i minIndex arr

//Test
let mutable testArr3 = [|3;5;10;1;4|]
printfn "%A" testArr3
choiceSort testArr3
    |>ignore
printfn "%A" testArr3

let bubbleSort (arr:int[]) =
    for i = 0 to arr.Length-1 do
        for j = 0 to arr.Length-2-i do
            if arr.[j] > arr.[j+1] then
                arrSwap j (j+1) arr

//Test
let mutable testArr4 = [|3;5;10;1;4|]
printfn "%A" testArr4
bubbleSort testArr4
    |>ignore
printfn "%A" testArr4


//Базовые сортировки

let rec qsort (arr:int[]) =
    match arr.Length with
    | x when x <= 1 -> ()
    | _ -> 
        let baseElemInd = arr.Length/2
        //Пользуемся отдельными массивами. Правильнее было бы сортировать "in place"
        let left = Array.choose (fun item -> if item < arr.[baseElemInd] then Some item else None) arr
        let mid = Array.choose (fun item -> if item = arr.[baseElemInd] then Some item else None) arr
        let right = Array.choose (fun item ->if item > arr.[baseElemInd] then Some item else None) arr
        qsort left
        qsort right
        Array.Copy(left, arr, left.Length)
        Array.Copy(mid, 0, arr, left.Length, mid.Length)
        Array.Copy(right, 0, arr, left.Length+mid.Length, right.Length)
        ()

//Test
let mutable testArr5 = [|3;5;10;1;4|]
printfn "%A" testArr5
qsort testArr5
    |>ignore
printfn "%A" testArr5


let mergeFunc (srcA: int[]) (srcB: int[]) (dest: int[]) =
    let mutable indexA = 0
    let mutable indexB = 0
    let mutable indexDest = 0
    while indexA < srcA.Length && indexB < srcB.Length do
        match srcA.[indexA] with
            | x when x <= srcB.[indexB] -> 
                dest.[indexDest] <- x
                indexA <- indexA + 1
                ()
            | x when x > srcB.[indexB] ->
                dest.[indexDest] <- srcB.[indexB]
                indexB <- indexB + 1
                ()
            | _ -> ()
        indexDest <- indexDest + 1

    while indexA < srcA.Length do
        dest.[indexDest] <- srcA.[indexA]
        indexA <- indexA + 1
        indexDest <- indexDest + 1
    while indexB < srcB.Length do
        dest.[indexDest] <- srcB.[indexB]
        indexB <- indexB + 1
        indexDest <- indexDest + 1
    ()

let rec mergeSort (arr:int[]) =
    match arr.Length with
    | x when x <=1 -> ()
    | _ ->
        let left, right = Array.splitAt (arr.Length/2) arr
        mergeSort left
        mergeSort right
        mergeFunc left right arr
        ()

//Test
let mutable testArr6 = [|3;5;10;1;4|]
printfn "%A" testArr6
mergeSort testArr6
    |>ignore
printfn "%A" testArr6