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

            ParseInput(out input);

            BackUp(input, @"E:\Studying\EPAM_Task5_Files\", @"E:\Studying\EPAM_Task5_logs\");

            Console.Read();   
        }

        public static void ParseInput(out int input)
        {
            Console.WriteLine("Which mode do you want to use?");
            Console.WriteLine("1. Observer");
            Console.WriteLine("2. Backup");

            while (!(Int32.TryParse(Console.ReadLine(), out input) && (input == 1 || input == 2)))
            {
                Console.WriteLine("Incorrect input");
                Console.WriteLine("Try again");
            }
        }

        public static void BackUp(int input, string WorkDir, string logDir)
        {
            if (input == 1)
            {
                DateTime date = DateTime.Now;
                string logFolder = logDir + date.Day + "."
                    + date.Month + "." + date.Year + "_" + date.Hour + "h"
                    + date.Minute + "m" + date.Second + "s";

                Logger logger = new Logger(WorkDir, logDir);
                logger.Start();
            }
            else if (input == 2)
            {
                Console.WriteLine("What time do you back up?");
                Console.WriteLine("Your input must be in format day.month.year hours:minutes:seconds");

                DirectoryInfo logDirectory = new DirectoryInfo(logDir + Console.ReadLine());

                if (logDirectory.Exists)
                {
                    DirectoryInfo workDirectory = new DirectoryInfo(WorkDir);

                    //Delete every file in our working directory
                    foreach (FileInfo file in workDirectory.GetFiles())
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

                    DirectoryCopy(logDirectory.ToString(), WorkDir, true);
                }
                else
                {
                    Console.WriteLine("There is no backup for this time");
                }
            }
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
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
                string tempPath = Path.Combine(destDirName, file.Name);
                // Overwrite the files in the destination directory 
                try
                {
                    file.CopyTo(tempPath, true);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }

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
