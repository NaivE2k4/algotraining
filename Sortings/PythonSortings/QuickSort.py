def QuickSort(arr):
    """Функция быстрой сортировки"""
    if len(arr) <= 1:
        return
    base = arr[len(arr) // 2]
    L = []
    R = []
    M = []
    for i in range(len(arr)):
        if arr[i] < base:
            L.append(arr[i])
        elif arr[i] == base:
            M.append(arr[i])
        else:
            R.append(arr[i])

    QuickSort(L)
    QuickSort(R)
    k = 0
    for x in L+M+R:
        arr[k] = x
        k+=1
    
