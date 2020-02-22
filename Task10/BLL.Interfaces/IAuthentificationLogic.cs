using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    public interface IAuthentificationLogic
    {
        bool CreateAccount(string name, string password);
        void GiveRole(string name, string role);
        void RemoveRole(string name, string role);
        bool HasRole(string username, string roleName);
    }
}
