using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.GameTask;

namespace Task2.GameTask.Monsters
{
    abstract class Monster
    {      
        public int Health { get; set; }
        public abstract void Move();
    }
}
