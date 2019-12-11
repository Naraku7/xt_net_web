using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class SortingHandler
    {
        public static int Compare<T>(T x, T y) where T : IComparable
        {
            if (x == null || y == null) return -1;

            return x.CompareTo(y);
        }

        //4.2
        public static int CompareString(string s1, string s2)
            => s1.Length > s2.Length ? 1 : s1.Length == s2.Length ? string.Compare(s1, s2, true) : -1;

        //No arrow function version is below

        //{
        //    if (s1.Length > s2.Length) return 1;
        //    else if(s1.Length == s2.Length) return string.Compare(s1, s2, true);           

        //    return -1;
        //}

        public static void PrintFinish() => Console.WriteLine("Sorting is finished");
    }
}
