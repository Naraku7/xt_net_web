using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Searching
    {
        public static bool SearchPositive(int x)
        {
            return x > 0;
        }

        public static void SearchPosDel(int[] array, Predicate<int> predicate)
        {
            foreach (var item in array)
            {
                if (predicate(item)) Console.WriteLine(item);
            }
        }
    }
}
