using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Task6.BLL;

namespace Task10.Models
{
    public class UserAuthentification : IAuthentificationLogic
    {
        private Account newAccount;
        private List<Account> storedAccs = new List<Account>();
        private string AccPath = @"E:\Studying\EPAM_Task10_Accounts\Accounts.txt";
        string line = null;

        public bool CreateAccount(string name, string password)
        {
            newAccount = new Account(name, password);

            Account accFromJSON = null;

            using (StreamReader reader = new StreamReader(AccPath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    accFromJSON = JsonConvert.DeserializeObject<Account>(line);

                    if (accFromJSON != null)
                    {
                        storedAccs.Add(accFromJSON);
                    }
                }        
            }

            foreach (var acc in storedAccs)
            {
                if (acc.Name == newAccount.Name)
                {
                    return false;
                }
            }

            storedAccs.Add(newAccount);

            using (StreamWriter writer = new StreamWriter(AccPath, false))
            {
                foreach (var item in storedAccs)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(item));
                }
            }

            return true;
        }

        public void GiveRole(string name, string role)
        {
            Account accFromJSON = null;

            using (StreamReader reader = new StreamReader(AccPath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    accFromJSON = JsonConvert.DeserializeObject<Account>(line);

                    if (accFromJSON != null)
                    {
                        storedAccs.Add(accFromJSON);
                    }
                }
            }

            foreach(var acc in storedAccs)
            {
                if(acc.Name == name)
                {
                    acc.Roles.Add(role);
                }
            }

            using (StreamWriter writer = new StreamWriter(AccPath, false))
            {
                foreach (var item in storedAccs)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        public void RemoveRole(string name, string role)
        {
            Account accFromJSON = null;

            using (StreamReader reader = new StreamReader(AccPath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    accFromJSON = JsonConvert.DeserializeObject<Account>(line);

                    if (accFromJSON != null)
                    {
                        storedAccs.Add(accFromJSON);
                    }
                }
            }

            foreach (var acc in storedAccs)
            {
                if (acc.Name == name)
                {
                    acc.Roles.Remove(role);
                }
            }

            using (StreamWriter writer = new StreamWriter(AccPath, false))
            {
                foreach (var item in storedAccs)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        public List<Account> GetAccounts()
        {
            Account accFromJSON = null;

            using (StreamReader reader = new StreamReader(AccPath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    accFromJSON = JsonConvert.DeserializeObject<Account>(line);

                    if (accFromJSON != null)
                    {
                        storedAccs.Add(accFromJSON);
                    }
                }
            }

            return storedAccs;
        }

        public bool HasRole(string username, string roleName)
        {
            Account accFromJSON = null;

            using (StreamReader reader = new StreamReader(AccPath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    accFromJSON = JsonConvert.DeserializeObject<Account>(line);

                    if (accFromJSON != null)
                    {
                        storedAccs.Add(accFromJSON);
                    }
                }
            }

            foreach (var acc in storedAccs)
            {
                if (acc.Name == username)
                {
                    foreach (var role in acc.Roles)
                    {
                        if(role == "Admin")
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}