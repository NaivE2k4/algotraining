using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSortings
{
    public static class QuadraticSortings
    {
        public static void BubbleSort(List<int> arr)
        {
            for(int i = 0; i < arr.Count; i++)
            {
                bool flag = false;
                for(int j = 1; j < arr.Count - i; j++)
                {
                    if(arr[j] < arr[j - 1])
                    {
                        (arr[j], arr[j-1]) = (arr[j-1], arr[j]);
                        flag = true;
                    }
                }
                if(!flag)
                    break;
            }
        }

        public static void InsertSort(List<int> arr)
        {
            int tmp;
            //Считаем что первый элемент отсортирован
            for(int i = 1; i < arr.Count; i++)
            {
                for(int j = i; j > 0; j--) //Идем вдоль строя и смотрим не нужно ли вставить элемент в отсортированную область
                {
                    if(arr[j] < arr[j - 1]) //Если анализируемый предыдущий эелемент больше текущего - меняем местами
                    {
                        tmp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = tmp;
                    }
                    else
                        break;
                }
            }
        }

        public static void ChoiseSort(List<int> arr)
        {
            for(int i = 0; i < arr.Count - 1; i++)
            {
                for(int j = i + 1; j < arr.Count; j++)
                {
                    if(arr[j] < arr[i])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
        }
    }
}
