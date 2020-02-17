using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Triangle
    {
        public double A { get; }
        public double B { get; } 
        public double C { get; }   
        double P  => 0.5 * Perimeter;  //полупериметр из формулы Герона
        public double Perimeter => A + B + C;
        public double Square => Math.Sqrt(P * (P - A) * (P - B) * (P - C)); 

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) 
                throw new ArgumentException("Triangle side cannot equal to or less than zero");
            if(a + b >= c || b + c >= a || c + a >= b)
                throw new ArgumentException("The sum of two triangle sides cannot equal to or greater than the third side");
            this.A = a;
            this.B = b;
            this.C = c;
        }
        
        public Triangle() { }
    }
}
