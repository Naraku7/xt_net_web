using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DateExistence("2016 год наступит 01-12-2020"));

            TimeCounter("В 7:55 я встал, позавтракал и к 77:00 пошёл на работу.");

            //Console.WriteLine(HTMLReplacer("<b>Это</b> текст <i>с</i> <font color=\"red\">HTML</font> кодами"));

            //NumberValidator(); 

            //EmailFinder();

            Console.ReadLine();
        }

        public static bool DateExistence(string text) => Regex.IsMatch(text, @"(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[012])-(19|20)\d{2}");

        public static void TimeCounter(string text)
        {
            Regex regex = new Regex(@"(\D[0-9]:[0-5][0-9])|(\D[1][0-9]:[0-5][0-9])|(\D[2][0-3]:[0-5][0-9])");

            MatchCollection matches = regex.Matches(text);

            Console.WriteLine($"Время в тексте присутствует {matches.Count} раз.");
        }

        
        public static string HTMLReplacer(string text)
        {    
            Regex regex = new Regex(@"(<\s*[^>]*>)|(<\s*/\s*>)");

            return regex.Replace(text, "_");
        }

        public static void NumberValidator()
        {
            while (true)
            {
                Console.WriteLine("Введите число: ");

                string text = Console.ReadLine();

                if (Regex.IsMatch(text, @"\d"))
                {
                    if (Regex.IsMatch(text, "[^0-9]"))
                    {
                        if (Regex.IsMatch(text, "[^e\\-0-9\\.]"))
                        {
                            Console.WriteLine("Это не число");
                        }
                        else if (Regex.IsMatch(text, "e"))
                        {
                            Console.WriteLine("Это число в научной нотации");
                        }
                        else
                        {
                            Console.WriteLine("Это число в обычной нотации");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Это число в обычной нотации");
                    }
                }
                else
                {
                    Console.WriteLine("Это не число");
                }
            }

        }

        public static void EmailFinder()
        {
            while (true)
            {
                Console.WriteLine("Введите строку: ");

                string text = Console.ReadLine();

                Regex regex = new Regex(@"(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))");

                Console.WriteLine("Найденные адреса электронной почты:");

                MatchCollection matches = regex.Matches(text);

                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
