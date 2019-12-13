using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4
{
    class Sorting<T>
    {
        public delegate void Message();

        public static event Message onCompare;

        public static event Action onCompareString;

        //4.1
        //public static void CustomSort(T[] array, Comparison<T> comparison)
        //{
        //    T temp;
        //    bool sorted = false;

        //    while (!sorted)
        //    {
        //        sorted = true;

        //        for (int i = 0; i < array.Length - 1; i++)
        //        {
        //            if (comparison(array[i], array[i + 1]) > 0)
        //            {
        //                temp = array[i];
        //                array[i] = array[i + 1];
        //                array[i + 1] = temp;
        //                sorted = false;
        //            }
        //        }
        //    }

        //    onCompare?.Invoke();
        //}

        //Overloading for 4.2
        public static void CustomSort(T[] array, Func<T, T, int> comparison)
        {
            T temp;
            bool sorted = false;

            onCompare += SortingHandler.PrintFinish;

            while (!sorted)
            {
                sorted = true;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (comparison(array[i], array[i + 1]) > 0)
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        sorted = false;
                    }
                }
            }

            onCompare?.Invoke();

            onCompare -= SortingHandler.PrintFinish;
        }

        //public static void SortInThread(T[]array, Comparison<T> comparison)
        //{
        //   new Thread( () =>
        //   {
        //       CustomSort(array, comparison);

        //       foreach (var item in array)
        //       {
        //           Console.WriteLine(item);
        //       }
        //   }
        //    ).Start();           
        //}

        public static void SortInThread(T[] array, Func<T, T, int> comparison)
        {
            new Thread(() =>
            {
                CustomSort(array, comparison);

                foreach (var item in array)
                {
                    Console.WriteLine(item);
                }
            }
             ).Start();
        }

        public static void SortingString(string[] array, Func<string, string, int> SortingFunction)
        {
            onCompareString += SortingHandler.PrintFinish;

            Sorting<string>.CustomSort(array, SortingFunction);

            onCompareString -= SortingHandler.PrintFinish;
        }
    }
}
