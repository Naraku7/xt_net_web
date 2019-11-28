﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class GraphicsEditor
    {
        //public static Ring CreateFigure(Point center, double innerRadius, double outerRadius)
        //{
        //    return new Ring(center, innerRadius, outerRadius);
        //}

        public static void PrintFigure(Ring ring)
        {
            Console.WriteLine("Type of the object: " + ring.GetType());
            Console.WriteLine("Center of the ring: (" + ring.Center.X + ", " + ring.Center.Y + ")");
            //Console.WriteLine("Inner Radius of the ring: " + ring.InnerCircle.Radius);
            //Console.WriteLine("Outer Radius of the ring: " + ring.OuterCircle.Radius);
            Console.WriteLine("Inner Radius of the ring: " + ring.InnerRadius);
            Console.WriteLine("Outer Radius of the ring: " + ring.OuterRadius);
            Console.WriteLine("Area of the ring: " + ring.Area);
            Console.WriteLine("Sum of circuits of the ring: " + ring.SumOfCircuits);
        }

        public static Circle CreateFigure(Point center, double radius)
        {
            return new Circle(center, radius);
        }

        public static void PrintFigure(Circle circle)
        {
            Console.WriteLine("Type of the object: " + circle.GetType());
            Console.WriteLine("Center of the circle: (" + circle.Center.X + ", " + circle.Center.Y + ")");
            Console.WriteLine("Radius of the circle: " + circle.Radius);
            Console.WriteLine("Curcuit of the circle: " + circle.Circuit);
        }

        //public static Round CreateFigure(Point center, double radius) //набор параметров тот же
        //{
        //    return new Round(center, radius);
        //}

        public static void PrintFigure(Round round)
        {
            Console.WriteLine("Type of the object: " + round.GetType());
            Console.WriteLine("Center of the round: (" + round.Center.X + ", " + round.Center.Y + ")");
            Console.WriteLine("Radius of the round: " + round.Radius);      
            Console.WriteLine("Area of the round: " + round.Area);
        }

        public static Line CreateFigure(Point point1, Point point2)
        {
            return new Line(point1, point2);
        }

        public static void PrintFigure(Line line)
        {
            Console.WriteLine("Type of the object: " + line.GetType());
            Console.WriteLine("The first point of the line: \n" + "X: " + line.Point1.X + "\nY: " + line.Point1.Y);
            Console.WriteLine("The second point of the line: \n" + "X: " + line.Point2.X + "\nY: " + line.Point2.Y);
            Console.WriteLine("The length of the line: " + line.Length);
        }

        public static Rectangle CreateFigure(double length, double width)
        {
            return new Rectangle(length, width);
        }

        public static void PrintFigure(Rectangle rectangle)
        {
            Console.WriteLine("Type of the object: " + rectangle.GetType());
            Console.WriteLine("The height of the rectangle: " + rectangle.Height);
            Console.WriteLine("The width of the rectangle: " + rectangle.Width);
            Console.WriteLine("The perimeter of the rectangle: " + rectangle.Perimeter);
            Console.WriteLine("The area of the rectangle: " + rectangle.Area);
        }

    }
}
