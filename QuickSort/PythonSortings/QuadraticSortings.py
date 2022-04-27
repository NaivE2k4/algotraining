def InsertSort(arr):
    """Функция сортировки вставками"""
    for pos in range(1, len(arr)):
        i = pos
        while i > 0 and arr[i] < arr[i-1]:
            arr[i], arr[i-1] = arr[i-1], arr[i]
            i-=1



def ChoiseSort(arr):
    """Функция сортировки выбором"""
    for pos in range(len(arr)-1):
        for x in range(pos,len(arr)):
            if arr[pos] > arr[x]:
                arr[pos],arr[x] = arr[x], arr[pos]

    

def BubbleSort(arr):
    """Функция сортировки пузырьком"""
    for pos in range(len(arr)-1):
        for x in range(0, len(arr) - 1 - pos):
            if arr[x]>arr[x+1]:
                arr[x],arr[x+1] = arr[x+1], arr[x]

