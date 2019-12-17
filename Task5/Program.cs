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

                if (DateTime.TryParse(Console.ReadLine(), out DateTime Time))
                { 
                    DirectoryInfo logDirectory = new DirectoryInfo(@"E:\Studying\EPAM_Task5_logs\" + Time.Day + "."
                    + Time.Month + "." + Time.Year + "_" + Time.Hour + "h"
                    + Time.Minute + "m" + Time.Second + "s");

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
                            catch (System.IO.IOException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                        string fileName; 
                        string destFile;

                        if (Directory.Exists(logDirectory.ToString()))
                        {
                            string[] files = Directory.GetFiles(logDirectory.ToString(), "*.txt");

                            // Copy the files and overwrite destination files if they already exist.
                            foreach (string s in files)
                            {
                                // Use static Path methods to extract only the file name from the path.
                                fileName = Path.GetFileName(s);
                                destFile = Path.Combine(filesDir, fileName);
                               File.Copy(s, destFile, true);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Source path does not exist!");
                        }

                        
                        DirectoryCopy(@"E:\Studying\EPAM_Task5_logs\", @"E:\Studying\EPAM_Task5_Files\", true);
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

        //изучи этот метод
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
