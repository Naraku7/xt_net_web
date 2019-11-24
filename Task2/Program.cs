using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round(new Point(1, 2, 3), 4);

            Console.WriteLine("Area " + round.Area);
            Console.WriteLine("Curcuit "+ round.Circuit);

            User user = new User("Eugene", "Alekseevich", "Zheltov", new DateTime(1997, 11, 04));
            Console.WriteLine(user.Age);

            Employee emp = new Employee("Eugene", "Alekseevich", "Zheltov", new DateTime(1997, 11, 04), 2, "Developer");
            Console.WriteLine(emp.Post);
            
            Console.ReadKey();
        }
    }
}
