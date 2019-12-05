using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessoneTwoExample
{
    class Program
    {
        public delegate double MathFunction(double n1, double n2);

        static void Main(string[] args)
        {
            MathFunction func =  new MathFunction(Multiply);

            DoSome(func);

            func(3, 5);

            func.Invoke(3,5);

            Console.ReadLine();
        }

        static double Multiply(double n1, double n2) => n1 * n2;

        static void DoSome(MathFunction function)
        {
            var res = 0.0;
            if(function != null)
            //res = function(3, 5);
            res = function.Invoke(3, 5);

            Console.WriteLine(res);
        }
    }

    public class Calculator
    {


        public Calculator()
        {

        }
    }
}
