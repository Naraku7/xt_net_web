using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 0, 5, 10, 25, 44, 2, 6, 11, 89, 10002, 54, -2, 0, 5, 6, 26 };
            int[] arr2 = new int[] { 1, 2, 3 };

            Console.WriteLine(arr2.NumberArraySum());

            //CustomSort<int>(arr, Compare<int>);

            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}

           

            //string[] animals = new string[] { "deer", "zebra", "mouse", "boar", "dog", "cat", "elephant" };

            //CustomSort<string>(animals, CompareString);

            //foreach (var item in animals)
            //{
            //    Console.WriteLine(item);
            //}

            Console.ReadLine();
        }

        #region
        //4.1

        public static void CustomSort<T>(T[] array, Comparison<T> comparison)
        {
            T temp;
            bool sorted = false;

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
        }

        public static int Compare<T>(T x, T y) where T : IComparable
        {
            if (x == null || y == null) return -1;

            return x.CompareTo(y);
        }
        #endregion


        #region
        //4.2
        public static int CompareString(string s1, string s2) 
            => s1.Length > s2.Length ? 1 : s1.Length == s2.Length ? string.Compare(s1, s2, true) : -1;

        //No arrow function version is below

        //{
        //    if (s1.Length > s2.Length) return 1;
        //    else if(s1.Length == s2.Length) return string.Compare(s1, s2, true);           

        //    return -1;
        //}

        #endregion
  
    }

    #region
    //4.4

    public static class NumberArrayExtension
    {
        public static int NumberArraySum(this int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

    }

    #endregion
}
