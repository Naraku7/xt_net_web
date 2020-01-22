using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.GameTask.Monsters
{
    class Wolf : Monster
    {
        public override void Move()
        {
            Console.WriteLine("Wolf walking");
        }

        public Wolf(int health)
        {
            if (health <= 0)
                throw new ArgumentException("Monster must be alive when created", "health");
            Health = health;
        }

        public Wolf() { }
    }
}
