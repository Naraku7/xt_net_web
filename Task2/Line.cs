using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Line
    {
        public double Length => Math.Sqrt((Point2.X - Point1.X)*(Point2.X - Point1.X) - (Point2.Y - Point1.Y) * (Point2.Y - Point1.Y));

        public Point Point1 { get; }
        public Point Point2 { get;  }

        public Line(Point point1, Point point2)
        {
            if (point1.X == point2.X && point1.Y == point2.Y)
                throw new ArgumentException("You cannot have two same points");

            Point1 = point1;
            Point2 = point2;
        }

        public Line() { }
    }
}
