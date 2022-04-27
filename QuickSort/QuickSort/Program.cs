using CSharpSortings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //var heap = new MyHeap();
            //heap.Add(5);
            //heap.Add(10);
            //heap.Add(3);
            //heap.Add(20);
            //heap.Add(8);
            //int? a;
            //while((a = heap.PopMax()) != null)
            //{
            //    Console.WriteLine(a);
            //}

            var arr = new[] { 3, 5, 7, 15, 23, 1, 6, 8, 100, 2 };
            var heap = new MyHeap(arr, arr.Length);
            int? elem = heap.PopMax();
            while(elem != null)
            {
                Console.Write(elem);
                Console.Write(' ');
                elem = heap.PopMax();
            }

            //TestSort();
            Console.ReadLine();
        }

        public static void TestAlgo(Action<List<int>> algo)
        {
            var arr1 = new List<int> { 2, 1, 5, 4, 3 };
            arr1.ForEach(a => Console.Write(a.ToString() + " "));
            Console.WriteLine();
            algo(arr1);
            arr1.ForEach(a => Console.Write(a.ToString() + " "));
            Console.WriteLine();
            var sortedArr1 = new[] { 1, 2, 3, 4, 5 };
            if(Enumerable.SequenceEqual(arr1, sortedArr1))
                Console.WriteLine("Test pass!");
            else
                Console.WriteLine("Test fail!");
        }

        public static void TestSort()
        {
            Console.WriteLine("Быстрая сортировка:");
            TestAlgo(QuickSort.Sort);

            Console.WriteLine("\nСортировка слиянием:");
            TestAlgo(MergeSort.Sort);

            Console.WriteLine("\nСортировка вставками:");
            TestAlgo(QuadraticSortings.InsertSort);

            Console.WriteLine("\nСортировка выбором:");
            TestAlgo(QuadraticSortings.ChoiseSort);

            Console.WriteLine("\nСортировка пузырьком:");
            TestAlgo(QuadraticSortings.BubbleSort);

        }
    }
}
