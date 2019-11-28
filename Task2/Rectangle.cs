using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Rectangle
    {
        public double Height { get; }
        public double Width { get; }
        public double Area => Width * Height;
        public double Perimeter => 2 * Width + 2 * Height;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public Rectangle() { }
    }
}
