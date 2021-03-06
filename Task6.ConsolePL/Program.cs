﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;
using Task6.Ioc;
using System.Configuration;
using Task6.BLL.Interfaces;

namespace Task6.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var userLogic = DependencyResolver.UserLogic;
            var awardLogic = DependencyResolver.AwardLogic;
            //var dao = DependencyResolver.UserDao;
            
            //var current = logic.AddUser(new User("Eugene", new DateTime(1993,02,03)));
            //logic.AddUser(new User("Ivan", new DateTime(1991, 05, 11)));

            //var settings = ConfigurationManager.AppSettings;

            //foreach (var item in settings)
            //{
            //    Console.WriteLine(item);
            //}

            int input;

            ParseInput(out input);

            Program program = new Program();
            program.ChooseMode(input, userLogic, awardLogic);

            Console.ReadLine();
        }

        private static void ParseInput(out int input)
        {
            Console.WriteLine("Which mode do you want to use?");
            Console.WriteLine("1. Watch the list of users");
            Console.WriteLine("2. Create");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Add award to user");
            Console.WriteLine("5. Create an award");

            while (!(Int32.TryParse(Console.ReadLine(), out input) && (input > 0 && input < 6)))
            {
                Console.WriteLine("Incorrect input");
                Console.WriteLine("Try again");
            }       
        }

        private void ChooseMode(int input, IUserLogic userLogic, IAwardLogic awardLogic)
        {
            if (input == 1)
            {
                Console.WriteLine("The list of users");
                foreach (var item in userLogic.GetAll())
                {
                    Console.WriteLine(item);
                }

            }
            else if (input == 2)
            {
                while (true)
                {
                    Console.WriteLine("Please insert the information about the user you want to create");
                    Console.WriteLine("Insert name:");

                    var name = Console.ReadLine();
                    bool correctName = false;

                    while (!correctName)
                    {
                        if (name.Trim().Length < 1)
                        {
                            Console.WriteLine("Name cannot be empty, try again");
                            name = Console.ReadLine();
                        }
                        else
                        {
                            correctName = true;
                        }
                    }


                    Console.WriteLine("Insert date of birth ");
                    Console.WriteLine("Your input must be in format day.month.year");

                    DateTime birthdate;

                    while (!DateTime.TryParse(Console.ReadLine(), out birthdate))
                    {
                        Console.WriteLine("Incorrect input of date");
                        Console.WriteLine("Try again");
                    }

                    userLogic.AddUser(new User(name, birthdate));
                }

            }

            else if (input == 3)
            {
                Console.WriteLine("Insert the id of the user you want to delete");

                int id;

                while (!Int32.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Incorrect input of id");
                    Console.WriteLine("Try again");
                }

                userLogic.RemoveUser(id);
            }

            else if (input == 4)
            {
                Console.WriteLine("Insert id of the user you want the award to be added to");

                int userId;

                while (!Int32.TryParse(Console.ReadLine(), out userId))
                {
                    Console.WriteLine("Incorrect input of user id");
                    Console.WriteLine("Try again");
                }

                Console.WriteLine("Insert id of the award");

                int awardId;

                while (!Int32.TryParse(Console.ReadLine(), out awardId))
                {
                    Console.WriteLine("Incorrect input of user id");
                    Console.WriteLine("Try again");
                }

                userLogic.AddAward(userId, awardId);
            }
            else if (input == 5)
            {
                Console.WriteLine("Insert the title of the award");

                var title = Console.ReadLine();
                Award award = new Award(title);
                
                awardLogic.CreateAward(award);
            }

        }

        //private void Continue(int input, IUserLogic logic)
        //{
        //    Console.WriteLine("Do you want to continue?");
        //    Console.WriteLine("1 - yes, 2 - no");

        //    int newInput;

        //    while (!(Int32.TryParse(Console.ReadLine(), out newInput) && (newInput == 1 || newInput == 2)))
        //    {
        //        Console.WriteLine("Incorrect input");
        //        Console.WriteLine("Try again");
        //    }

        //    if (newInput == 1)
        //    {
        //        ChooseMode(input, logic);
        //    }
        //    else if (newInput == 2)
        //    {

        //    }
        //}
        //private static void CreateUser()
        //{
            
        //}
        //private static void DeleteUser(int id)
        //{

        //}
        //private static void DeleteUser(string name, DateTime dateOfBirth)
        //{

        //}
        //private static void WatchUserList()
        //{

        //}

    }
}
