using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.GameTask.Obstacles
{
    class Rock : Obstacle
    {
        public string Material { get; }

        public Rock(double height, double width, string material)
        {
            if (height <= 0 || width <= 0)
                throw new ArgumentException("Non-correct parameteres");

            Height = height;
            Width = width;
            Material = material;
        }
    }
}
