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
        //вынести потом это в отдельные методы
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
                //Create a log when we start working ??
                DateTime date = DateTime.Now;
                string logFolder = @"E:\Studying\EPAM_Task5_logs\" + date.Day + "." 
                    + date.Month + "." + date.Year + "_" + date.Hour + "h" 
                    + date.Minute + "m" + date.Second + "s";
                
                Directory.CreateDirectory(logFolder);

                Logger logger = new Logger();
            }
            else if (input == 2)
            {
                Console.WriteLine("What time do you back up?");
                Console.WriteLine("Your input must be in format day.month.year hours:minutes:seconds");

                    DirectoryInfo logDirectory = new DirectoryInfo(@"E:\Studying\EPAM_Task5_logs\" + Console.ReadLine());
                

                    //string logDir = @"E:\Studying\EPAM_Task5_logs\";
                    string filesDir = @"E:\Studying\EPAM_Task5_Files\";

                    if (logDirectory.Exists)
                    {
                        DirectoryInfo workDirectory = new DirectoryInfo(filesDir);
                        
                        //Delete every file in our working directory
                        foreach(FileInfo file in workDirectory.GetFiles())
                        {
                            try
                            {
                                file.Delete();
                            }
                            catch (System.IO.IOException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        
                        //Delete every subdirectory in our working directory
                        foreach (DirectoryInfo dir in workDirectory.GetDirectories())
                        {
                            try
                            {
                                dir.Delete(true);
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                        string fileName; 
                        string destFile;

                        //по идее, Logger.DirectoryCopy() копирует и файлы тоже

                        //if (Directory.Exists(logDirectory.ToString()))
                        //{
                        //    string[] files = Directory.GetFiles(logDirectory.ToString(), "*.txt");

                        //    // Copy the files and overwrite destination files if they already exist.
                        //    foreach (string s in files)
                        //    {
                        //        // Use static Path methods to extract only the file name from the path.
                        //        fileName = Path.GetFileName(s);
                        //        destFile = Path.Combine(filesDir, fileName);
                        //       File.Copy(s, destFile, true);
                        //    }
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Source path does not exist!");
                        //}


                        Logger.DirectoryCopy(logDirectory.ToString(), @"E:\Studying\EPAM_Task5_Files\", true);
                    }
                    else //это почему-то никогда не срабатывает
                    {
                        Console.WriteLine("There is no backup for this time");                      
                    }        
            }

            Console.Read();
      
            //using(FileSystemWatcher watcher = new FileSystemWatcher(@"E:\Studying\EPAM_Task5_Files", "*txt"))
            //{
            //    watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;


            //}


        }

        
       
    }
}
