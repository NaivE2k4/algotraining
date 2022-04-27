using System;

namespace CSharpBinTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new MyBinTree();
            tree.Add(3);
            tree.Add(0);
            tree.Add(7);
            tree.Add(2);
            tree.Add(5);
            tree.Add(9);
            tree.Add(8);
            tree.Add(10);
            tree.Add(6);

            //tree.Remove(7);
            tree.Search(6);
            tree.Search(100);
            Console.ReadLine();
        }
    }
}
