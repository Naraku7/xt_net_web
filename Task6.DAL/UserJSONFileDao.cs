using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task6.Dao.Interfaces;
using Task6.Entities;

namespace Task6.DAL
{
    /// <summary>
    /// DAO for Users stored in json.
    /// </summary>
    public class UserJSONFileDao : IUserDao
    {
        private static readonly Dictionary<int, User> _users = new Dictionary<int, User>();

        public string UsersFile { get; private set; } = @"E:\Studying\EPAM_Task6_Users\Users.txt";
    
        public Award AddAward(int userId, Award award)
        {
            string line = null;
            User user;
            List<User> users = new List<User>();

            //reading the file and getting the list of users
            try
            {
                using (StreamReader reader = new StreamReader(UsersFile))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        user = JsonConvert.DeserializeObject<User>(line);

                        users.Add(user);
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            //writing the users back to file with the award added
            try
            {
                using (StreamWriter writer = new StreamWriter(UsersFile))
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].Id == userId)
                        {
                            award.Id = users[i].awards.Count + 1;
                            users[i].awards.Add(award);                       
                        }

                        writer.WriteLine(JsonConvert.SerializeObject(users[i]));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return award;
        }

        //TODO: make id work the right way
        public User AddUser(User user)
        {
            var lastId = _users.Keys.Count > 0
                ? _users.Keys.Max() : 0;

            user.Id = lastId + 1;

            _users.Add(user.Id, user);

            string json = JsonConvert.SerializeObject(user);

            try
            {
                using (StreamWriter writer = new StreamWriter(UsersFile, true))
                {
                    writer.WriteLine(json);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return user;
        }
        public IEnumerable<User> GetAll()
        {
            string user = "";
            List<User> users = new List<User>();

            try
            {
                using (StreamReader reader = new StreamReader(UsersFile))
                {
                    while ((user = reader.ReadLine()) != null)
                    {
                        users.Add(JsonConvert.DeserializeObject<User>(user));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            } 
            
            return users;
        }

        public User GetById(int id)
        {
            string line = "";
            User user = null;

            try
            {
                using (StreamReader reader = new StreamReader(UsersFile))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        user = JsonConvert.DeserializeObject<User>(line);
                        
                        if(user.Id == id)
                        {
                            return user;
                        }
                    }

                    Console.WriteLine("There is no user with id {0}", id);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return user;
        }

        //public void RemoveAward(int userId, int awardId)
        //{
        //    throw new NotImplementedException();
        //}

        public void RemoveUser(int id)
        {
            string line = null;
            User user;
            List<User> users = new List<User>();

            //reading the file and getting the list of users
            try
            {
                using (StreamReader reader = new StreamReader(UsersFile))
                {
                        while ((line = reader.ReadLine()) != null)
                        {
                            user = JsonConvert.DeserializeObject<User>(line);

                            users.Add(user);
                        }
                     
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            //writing all users back except of the user we want to delete
            try
            {
                using (StreamWriter writer = new StreamWriter(UsersFile))
                {
                    foreach (var item in users)
                    {
                        if (item.Id == id)
                        {
                            continue;
                        }

                        writer.WriteLine(JsonConvert.SerializeObject(item));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
