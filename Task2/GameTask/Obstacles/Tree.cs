using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.GameTask.Obstacles
{
    class Tree : Obstacle
    {
        public string SpeciesOfTree { get; }

        public Tree(double height, double width, string speciesOfTree)
        {
            if (height <= 0 || width <= 0)
                throw new ArgumentException("Non-correct parameteres");

            Height = height;
            Width = width;
            SpeciesOfTree = speciesOfTree;
        }
    }
}
