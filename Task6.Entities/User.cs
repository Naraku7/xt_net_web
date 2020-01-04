﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public List<Award> awards;

        //if we delete one award, id will be counted further
        public int CommonAmountOfAwards = 0;

        public User(string name, DateTime birthdate)
        {
            Name = name;
            DateOfBirth = birthdate;

            Age = DateTime.Today.Year - birthdate.Year;
            // Go back to the year the person was born in case of a leap year
            if (birthdate.Date > DateTime.Today.AddYears(-Age)) Age--;
        }

        public User() { }

        public override string ToString()
        {
            return $"Id: {Id}, name: {Name}, date of birth: {DateOfBirth.ToString("MM:dd:yyyy")}, age: {Age}";
        }
    }
}
