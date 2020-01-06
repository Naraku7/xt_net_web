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

        public static bool SearchPosDel(int[] array, Predicate<int> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                return predicate(array[i]);
            }
            return true; 
        }
    }
}
