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

            //TimeCounter("В 7:55 я встал, позавтракал и к 10:77 пошёл на работу.");

            //Console.WriteLine(HTMLReplacer("<b>Это</b> текст <i>с</i> <font color=\"red\">HTML</font> кодами"));

            Console.ReadLine();
        }

        public static bool DateExistence(string text) => Regex.IsMatch(text, @"(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[012])-(19|20)\d{2}");

        public static void TimeCounter(string text)
        {
            Regex regex = new Regex(@"([0-9]|[10-24]):([0-60])"); //24:07 и подобное тоже считает

            MatchCollection matches = regex.Matches(text);

            Console.WriteLine($"Время в тексте присутствует {matches.Count} раз.");
        }

        //убирает и все, что между
        public static string HTMLReplacer(string text)
        {
            Regex regex = new Regex(@"((<\s*a[^>]*>)|(<\s*/\s*a>))|((<\s*b>)|(</\s*b>))|((<\s*i>)|(</\s*i>))|((<\s*font[^>]*>)|(<\s*/\s*font>))");

            return regex.Replace(text, "_");
        }
    }
}
