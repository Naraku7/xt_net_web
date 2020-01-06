using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public abstract class Figure
    {
        public virtual Point Center { get; set; } //дабы было какое-то общее свойство, добавил сюда Center
    }
}
