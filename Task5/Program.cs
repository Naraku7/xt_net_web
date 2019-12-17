using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;

            Console.WriteLine("Which mode do you want to use?");
            Console.WriteLine("1. Observer");
            Console.WriteLine("2. Backup");

            while(!(Int32.TryParse(Console.ReadLine(), out input) && (input == 1 || input == 2)))
            {
                Console.WriteLine("Incorrect input");
                Console.WriteLine("Try again");
            }

            
            if (input == 1)
            {
                DateTime date = DateTime.Now;
                string logFoler = @"E:\Studying\EPAM_Task5_logs\" + date.Day + "." 
                    + date.Month + "." + date.Year + "_" + date.Hour + "h" 
                    + date.Minute + "m" + date.Second + "s";
                
                Directory.CreateDirectory(logFoler);

                Logger logger = new Logger();
            }
            else if (input == 2)
            {
                Console.WriteLine("What time do you back up?");
                Console.WriteLine("Your input must be in format day.month.year hours:minutes:seconds");

                if (DateTime.TryParse(Console.ReadLine(), out DateTime Time))
                { 
                    DirectoryInfo directory = new DirectoryInfo(@"E:\Studying\EPAM_Task5_logs\" + Time.Day + "."
                    + Time.Month + "." + Time.Year + "_" + Time.Hour + "h"
                    + Time.Minute + "m" + Time.Second + "s");
                    
                    if (directory.Exists)
                    {

                    }
                    else
                    {
                        Console.WriteLine("There is no backup for this time");                      
                    }
                }
            }

            Console.Read();


            //using(var stream = new FileStream(@"E:\Studying\EPAM_Task5_Files", FileMode.Append))

            //using(FileSystemWatcher watcher = new FileSystemWatcher(@"E:\Studying\EPAM_Task5_Files", "*txt"))
            //{
            //    watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;


            //}


        }
    }
}
