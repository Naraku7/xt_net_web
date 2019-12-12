using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            //4.1, 4.4
            #region
            //int[] arr = new int[] { 0, 5, 10, 25, 44, 2, 6, 11, 89, 10002, 54, -2, 0, 5, 6, 26 };
            //int[] arr2 = new int[] { 1, 2, 3 };

            //SortingHandler sortingHandler = new SortingHandler();
            //Sorting<string> sortingString = new Sorting<string>();
            //Sorting<int> sortingInt = new Sorting<int>();

            //Sorting<int>.onCompare += SortingHandler.PrintFinish;

            //4.4
            //Console.WriteLine(arr2.NumberArraySum());

            //sortingInt.CustomSort(arr, SortingHandler.Compare<int>);

            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion


            //4.2
            #region
            //string[] animals = new string[] { "deer", "zebra", "mouse", "boar", "dog", "cat", "elephant" };

            //Sorting<string>.onCompare += SortingHandler.PrintFinish;

            //Sorting<string>.CustomSort(animals, SortingHandler.CompareString);

            //Sorting<string>.onCompare -= SortingHandler.PrintFinish;



            //foreach (var item in animals)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region
            //int[] arr = new int[] { 0, 5, 10, 25, 44, 2, 6, 11, 89, 10002, 54, -2, 0, 5, 6, 26 };
            //Sorting<int>.SortInThread(arr, SortingHandler.Compare<int>);
            #endregion

            //4.5
            #region
            string test = "54";
            Console.WriteLine(test.IsStringIntPositive());
            #endregion

            //4.6
            #region
            Random rnd = new Random();
            int[] intArray = new int[600];

            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = rnd.Next(-100, 100);
            }

            

            Stopwatch stopWatch = new Stopwatch();

            //1. метода, непосредственно реализующего поиск;
            stopWatch.Start();
            for (int i = 0; i < intArray.Length; i++)
            {
                Searching.SearchPositive(intArray[i]);
            }
            TimeSpan ts = stopWatch.Elapsed;

            #endregion


            Console.ReadLine();
        }


    }

    //4.4
    #region

    public static class NumberArrayExtension
    {
        public static int NumberArraySum(this int[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "Your array cannot be empty or null");

            int sum = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

    }

    #endregion

    //4.5
    #region
    public static class StringExtension
    {
        public static bool IsStringIntPositive(this string s) => s.All(char.IsDigit);        
    }
    #endregion
}
