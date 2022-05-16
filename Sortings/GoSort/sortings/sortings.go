package sortings

func InsertSort(arr []int) {
	for i := 1; i < len(arr); i++ {
		for j := i; j > 0; j-- {
			if arr[j] < arr[j-1] {
				var temp = arr[j]
				arr[j] = arr[j-1]
				arr[j-1] = temp
			}
		}
	}
}
