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
    /// DAO for Users stored in .json files.
    /// </summary>
    public class UserJSONFileDao : IUserDao
    {
        public string UsersDirectory { get; private set; } = @"E:\Studying\EPAM_Task6_Users\";

        public Award AddAward(int userId, Award award)
        {
            string[] files = Directory.GetFiles(UsersDirectory);
            string fileWithUserId = null;
            string json = "";
            User user = null;

            //getting user with userId
            foreach (var file in files)
            {
                if (file.EndsWith("userId.txt"))
                    fileWithUserId = file;
            }

            if (fileWithUserId == null)
            {
                Console.WriteLine("There is no user with such ID");
            }
            else
            {
                try
                {
                    using (StreamReader reader = new StreamReader(UsersDirectory + fileWithUserId))
                    {
                        json = reader.ReadToEnd();
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }

                user = JsonConvert.DeserializeObject<User>(json);
            }

            user.CommonAmountOfAwards++;

            award.Id = user.CommonAmountOfAwards;

            user.awards.Add(award);

            //Serializing back to json
            AddUser(user);

            return award;
        }

        public User AddUser(User user)
        {
            string[] files = Directory.GetFiles(UsersDirectory);
            int[] ids = new int[files.Length];

            Regex regex = new Regex(@"*id*");

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Substring(files[i].Length - 4);
            }

            var lastId = 1;

            user.Id = lastId + 1;

            //problems with ID
            string filePath = UsersDirectory + user.Name + "_id" + user.Id + ".txt";

            string json = JsonConvert.SerializeObject(user);

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(json);
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
            string[] files = Directory.GetFiles(UsersDirectory);
            string[] jsons = new string[files.Length];

            for (int i = 0; i < jsons.Length; i++)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(files[i]))
                    {
                        jsons[i] = reader.ReadToEnd();
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
           

            User[] users = new User[files.Length];

            for (int i = 0; i < users.Length; i++)
            {
                users[i] = JsonConvert.DeserializeObject<User>(jsons[i]);
            }
            
            return users;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        //public void RemoveAward(int userId, int awardId)
        //{
        //    throw new NotImplementedException();
        //}

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
