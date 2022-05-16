package main

import (
	"fmt"
	"gosortings/sortings"
)

func main() {
	fmt.Println("Hello, World!")
	arr := []int{3, 2, 5, 4, 1}
	sortings.InsertSort(arr)
	fmt.Println(arr)
}
