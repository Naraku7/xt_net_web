using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
            Console.WriteLine(PrintSequence(4));
            Console.WriteLine(PrintSequence(7));

            Console.WriteLine(IsSimple(12));
            Console.WriteLine(IsSimple(7));
            Console.WriteLine(IsSimple(1));
            Console.WriteLine(IsSimple(2));
            Console.WriteLine(IsSimple(6));

            PrintSquare(7);
            **/

            ArrayFun();

            Console.ReadLine();
        }

        public static string PrintSequence(int N)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= N; i++)
            {
                result.Append(i).Append(", ");
            }

            result.Remove(3*N - 2, 2);

            return result.ToString();
        }

        public static bool IsSimple(int N)
        {

            if (N <= 0) throw new ArgumentOutOfRangeException();

            for (int i = 2; i < N; i++)
            {
                if (N % i == 0) return false;
            }

            return true;
        }

        public static void PrintSquare(int N)
        {
            if (N < 0 || N % 2 == 0) throw new ArgumentOutOfRangeException();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == (N) / 2 && j == (N) / 2) { Console.Write(' '); }
                    else Console.Write('*');
                }
                Console.Write("\n");
            }
        }

        public static void ArrayFun()
        {
            Console.WriteLine("Введите размерность массива: ");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите размерности подмассивов: ");
            int[] elements = new int[N];

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Размер подмассива номер {i+1}:");
                elements[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[][] Array = new int[N][];
            int[] AllElements;
            int amountOfElements = 0;
            

            //Initialize each element of dArray
            for (int i = 0; i < N; i++)
            {
                Array[i] = new int[elements[i]];
            }

            //Assign each element of Array[i] for every i with a random integer number from 0 to 100
            AssignRandom(Array);


            Console.WriteLine("Вывести неотсортированный массив: ");

            //Print an unsorted array
            PrintArray(Array);

            //Count amountOfElements
            amountOfElements = CountElements(Array);

            //Create AllElements, where we store all elements
            AllElements = new int[amountOfElements];

            int count = 0;

            //Put all elements to AllElements
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < Array[i].Length; j++)
                {
                        AllElements[count] = Array[i][j];
                        count++;
                }
            }

            //Sort AllElements, where we store all elements
            int[] sortedAllElements = BubbleSort(AllElements);
            

            //Put elements from sortedAllElements to Array
            PutElementsFrom1Dto2DArray(Array, sortedAllElements);

            Console.WriteLine("Вывести отсортированный массив: ");

            //Print a sorted array
            PrintArray(Array);

            //New array, where subarrs will be sorted by length
            int[][] sorteByLensArray = new int[N][];
            //Here we store lengths of subarrays
            int[] lensOfSubarrs = new int[N];

            //Assign elements of lensOfSubarrs
            for (int i = 0; i < N; i++)
            {
                lensOfSubarrs[i] = elements[i];
            }

            //Sort lensOfSubarrs
            int[] sortedlensOfSubarrs = BubbleSort(lensOfSubarrs);

            //Assign sorteByLensArray
            for (int i = 0; i < Array.Length; i++)
            {
                sorteByLensArray[i] = new int[sortedlensOfSubarrs[i]];
            }

            //Put elements from sortedAllElements to sorteByLensArray
            PutElementsFrom1Dto2DArray(sorteByLensArray, sortedAllElements);

            

            Console.WriteLine("Вывести отсортированный массив, где подмассивы отсортированы по длине: ");
            PrintArray(sorteByLensArray);

        }

        public static void PutElementsFrom1Dto2DArray(int[][] TwoDarray, int[] OneDarray)
        {
            int count = 0;

            for (int i = 0; i < TwoDarray.Length; i++)
            {
                for (int j = 0; j < TwoDarray[i].Length; j++)
                {
                    TwoDarray[i][j] = OneDarray[count];
                    count++;
                }
            }
        }



        public static void AssignRandom(int[][] array)
        {
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rand.Next(0, 100);
                }
            }
        }

        public static int CountElements(int[][] array)
        {
            int amountOfElements = 0;
            for (int i = 0; i < array.Length; i++)
            {
                amountOfElements += array[i].Length;
            }

            return amountOfElements;
        }

        //This method sorts an array
        public static int[] BubbleSort(int[] array)
        {
            bool sorted = false;
            int temp;

            while (!sorted)
            {
                sorted = true;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if(array[i] > array[i + 1]) //indexoutofbound
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        sorted = false;
                    }
                }
            }

            return array;
        }
        

        //This method prints an array
        public static void PrintArray(int[][] array) //вывод поправить
        {
            Console.Write("{");

            foreach (int[] i in array)
            {
                Console.Write("{");

                foreach (int j in i)
                {
                    Console.Write(j);
                    Console.Write(", ");
                }
                Console.Write("}");
                Console.Write(", ");
            }
            Console.WriteLine("}");
        }
    }
}
