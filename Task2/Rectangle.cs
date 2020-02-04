using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Rectangle : Figure
    {
        public double Height { get; }
        public double Width { get; }
        public double Area => Width * Height;
        public double Perimeter => 2 * Width + 2 * Height;
        public override Point Center { get => new Point(Width/2, Height/2); set => base.Center = value; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public Rectangle() { }
    }
}
