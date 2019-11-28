using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Employee : User
    {
        public int LengthOfService { get; }
        public string Post { get; }

        public Employee(string firstName, string secondName, string surname, DateTime birthDate, int lengthOfService, string post)
            : base (firstName, secondName, surname, birthDate)
        {
            if (lengthOfService < 0) 
                throw new ArgumentException("Length of service cannot be negative", "lengthOfService");

            LengthOfService = lengthOfService;
            Post = post;
        }
        public Employee() { }
    }
}
