using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.GameTask.Bonuses
{
    class Apple : Bonus
    {
        public override void GetEffect()
        {
            Console.WriteLine("Health restored");
        }
    }
}
