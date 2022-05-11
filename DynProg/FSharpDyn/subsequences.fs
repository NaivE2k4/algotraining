module subsequences
//Функция для поиска длины наибольшей возрастающей подпоследовательности
//Здесь сделано из своей головы, у Хирьянова поизящнее наверное, через максимум (см решение на питоне)
//Решение ошибочно!
let gis (arr:int[]) =
    let F = Array.init arr.Length (fun i -> if i = 0 then 1 else 0)
    for i = 1 to arr.Length-1 do
        let mutable j = i - 1
        while j>=0 && arr.[j] > arr.[i] do
            j <- j-1
        match j with
            | -1 -> F.[i] <-1
            | _ -> F.[i] <- F.[j] + 1
    F

//попробуем модифицировать в функциональном стиле
let gis2 (arr:int[]) =
    let first_lesser i (arr:int[]) =
        let mutable j = i - 1
        while j>=0 && arr.[j] > arr.[i] do
            j <- j-1
        j

    let F = Array.init arr.Length (fun i -> if i = 0 then 1 else 0)
    for i = 1 to arr.Length-1 do
        match first_lesser i arr with
            | -1 -> F.[i] <- 1
            | j -> F.[i] <- F.[j] + 1
    F

//попробуем модифицировать в функциональном стиле
let gis3 (arr:int[]) =
    let rec mutator j i (arr:int[]) =
        match j with
            | -1 -> j
            | x when arr.[x] < arr.[i] -> j
            | _ -> mutator (j-1) i arr

    let F = Array.init arr.Length (fun i -> if i = 0 then 1 else 0)
    for i = 1 to arr.Length-1 do
        match mutator (i-1) i arr with
            | -1 -> F.[i] <- 1
            | j -> F.[i] <- F.[j] + 1
    F
//Функция для поиска рассторяния Левенштейна
//let levenstein str1 str2 = 
    