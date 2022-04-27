using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDynamicProg
{
    public static class Subsequences
    {
        public static List<int> SubstringKMP(string source, string substring, bool useZFunc = false)
        {
            var testString = String.Format("{0}#{1}", substring, source);
            var len = substring.Length;
            var result = new List<int>();
            if(!useZFunc)
            {
                var pFuncResult = PrefixFunc(testString);
                //Вернем список индексов вхождений первого элемента подстроки

                for(int i = 0; i < source.Length; i++)
                {
                    if(pFuncResult[i + len + 1] == len)
                        result.Add(i - len + 1);
                }
            }
            else
            {
                var zFuncResult = CoolerZFunc(testString);
                for(int i = 0; i < source.Length; i++)
                {
                    if(zFuncResult[i + len + 1] == len)
                        result.Add(i);
                }
            }
            return result;
        }

        private static int[] PrefixFunc(string s)
        {
            var arr = new int[s.Length]; //Массив для результата, инициализирован нулями
            //Нулевой жлемент массива всегда 0, поэтому не нужен дополнительный "левый элемент", как в иных задачах дин прогр
            for(int i = 1; i < s.Length; i++) //Считаем п-функцию для каждого символа строки
            {
                var PPrev = arr[i - 1]; //Рассматриваем п-функцию от строки на 1 меньше
                //В PPrev - длина суффикса=префиксу
                //abcabс
                while(PPrev > 0 && s[PPrev] != s[i]) //Если текущий символ не равен символу за s[PPrev] то надо поискать префикс меньше, внутри PPrev
                {
                    PPrev = arr[PPrev];
                }
                if(s[PPrev] == s[i])
                {
                    arr[i] = arr[i - 1] + 1;
                }

            }
            return arr;
        }

        ///Z-функция (англ. Z-function) от строки S и позиции x — это длина максимального префикса подстроки, начинающейся с позиции x в строке S, который одновременно является и префиксом всей строки S. Более формально, Z[i](s)=maxk∣s[i…i+k]=s[0…k]. Значение Z-функции от первой позиции не определено, поэтому его обычно приравнивают к нулю или к длине строки.
        ///
        public static int[] ZfuncTrivial(string source)
        {
            var Z = new int[source.Length];
            for(int i = 1; i < source.Length; i++) //Для нулевого элемента функция равна 0
            {
                var currentCounter = 0;
                for(int j = 0; j < source.Length-i; j++)
                {
                    if(source[j] == source[i + j])
                        currentCounter++;
                    else
                    {
                        break;
                    }
                }
                Z[i] = currentCounter;
            }
            return Z;
        }

        public static int[] CoolerZFunc(string source)
        {
            //Z-блоком назовем подстроку с началом в позиции i и длиной Z[i].
            //Для работы алгоритма заведём две переменные: left и right — начало и конец Z-блока строки S с максимальной позицией конца right(среди всех таких Z - блоков, если их несколько, выбирается наибольший).Изначально left = 0 и right = 0.
            int left = 0, right = 0;
            var Z = new int[source.Length];
            for(int i = 1; i < source.Length; i++)
            {
                var z0 = 0;
                if(i > right)
                {

                }
                else 
                {
                    z0 = Math.Min(right-i+1, Z[i-left]);
                }
                int j = z0;
                while((i+j)<source.Length && source[j] == source[i + j])
                {
                    j++;
                }
                Z[i] = j;
                if(Z[i] > 0)
                {
                    left = i;
                    right = i + j - 1;
                }
            }
            return Z;
        }
    }
}
