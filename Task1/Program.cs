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
            XMasTree();
            //SumOfNumbers();

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

            if (Int32.TryParse(Console.ReadLine(), out int N))
            {
                PrintTipOfTree(N);

                for (int i = 3; i <= N+1; ++i)
                {
                    PrintBodyOfTree(i);
                }

            }
            else Console.WriteLine("Некорректные данные");
        }

        static void PrintTipOfTree(int N) //нужно сдвинуть
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

        public static void PrintBodyOfTree(int N) //перед тем как писать * делать отступы. Всегда в начале писать N пробелов, потом каждый раз на 1 меньше
        {
            int count1 = 1;
            int count3 = 1;
            //int NumberOfSpaces = N;
            int count = 0;

            for (int i = 1; i <= N; i++)
            {
                for (int j = N - i + count3; j >= -1; j--)
                {
                    Console.Write(' ');
                }

                for (int k = 1; k <= count1; k++)
                {
                    Console.Write('*');
                }

                //count3--;
                count1 += 2;
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

        }

    }


}
