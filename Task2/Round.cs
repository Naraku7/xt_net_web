using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Round : RoundFigure
    {     
        public double Area => Math.PI * Radius * Radius; 


        public Round(Point center, double radius)
        {
            if (radius <= 0) throw new ArgumentException("Radius cannot equal to or less than zero", "radius");

            Center = center;
            Radius = radius; 
        }

        public Round() { }
    } 
}
