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
        public string AwardsFile { get; private set; } = @"E:\Studying\EPAM_Task6_Awards\Awards.txt";

        //null instead of title 
        public Award AddAward(int userId, int awardId)
        {
            string line = null;
            User user;
            Award award = null;
            List<User> users = new List<User>();

            //reading the file with users and getting the list of users
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

            //reading the file with awards and getting the one we need
            try
            {
                using (StreamReader reader = new StreamReader(AwardsFile))
                {
                    while ((line = reader.ReadLine()) != null)
                    {                       
                        award = JsonConvert.DeserializeObject<Award>(line);
                        
                        if (award.Id == awardId)
                        {
                            for (int i = 0; i < users.Count; i++)
                            {
                                if(users[i].Id == userId)
                                {                                 
                                    users[i].awards.Add(award);
                                    break;
                                }
                            }
                        }
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

        
        public User AddUser(User user)
        {
            List<User> users = new List<User>();

            string line;

            _users.Add(user.Id, user);

            using (StreamReader reader = new StreamReader(UsersFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    users.Add(JsonConvert.DeserializeObject<User>(line));
                }
                    
            }

            user.Id = users.Count > 1 ? users[users.Count - 1].Id + 1 : 1;           

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
