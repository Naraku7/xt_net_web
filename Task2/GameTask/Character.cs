using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.GameTask.Bonuses;

namespace Task2.GameTask
{
    class Character
    {
        public string Name { get; }
        public int Health { get; }
        public int Mana { get; }
        public Bonus[] LootedBonuses { get; set; }
        public bool Alive { get; set; } = true;
        public bool AllLooted { get; set; } = false;

        public Character(string name, int health, int mana, Bonus[] loot)
        {
            if (health <= 0)
                throw new ArgumentException("Character must be alive when created", "health");
            if (mana < 0)
                throw new ArgumentException("Character cannot have less than 0 mana", "mana");

            if (health > 100)
                throw new ArgumentException("100 hp max", "health");
            if (mana > 100)
                throw new ArgumentException("100 mp max", "mana");

            Name = name;
            Health = health;
            Mana = mana;
        }
        public Character()
        {
            Health = 100;
            Mana = 100;
        }

        public void Move()
        {
            Console.WriteLine("Character is going somewhere");
        }
    }
}
