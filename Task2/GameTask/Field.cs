using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.GameTask.Bonuses;
using Task2.GameTask.Obstacles;
using Task2.GameTask.Monsters;

namespace Task2.GameTask
{
    class Field
    {
        public double Height { get; }
        public double Width { get; }
        public Bonus[] Bonuses { get; }
        public Monster[] Monsters { get; }
        public Obstacle[] Obstacles { get; }

        public Field(double height, double width, Bonus[] bonuses, Monster[] monsters, Obstacle[] obstacles)
        {
            Height = height;
            Width = width;
            Bonuses = bonuses;
            Monsters = monsters;
            Obstacles = obstacles;
        }

        public Field()
        {
            Height = 10000;
            Width = 10000;
        }
    }
}
