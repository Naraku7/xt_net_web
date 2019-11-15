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

            //StringBuilder square = new StringBuilder();


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

            foreach (int el in elements)
            {
                elements[el] = Convert.ToInt32(Console.ReadLine());
            }

            int[][] unsortedArray = new int[N][];
            int[][] sortedArr = new int [N][];
            int[] tempArr;
            int amountOfElements = N;
            Random rand = new Random();

            /**
            //Initialize each element of unsortedArray
            foreach(int el in elements)
            {
                unsortedArray[el] = new int[elements[el]]; //indexoutofbound
            }
            **/

            for (int i = 0; i < N; i++)
            {
                unsortedArray[i] = new int[elements[i]];
            }

            //Assign each element of unsortedArray[i] for every i with a random integer number from 0 to 100
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < unsortedArray[i].Length; j++)
                {
                    unsortedArray[i][j] = rand.Next(0, 100);
                }
            }

            //Put every element in tempArr
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < unsortedArray[i].Length; j++) 
                {
                    amountOfElements += unsortedArray[i][j];
                }
            }

            //Create tempArr, where we store all elements
            tempArr = new int[amountOfElements];

           

            //Create an array, where we store lenghths of subarrays of our array we got as a parameter
            int[] unsortedLensOfArray = new int[N];

            //Assign unsortedLensOfArray
            for (int i = 0; i < N; i++)
            {
                unsortedLensOfArray[i] = unsortedArray[i].Length;
            }


            //Print an unsorted array
            foreach (int[] el in unsortedArray)
            {
                PrintArray(el);
            }

            //Sort tempArr, where we store all elements
            int[] sortedTempArr = BubbleSort(tempArr);

            //Sort an array, where we store lenghths of subarrays of our array we got as a parameter
            int[] sortedLensOfArray = BubbleSort(unsortedLensOfArray);

            //newArr is a new array, where subarrays are placed in order of their lenghts
            int[][] newArr = new int[N][];
            

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    newArr[i] = new int[sortedLensOfArray[j]];
                }
            }

            int count = 0;

            //Put elements from sortedTempArr to subarrays of newArr
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = count; k < amountOfElements; k++)
                    {
                        newArr[i][j] = sortedTempArr[k];
                        count = k;
                    }
                }
            }

            //Print a newArr
            foreach (int[] el in newArr)
            {
                PrintArray(el);
            }


            /**
            //Sort an unsorted array
            for (int i = 0; i < unsortedArray.Length; i++)
            {
                sortedArr[i] = BubbleSort(unsortedArray[i]);
            }
            **/

            /**
            //Print a sorted array
            foreach (int[] el in sortedArr)
            {
                PrintArray(el);
            }
            **/

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
        public static void PrintArray(int[] array) //вывод поправить
        {
            Console.WriteLine();
            StringBuilder sb = new StringBuilder("<");

            foreach (int el in array)
            {
                sb.Append(el).Append(", ");
            }
            //sb.Remove(sb.Length - 2, 2).Append('>'); // System.ArgumentOutOfRangeException
            sb.Append('>');
            Console.WriteLine(sb);
        }
    }
}
