module subsequences
//Функция для поиска длины наибольшей возрастающей подпоследовательности
//Здесь сделано из своей головы, у Хирьянова поизящнее наверное, через максимум (см решение на питоне)
//Решение ошибочно!
let gis (arr:int[]) =
    let F = Array.init arr.Length (fun i -> if i = 0 then 1 else 0)
    for i = 1 to arr.Length-1 do
        let mutable j = i - 1
        let mutable max = 0
        while j >=0  do
            if arr.[j] < arr.[i] && F.[j] > max then
                max <- F.[j]
            j <- j-1
        match max with
            | 0 -> F.[i] <-1
            | _ -> F.[i] <- max + 1
    F

//Попытка переписать в функциональном стиле 1
let gis2 (arr:int[]) =
    let getmax i (arr:int[]) (F:int[])=
        let mutable j = i - 1
        let mutable max = 0
        while j >=0  do
            if arr.[j] < arr.[i] && F.[j] > max then
                max <- F.[j]
            j <- j-1
        max
    let F = Array.init arr.Length (fun i -> if i = 0 then 1 else 0)
    for i = 1 to arr.Length-1 do
        match getmax i arr F with
            | 0 -> F.[i] <-1
            | max -> F.[i] <- max + 1
    F

//Попытка переписать в функциональном стиле 2
let gis3 (arr:int[]) =
    let rec getmax j target curmax (arr:int[]) (F:int[]) =
        match j with
            | 0 -> curmax
            | j -> 
                if arr.[j] < target && F.[j] > curmax then
                    getmax (j-1) target F.[j] arr F
                else
                    getmax (j-1) target curmax arr F

    let F = Array.init arr.Length (fun i -> if i = 0 then 1 else 0)
    for i = 1 to arr.Length-1 do
        match getmax (i-1) arr.[i] 0 arr F with
            | 0 -> F.[i] <-1
            | max -> F.[i] <- max + 1
    F

//Попытка переписать в функциональном стиле 3
let gis4 (arr:int[]) =
    let rec getmax j target curmax (arr:int[]) (F:int[]) =
        match j with
        | 0 -> curmax
        | j -> 
            match arr.[j], F.[j] with
            | arrj, fj when arrj < target && fj > curmax -> getmax (j-1) target F.[j] arr F
            | _ -> getmax (j-1) target curmax arr F

    let rec iter (arr:int[]) (F:int[]) i =
        match i with
        | i when i = arr.Length -> ()
        | _ ->  match getmax (i-1) arr.[i] 0 arr F with
                | 0 -> F.[i] <-1
                | max -> F.[i] <- max + 1
                iter arr F (i+1)

    let F = Array.init arr.Length (fun i -> if i = 0 then 1 else 0)
    iter arr F 1
    F
//Пока мне не видно преимуществ в таком подходе, но я допускаю, что я пока не особо много чего понимаю


//Функция для поиска рассторяния Левенштейна
//let levenstein str1 str2 = 
    