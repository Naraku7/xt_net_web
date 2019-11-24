using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Triangle
    {
        double a, b, c;
        double P { get => 0.5 * (a + b + c); } //полупериметр из формулы Герона
        public double Perimeter { get => a + b + c; } 
        public double Square { get => Math.Sqrt(P * (P - a) * (P - b) * (P - c)); }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) 
                throw new ArgumentException("Сторона треугольника не можеть быть меньше нуля или равна ему");
            this.a = a;
            this.b = b;
            this.c = c;
        }
        
        public Triangle() { }
    }
}
