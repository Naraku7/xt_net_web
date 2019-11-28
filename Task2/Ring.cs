using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //По какой-то причине у меня не получилось агрегировать в Ring два объекта Circle. 
    //В методе PrintFigure() выдавало нули, если писал, например, InnerCircle.Radius

    public class Ring : Circle
    {  
        //public Circle InnerCircle { get; }
       // public Circle OuterCircle { get; }
        public new Point Center { get; }
        //public double Area => Math.PI * (OuterCircle.Radius * OuterCircle.Radius - InnerCircle.Radius * InnerCircle.Radius);
        //public double SumOfCircuits => OuterCircle.Circuit + InnerCircle.Circuit;

        public double Area => Math.PI * (OuterRadius * OuterRadius - InnerRadius * InnerRadius);
        public double SumOfCircuits => 2 * Math.PI * OuterRadius + 2 * Math.PI * InnerRadius;

        public double InnerRadius { get; set; }
        public double OuterRadius { get; set; }

        public Ring(Point center, double innerRadius, double outerRadius)
        {
            if (innerRadius >= outerRadius) 
                throw new ArgumentException("Inner radius cannot equal to or greater than outer radius", "innerRadius");
            if (innerRadius <= 0) 
                throw new ArgumentException("Radius cannot equal to or less than zero", "innerRadius");
            if (outerRadius <= 0)
                throw new ArgumentException("Radius cannot equal to or less than zero", "outerRadius");

            //InnerCircle = new Round(center, innerRadius);
            //OuterCircle = new Round(center, outerRadius);
            InnerRadius = innerRadius;
            OuterRadius = outerRadius;
            Center = center;

        }

        public Ring() { }
    }
}
