using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSortings
{
    public static class MergeSort
    {
        public static void Sort(List<int> arr)
        {
            if(arr.Count <= 1)
                return;
            var middle = arr.Count / 2;
            var left = new List<int>();
            var right = new List<int>();
            for(int i = 0; i < arr.Count; i++)
            {
                if(i < middle)
                    left.Add(arr[i]);
                else
                    right.Add(arr[i]);
            }
            Sort(left);
            Sort(right);
            var res = MergeFunc(left, right);
            for(int i = 0; i < arr.Count; i++)
                arr[i] = res[i];

        }


        private static List<int> MergeFunc(List<int> a, List<int> b)
        {
            var result = new List<int>();

            var apos = 0;
            var bpos = 0;
            //var resultPos = 0;
            while(apos < a.Count && bpos < b.Count)
            {
                if(a[apos] <= b[bpos])
                {
                    result.Add(a[apos]);
                    apos++;
                }
                else
                {
                    result.Add(b[bpos]);
                    bpos++;
                }
                //resultPos++;
            }
            while(apos < a.Count)
            {
                result.Add(a[apos]);
                apos++;
                //resultPos++;
            }
            while(bpos < b.Count)
            {
                result.Add(b[bpos]);
                bpos++;
                //resultPos++;
            }
            return result;
        }
    }
}
