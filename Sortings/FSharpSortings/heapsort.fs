module heapsort

//Попробуем пока без класса
type Heap = {arr:int[]; mutable heaplen: int}
    //| Empty
    //| Node of int * Heap * Heap

let heapswap i j heap =
    let temp = heap.arr.[i]
    heap.arr.[i] <- heap.arr.[j]
    heap.arr.[j] <- temp
    ()

let rec sift_up index heap =
    match index with
        | 0 -> ()
        | _ ->  
            let parentIndex = (index-1)/2
            if heap.arr.[parentIndex] > heap.arr.[index] then
                heapswap parentIndex index heap
                sift_up parentIndex heap
            ()

let heap_add item heap =
    let len = heap.heaplen
    if len = heap.arr.Length then
        failwith "Heap overflow!"
    heap.arr.[len] <- item
    heap.heaplen <- len + 1
    sift_up len heap
    ()

//Функция возвращает значение и индекс первого ребенка в массиве, если он там есть
let get_left_child index heap =
    let childindex = index*2 + 1
    match childindex with
        | x when x < heap.heaplen -> Some (heap.arr.[x], childindex)
        | _ -> None
//Функция возвращает значение и индекс второго ребенка в массиве, если он там есть
let get_right_child index heap =
    let childindex = index*2 + 2
    match childindex with
        | x when x < heap.heaplen -> Some (heap.arr.[x], childindex)
        | _ -> None

//Функция проталкивает элемент вниз для восстановления свойства кучи после pop min
let rec sift_down index heap =
    let left = get_left_child index heap
    let right = get_right_child index heap
    let parentVal = heap.arr.[index]
    match left, right with
        | None, _ -> () //Нет потомков
        | (Some (leftval, leftindex), Some (rightval, rightindex)) when rightval < leftval && rightval < parentVal -> //Есть оба потомка и правый меньше чем левый
            heapswap index rightindex heap
            sift_down rightindex heap
        | (Some (leftval, leftindex), _) when leftval < parentVal -> //Правого нет или он не меньше чем левый
            heapswap index leftindex heap
            sift_down leftindex heap
        | _,_ -> () //Оба потомка не меньше


//Функция возвращает верхний элемент кучи, минимальный, и проводит "ребалансировку" для сохранения свойств кучи
let heap_pop heap =
    match heap.heaplen with
    | 0 -> failwith "heap is empty!"
    | _ -> 
        let result = heap.arr.[0]
        heap.heaplen <- heap.heaplen-1
        match heap.heaplen with
            | 0 -> result
            | _ -> 
                heap.arr.[0] <- heap.arr.[heap.heaplen]
                sift_down 0 heap
                result

let heapify (arr:int[]) len =
    let heap = {arr = arr; heaplen = len}
    for i = arr.Length/2 downto 0 do
        sift_down i heap
    heap

open System

let heapsort (arr: int[]) = 
    let heap = heapify arr arr.Length
    let sorted = Array.zeroCreate arr.Length
    let mutable counter = 0
    while heap.heaplen > 0 do
        sorted.[counter] <- heap_pop heap
        counter <- counter + 1
    Array.Copy(sorted, arr, arr.Length)
    ()