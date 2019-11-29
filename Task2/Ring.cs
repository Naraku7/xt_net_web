using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //По какой-то причине у меня не получилось агрегировать в Ring два объекта Circle. 
    //В методе PrintFigure() выдавало нули, если писал, например, InnerCircle.Radius

    public class Ring : RoundFigure
    {
        public Circle InnerCircle { get; }
        public Circle OuterCircle { get; }      
        public double Area => Math.PI * (OuterCircle.Radius * OuterCircle.Radius - InnerCircle.Radius * InnerCircle.Radius);
        public double SumOfCircuits => OuterCircle.Circuit + InnerCircle.Circuit;



        public Ring(Point center, double innerRadius, double outerRadius)
        {
            if (innerRadius >= outerRadius) 
                throw new ArgumentException("Inner radius cannot equal to or greater than outer radius", "innerRadius");
            if (innerRadius <= 0) 
                throw new ArgumentException("Radius cannot equal to or less than zero", "innerRadius");
            if (outerRadius <= 0)
                throw new ArgumentException("Radius cannot equal to or less than zero", "outerRadius");

            InnerCircle = new Circle(center, innerRadius);
            OuterCircle = new Circle(center, outerRadius);
            Radius = outerRadius; //добавил это, чтобы при приведении к RoundFigure внешний радиус был радиусом экземпляра RoundFigure
            Center = center;
        }

        public Ring() { }
    }
}
