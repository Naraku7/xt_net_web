using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> people = new List<int>();

            //AddPeople(10, people);
            //Console.WriteLine("Before removing: ");
            //PrintList(people);
            //RemovePeople(people);


            //WordFrequency("Вот дом, Который построил Джек. " +
            //    "А это пшеница, Которая в тёмном чулане хранится " +
            //    "В доме, Который построил Джек. А это весёлая птица-синица, " +
            //    "Которая часто ворует пшеницу, Которая в тёмном чулане хранится " +
            //    "В доме, Который построил Джек. Вот кот, Который пугает и ловит синицу, " +
            //    "Которая часто ворует пшеницу, Которая в тёмном чулане хранится");


            CycledDynamicArray<int> cycle = new CycledDynamicArray<int>(new int[] { 1, 2, 3, 4, 5});

            foreach (var item in cycle)
            {
                Console.WriteLine(item);
            }
            

            Console.ReadKey();

        }

        #region

        public static void AddPeople(int n, List<int> list)
        {
            if (n <= 0)
                throw new ArgumentException("n must be > 0", "n");

            for (int i = 0; i < n; i++)
            {
                list.Add(i + 1);
            }
        }

        public static void RemovePeople(List<int> list) 
        {
            if (list.Count < 1)
                throw new ArgumentException("List<T> must contain at least two elements");

            int Count = 0;

            while (list.Count != 1)
            {
                int pos = 0;

                for (int i = 0; i < list.Count; i += 2, pos++)
                {
                    list[pos] = list[i];
                }

                list.RemoveRange(pos, list.Count - pos);

                Count++;

                Console.WriteLine("After {0} removing: ", Count);
                PrintList(list);
            }    
        }

        public static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region 
        public static void WordFrequency(string text)
        {           
            string[] words = text.ToLower().Split(' ', '.');

            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                int Count = 0;

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[i] == words[j]) Count++;
                }
            
                if(!dict.ContainsKey(words[i])) //проверяем, не находили ли это слово ранее
                    dict.Add(words[i], Count);
            }

            PrintDictionary<string, int>(dict);
        }

        public static void PrintDictionary<T, K>(Dictionary<T, K> dict)
        {
            foreach (KeyValuePair<T, K> el in dict)
            {
                Console.WriteLine("Word = {0}, Frequency = {1}", el.Key, el.Value);             
            }
        }

        #endregion
    }
}
