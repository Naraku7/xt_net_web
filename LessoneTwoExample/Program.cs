using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessoneTwoExample
{


    class Program
    {
        
        static void Main(string[] args)
        {
            Account acc = new Account(100);
            acc.Notify += DisplayMessage;
            acc.Notify -= DisplayMessage;
            acc.Notify += new Account.AccountHandler(DisplayMessage);

            

            acc.Notify += mes => Console.WriteLine(mes); 

            Console.ReadKey();
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }


    }

    class Account 
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;

        public Account(int sum)
        {
            Sum = sum;
        }
        // сумма на счете
        public int Sum { get; private set; }
        // добавление средств на счет
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"На счет поступило: {sum}");
        }
        // списание средств со счета
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счета снято: {sum}");
            }
            else
            {
                Notify?.Invoke($"Недостаточно денег на счете.Текущий баланс: { Sum }");
            }
        }
    }


}
