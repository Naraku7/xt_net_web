using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class User
    {
        public string FirstName { get; }
        public string SecondName { get; }
        public string Surname { get; }
        public DateTime BirthDate { get; }
        public int Age { get; }

        public User(string firstName, string secondName, string surname, DateTime birthDate) 
        {
            FirstName = firstName;
            SecondName = secondName;
            Surname = surname;
            BirthDate = birthDate;
            Age = DateTime.Today.Year - birthDate.Year;
            //На случай, если пользователь родился в високосный год
            if (birthDate.Date > DateTime.Today.AddYears(-Age)) Age--;
        }

        public User() { }
    }
}
