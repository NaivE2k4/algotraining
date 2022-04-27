def MergeSort(arr:list):
    """Функция сортировки слиянием"""
    if len(arr) <= 1:
        return
    middle = len(arr) // 2
    A = [arr[i] for i in range(0, middle)]
    B = [arr[i] for i in range(middle, len(arr))]
    MergeSort(A)
    MergeSort(B)
    C = merge_func(A,B)
    for i in range(len(arr)):
        arr[i] = C[i]
    

def merge_func(A:list, B:list):
    C = [0]*(len(A)+len(B))
    apos = bpos = cpos = 0
    while apos < len(A) and bpos < len(B):
        if A[apos] <= B[bpos]:
            C[cpos] = A[apos]
            apos+=1
        else:
            C[cpos] = B[bpos]
            bpos+=1
        cpos+=1
    while apos < len(A):
        C[cpos] = A[apos]
        apos+=1
        cpos+=1
    while bpos < len(B):
        C[cpos] = B[bpos]
        bpos+=1
        cpos+=1
    return C