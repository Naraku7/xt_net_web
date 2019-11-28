using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Circle
    {
        public Point Center { get; }
        public double Radius { get; }
        public double Circuit => 2 * Math.PI * Radius;
        
        public Circle(Point center, double radius)
        {
            if (radius <= 0) throw new ArgumentException("Radius cannot equal to or less than zero", "radius");

            Center = center;
            Radius = radius;
        }

        public Circle() { }
    }
}

