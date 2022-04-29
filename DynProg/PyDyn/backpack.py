def backpack(Mmax, M, V):
    ###
    ##Задача о дискретном рюкзаке
    #Нужно заполнить таблицу (дин программирование) для всех размеров рюкзака меньше данного
    ###
    F = [[0 for backpackSize in range(0, Mmax + 1)] for itemNum in range(0,len(M)+1)]
    for itemid in range(1, len(M)+1):
        for backpackSize in range(1, Mmax+1):
            if(M[itemid - 1] <= backpackSize): #Текущий предмет влезает в пустой рюкзак размера b.s.
                mfree = backpackSize - M[itemid-1] #Свободная масса если данный предмет класть в рюкзак первым
                currentPossibleV = V[itemid-1] + F[itemid-1][mfree] 
                if currentPossibleV > F[itemid][backpackSize-1] and currentPossibleV > F[itemid-1][backpackSize]:#Стоимость данного предмета + стоимость свободного остающегося места в рюкзаке без этого предмета
                    F[itemid][backpackSize] = currentPossibleV
                else:
                    F[itemid][backpackSize] = max(F[itemid][backpackSize-1], F[itemid-1][backpackSize])
            else: #Предмет не влезает в пустой рюкзак - берем лучшее из предыдущего
                F[itemid][backpackSize] = F[itemid-1][backpackSize]
    return F

def get_chosen_items(matrix, weights, mmax):
    result = []
    m = mmax
    for i in range(len(weights), 0, -1):#Обратный цикл по предметам
        if(matrix[i][m] == matrix[i-1][m]): #Без этого предмета такая же стоимость
            continue #Этот предмет не берем
        result.append(i-1)
        m -= weights[i-1] # предмет берем, вычитаем из общей массы его массу
        if m == 0:
            break;
    return result
