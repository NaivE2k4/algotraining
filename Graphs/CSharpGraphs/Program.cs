using System;
using System.Collections.Generic;

namespace CSharpGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Граф из лекции Хирьянова https://www.youtube.com/watch?v=2N6YbTc-USw&list=PLRDzFCPr95fK7tr47883DFUbm4GeOjjc0&index=25&ab_channel=%D0%A2%D0%B8%D0%BC%D0%BE%D1%84%D0%B5%D0%B9%D0%A5%D0%B8%D1%80%D1%8C%D1%8F%D0%BD%D0%BE%D0%B2
            //(Для более легкой проверки)
            var graph = new Dictionary<int, Dictionary<int, int>>
            {
                { 0, new Dictionary<int, int>{ {1,2}, {7,15} } }, //A->B(2),H(15)
                { 1, new Dictionary<int, int>{ {0,2}, {2,1}, {3,5} } }, //B->A(2),C(1),D(5)
                { 2, new Dictionary<int, int>{ {1,1},{3,3},{5,2},{6,1} } }, //C-> B(1),D(3),F(2),G(1)
                { 3, new Dictionary<int, int>{ {1,5},{2,3},{5,4},{4,6} } },//D->B(5),C(3),F(4),E(6)
                { 4, new Dictionary<int, int>{ {3,6},{5,7},{8,2}} },//E->D(6),F(7),I(2)
                { 5, new Dictionary<int, int>{ {2,2},{3,4},{4,7},{6,1},{7,3} } },//F->C(2),D(4),E(7),G(1),H(3)
                { 6, new Dictionary<int, int>{ {2,1},{5,1} } }, //G->C(1),F(1)
                { 7, new Dictionary<int, int>{ {0,15},{8,12} } }, //H->A(15),I(12)
                { 8, new Dictionary<int, int>{ {4,2},{7,12} } }, //I->E(2),H(12)
                { 9, new Dictionary<int, int>{ { 10,2} } }, //J
                { 10, new Dictionary<int, int>{ { 9,2} } } //K

            };
            //var res = DykstraAlgo.DykstraQueue(graph, 0, 8);
            var res = DykstraAlgo.DykstraGreedy(graph, 0, 8);
            foreach(var index in res)
                Console.Write($"{index} ");
            Console.ReadLine();
        }
    }
}
