using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.GameTask;
using Task2.GameTask.Bonuses;
using Task2.GameTask.Monsters;
using Task2.GameTask.Obstacles;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString s = new MyString("It's a test");
            MyString m = new MyString("It's a test too");
            Console.WriteLine(s.IndexOf('s'));
            //Console.WriteLine(s+m);

            Console.ReadKey();
        }
    }
}
