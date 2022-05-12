
def gis(A):
    ###
    #A - массив натуральных чисел
    #
    #f = max(Fj) если a[i]> f[j] и i>j
    ####
    F = [0]*(len(A)+1) #Нолик будем использовать для старта. В F хранятся длины наиб возр посл для А[i]
    for i in range(1, len(A)+1):
        max = 0
        for j in range(0, i):
            if(A[j]<A[i-1] and F[j] > max):
                max = F[j]
        F[i] = max + 1

    print(F)


def levenstein(A:str, B:str):
    F = [[0]* (len(B) +1) for x in range(len(A)+1)]
    for i in range(1, len(A)+1):
        for j in range(1, len(B)+1):
            if(A[i-1] == B[j-1]):
                F[i][j] = F[i-1][j-1]
            else:
                F[i][j] = min(F[i-1][j],F[i][j-1], F[i-1][j-1])+1
    print(end="  ")
    for j in range(0, len(B)):
        print(B[j],end=' ')

    print()
    for i in range(1, len(A)+1):
        print(A[i-1], end=' ')
        for j in range(1,len(B)+1):
            print(F[i][j], end=' ')
        print



def pref_func(S):
    P = [0]*(len(S))
    for i in range(1, len(S)):
        Pprev = P[i-1] #длина ПФ для предыдущей строки
        #если предыдущий префикс+1 элемент == новому элементу то длина +=1
        while Pprev > 0 and S[Pprev] != S[i]:
            Pprev = P[Pprev-1]#Тут была ошибка!
        if(S[Pprev] == S[i]):
            Pprev+=1
        P[i] = Pprev

    return P

def find_substr(source, substr):
    S = substr+'#'+source
    P = pref_func(S)
    l = len(substr)
    for i in range(0,len(source)):
        if P[i+l+1] == l:
            print(i-l+1,' ');