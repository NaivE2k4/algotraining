using System;

namespace CSharpDynamicProg
{
    class Program
    {
        static void Main(string[] args)
        {
            //var res = Subsequences.PrefixFunc("abcabcasab");
            //var res = Subsequences.SubstringKMP("abcdabdeabfgabcdefgh", "abc");
            //var res = Subsequences.CoolerZFunc("abcabcasab");
            //var res = Subsequences.SubstringKMP("abcdabdeabfgabcdefgh", "abc", true);
            var masses = new int[] { 2, 1, 3 };
            var values = new int[] { 4, 2, 5 };
            var res = Backpack.DiscreteBackpack(5, masses, values);
            Console.ReadLine();
        }
    }
}
