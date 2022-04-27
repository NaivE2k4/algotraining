import QuickSort
import MergeSort
import QuadraticSortings

def TestAlgo(algo):
    print("Тестируем: ", algo.__doc__)
    arr = [3,2,5,4,1]
    algo(arr)
    test_arr = [1,2,3,4,5]
    if arr == test_arr:
        print("Test ok!")
    else:
        print("Test FAIL!")

TestAlgo(QuickSort.QuickSort)
TestAlgo(MergeSort.MergeSort)
TestAlgo(QuadraticSortings.InsertSort)
TestAlgo(QuadraticSortings.ChoiseSort)
TestAlgo(QuadraticSortings.BubbleSort)

import heap
arr = [3,5,1,2,10,6,8,4]
print(heap.heapify_fast(arr))
