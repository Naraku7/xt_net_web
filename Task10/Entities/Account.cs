using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task10.Models
{
    public class Account
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }

        public Account(string name, string password)
        {
            Name = name;
            Password = password;
            Roles = new List<string>();
            Roles.Add("User");
        }
    }
}