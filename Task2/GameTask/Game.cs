using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.GameTask.Bonuses;
using Task2.GameTask.Monsters;

namespace Task2.GameTask
{
    class Game
    {
        public Field Field { get; }
        
        public Character Character { get; }
        public bool Win { get; set; } = false;

        public Game(Field field, Character character)
        {
            Field = field;         
            Character = character;
        }
        public Game() { }
       
        public void Play()
        {
            if (Character.Alive && Character.AllLooted) Console.WriteLine("You win");
            else Console.WriteLine("You lost");
        }
    }
}
