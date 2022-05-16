module backpack

//Задача о дискретном рюкзаке
//Даны N предметов с указанными весами и стоимостями
//Дан рюкзак указанной максимальной вместимости по весу
//Найти оптимальный набор предметов, т.е. влезающий в рюкзак и максимальный по стоимости
let backpack (weights: int[]) (values: int[]) maxweight =
    let F = Array2D.create (weights.Length+1) (maxweight+1) 0
    for curitem = 1 to weights.Length do //Крутимся по предметам по очереди
        for curmass = 1 to maxweight do //Для каждого предмета, для каждого возможного размера рюкзака 1..M будем вычислять оптимальную стоимость на основании предыдущих данных
            //Если предмет влезает то надо взять максимум из 
            //а) подсчитанного рюкзака такого же размера БЕЗ этого предмета 
            //б) Этого предмета + подсчитанного рюкзака равного остатку после поклажи этого предмета
            //Иначе просто взять посчитанный максимум для рюкзака такогоразмера без этого предмета
            F.[curitem,curmass] <- 
                match weights.[curitem-1] with
                | curweight when curweight <= curmass ->
                    max (values.[curitem-1] + F.[curitem-1, curmass-curweight]) F.[curitem-1, curmass]
                | curweight when curweight > curmass ->
                    F.[curitem-1, curmass]
                | _ -> 0
        
    F


let getbackpackindexes (F: int[,]) (weights: int[]) (values: int[]) backpacksize =
    let mutable maxval = F.[weights.Length, backpacksize]
    let mutable answer = []
    let mutable curitemInd = weights.Length
    let mutable cursize = backpacksize
    while maxval > 0 do
        if F.[curitemInd, cursize] > F.[curitemInd-1, cursize] then
            answer <- List.append answer [curitemInd-1]
            maxval <- maxval - values.[curitemInd-1]
            cursize <- cursize - weights.[curitemInd-1]
            curitemInd <- curitemInd - 1
        else
            curitemInd <- curitemInd-1
    answer