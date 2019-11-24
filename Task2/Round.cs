using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Round
    {
        public Point Center { get; }
        public double Radius { get; }
        public double Circuit { get => 2 * Math.PI * Radius; }
        public double Area { get => Math.PI * Radius * Radius; }


        public Round(Point center, double radius)
        {
            if (radius <= 0) throw new ArgumentException("Радиус не может быть нулевым и отрицательным");

            Center = center;
            Radius = radius; 
        }

        public Round() { }
    }

    
}
