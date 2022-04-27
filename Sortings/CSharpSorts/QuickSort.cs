using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class QuickSort
    {
        public static void Sort(List<int> arr)
        {
            if(arr.Count <= 1)
                return;
            var left = new List<int>();
            var right = new List<int>();
            var eq = new List<int>();
            var barrier = arr[arr.Count / 2];
            for(int i = 0; i < arr.Count; i++)
            {
                if(arr[i] == barrier)
                    eq.Add(arr[i]);
                else if(arr[i] < barrier)
                    left.Add(arr[i]);
                else
                    right.Add(arr[i]);
            }
            Sort(left);
            Sort(right);
            left.AddRange(eq);
            left.AddRange(right);

            for(int i = 0; i < arr.Count; i++)
            {
                arr[i] = left[i];
            }

        }
    }
}
