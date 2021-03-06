﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Entities
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Award(string title)
        {     
            Title = title;
        }
        public Award() { }

        public override string ToString()
        {
            return $"Title of the award: {Title}, ID of the award: {Id}";
        }
    }
}
