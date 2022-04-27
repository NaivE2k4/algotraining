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
            var res = Subsequences.SubstringKMP("abcdabdeabfgabcdefgh", "abc", true);
            Console.ReadLine();
        }
    }
}
