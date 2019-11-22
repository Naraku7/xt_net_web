using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Rectangle(1, 2));
            //Triangle();
            //AnotherTriangle();
            //XMasTree();
            //SumOfNumbers();
            //ArrayProcessing();
            //FontAdjustment();
            //NoPositive();
            //Console.WriteLine(NonNegSum(1, -1, -3, 2, 5, -10));

            //int[][] array = new int[3][];
            //array[0] = new int[2] { 1, 2 };
            //array[1] = new int[3] { 3, 4, 5 };
            //array[2] = new int[4] { 6, 7, 8, 9 };

            //Console.WriteLine(TwoDArray(array));

            Console.WriteLine(AvgStrLength("aaa., aaaa,  aa! "));

            CharDoubler();
            

            Console.ReadKey();
        }


        public static int Rectangle(int a, int b)
        {
            if (a <= 0 || b <= 0) throw new ArgumentException("Введены неправильные данные");

            return a * b;
        }

        public static void Triangle()
        {
            Console.WriteLine("Введите длину катета треугольника: ");

            if (Int32.TryParse(Console.ReadLine(), out int N))
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        Console.Write('*');
                    }
                    Console.Write("\n");
                }
            }
            else Console.WriteLine("Некорректные данные");
        }

        public static void AnotherTriangle()
        {
            int count = 1;
 
            Console.WriteLine("Введите высоту треугольника: ");

            if (Int32.TryParse(Console.ReadLine(), out int N))
            {
                for (int i = 1; i <= N; i++)
                {
                    for (int j = N - i; j > 0; j--)
                    {
                        Console.Write(' ');
                    }

                    for (int k = 1; k <= count; k++)
                    {
                        Console.Write('*');
                    }

                    count += 2;
                    Console.Write("\n");
                }
            }
            else Console.WriteLine("Некорректные данные");
        }

        public static void XMasTree() //первый треугльник - отдельно (отсуп = N), остальные по методу выше, у нижнего треугльника длина будет N+1
        {

            Console.WriteLine("Введите число треугольников: ");


            //Так как верхушка треугольника везде одинакова (меняется только отступ слева), то метод для его вывода вынесен в отдельный метод

            if (Int32.TryParse(Console.ReadLine(), out int N))
            {
                PrintTipOfTree(N);

                for (int i = 3; i <= N+1; ++i)
                {
                    PrintPartOfTree(i, N);
                }

            }
            else Console.WriteLine("Некорректные данные");
        }

        static void PrintTipOfTree(int N)
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write(' ');
            }
            Console.Write('*');
            Console.Write("\n");

            for (int i = 0; i < N; i++)
            {
                Console.Write(' ');
            }
            Console.Write('*');
            Console.Write("\n");

            for (int i = 0; i < N + 2; i++)
            {
                if (i < N - 1) Console.Write(' ');

                else Console.Write('*');
            }
            Console.Write("\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="N">Число треугольников</param>
        /// <param name="S">Число отступов (совпадает с общим числом треугольников)</param>
        /// 
        public static void PrintPartOfTree(int N, int S) 
        {
            int count = 1;

            for (int i = 1; i <= N; i++)
            {
                //S понадобилось, тк число отступов в начале всегда должно быть неизменным
                for (int j = S - i; j >= 0; j--)
                {
                    Console.Write(' ');
                }
 
                for (int k = 1; k <= count; k++)  
                {
                    Console.Write('*');
                }

                //с каждой новой строкой рисуем на 2 звезды больше
                count += 2;

                Console.Write("\n");
            }
        }

        public static void SumOfNumbers()
        {
            int sum = 0;
            int count = 1;
            while (count < 1000)
            {
                if (count % 3 == 0 || count % 5 == 0)
                {
                    sum += count;
                }
                count++;
            }
            Console.WriteLine("Сумма чисел меньше 1000, кратная 3 или 5, равна " + sum);
        }

        public static void FontAdjustment()
        {
            Styles style = Styles.None; // по умолчанию нет шрифтов

            Console.WriteLine($"Параметры надписи: {style}");

            Console.WriteLine($"Введите: \n 1: {Styles.Bold} \n 2: {Styles.Italic} \n 3: {Styles.Underline}");


            //так как численные значения перечисления - степени двойки, то возводим 2 в степень, равную введенному значению
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    style ^= (Styles)Math.Pow(2, (input - 1));  
                    Console.WriteLine($"Параметры надписи: {style}");
                }
                else Console.WriteLine("Некорректные данные");
            }
        }

        [Flags]
        public enum Styles
        {
            None = 0b_0000_0000, // 0,
            Bold = 0b_0000_0001, // 1,
            Italic = 0b_0000_0010, // 2,
            Underline = 0b_0000_0100, // 4
        }

        public static void ArrayProcessing()
        {
            
            int[] arr = new int[10];
            int min, max;

            AssignRandom(arr);

            Console.WriteLine("Неотсортированный массив: ");

            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(' ');
            }
            

            Console.WriteLine();

            //Ищем максимум и минимум в массиве
            max = MaxInArr(arr);
            min = MinInArr(arr);

            Console.WriteLine("Минимум: {0}. Максимум: {1}", min, max);

            BubbleSort(arr);

            Console.WriteLine("Отсортированный массив: ");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(' ');
            }
        }

        public static void AssignRandom(int[] array)
        {
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {  
                    array[i] = rand.Next();
            }
        }

        static int MaxInArr(int[] arr)
        {
            int max = arr[0];

            foreach (int a in arr)
            {
                if (a > max)
                {
                    max = a;
                }
            }
            return max;
        }

        static int MinInArr(int[] arr)
        {
            int min = arr[0];

            foreach (int a in arr)
            {
                if (a < min)
                {
                    min = a;
                }
            }
            return min;
        }

        public static void BubbleSort(int[] array)
        {
            bool sorted = false;
            int temp;

            while (!sorted)
            {
                sorted = true;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1]) //indexoutofbound
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        sorted = false;
                    }
                }
            }
        }

        public static void NoPositive()
        {
            int[][][] arr = new int[5][][];

            //Инициализируем подмассивы
            InitializeSubArrs(arr);

            //Инициализируем элементы случайными числами
            AssignRandom(arr);

            Console.WriteLine("Вывести изначальный массив: ");
            PrintArray(arr);

            //Обнуляем все числа больше нуля
            MakeZero(arr);

            Console.WriteLine("Вывести массив, где все числа > 0 заменены нулями: ");
            PrintArray(arr);
        }

        static void InitializeSubArrs(int[][][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[5][];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = new int[5];
                }
            }
        }

        static void AssignRandom(int[][][] arr)
        {
            Random rand = new Random();

            for(int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    for(int k = 0; k < arr[i][j].Length; k++)
                    {
                        arr[i][j][k] = rand.Next(-50, 50);
                    }
                }
            }
        }

        static void MakeZero(int[][][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    for (int k = 0; k < arr[i][i].Length; k++)
                    {
                        if (arr[i][j][k] > 0) arr[i][j][k] = 0;
                    }
                }
            }
        }

        public static void PrintArray(int[][][] arr)
        {
            Console.Write("{");

            foreach (int[][] i in arr)
            {
                Console.Write("{");

                foreach (int[] j in i)
                {
                    Console.Write(", ");

                    foreach(int k in j)
                    {
                        Console.Write(" " + k);
                    }
                    Console.Write("}");
                    Console.Write(", ");
                }
                Console.Write("}");
                Console.Write(", ");
            }
            Console.WriteLine("}");
        }

        public static int NonNegSum(params int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0) sum += arr[i];
            }

            return sum;
        }

        public static int TwoDArray(int[][] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if ((i + j) % 2 == 0) sum += arr[i][j];
                }
            }
            return sum;
        }

        public static int AvgStrLength(string str) //пока работает немного неверно
        {
            return GetNumOfLetters(str) / GetNumOfWords(str);
        }

        static int GetNumOfLetters(string str)
        {
            int numOfLetters = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLetter(str[i])) numOfLetters++;
            }

            return numOfLetters;
        }

        static int GetNumOfWords(string str)
        {
            int numOfWords = 0;

            //Числа тоже считаются словами, при необходимости могу легко поправить
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsSeparator(str[i]) && !Char.IsWhiteSpace(str[i])) str.Replace(str[i], '\0');
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsWhiteSpace(str[i])) numOfWords++;
            }

            return numOfWords;
        }

        public static void CharDoubler() //не работает, удваивает только последний символ
        {

            Console.WriteLine("Введите первую строку: ");

            string str1 = Console.ReadLine();

            Console.WriteLine("Введите вторую строку: ");

            string str2 = Console.ReadLine();

            char[] chars = str2.ToCharArray();
            

            Console.WriteLine("Результирующая строка: ");

            Console.WriteLine(str1);
        }
    }
}
