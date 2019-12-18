using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task5
{
    //Для всех текстовых файлов (*.txt), находящихся в этой папке или вложенных подпапках,
    //реализовать сохранение истории изменений с возможностью отката состояния к любому моменту.
    class Logger
    {
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        string sourceDir;
        string logDir = @"E:\Studying\EPAM_Task5_logs\";

        public Logger()
        {
            sourceDir = @"E:\Studying\EPAM_Task5_Files";
            watcher = new FileSystemWatcher(sourceDir, "*txt");
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime; //нужно ли?

            // Add event handlers.
            watcher.Deleted += OnDeleted;
            watcher.Created += OnCreated;
            watcher.Changed += OnChanged;
        }

        public void Start()
        {
            // Begin watching.
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            // End watching.
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            //string fileEvent = "deleted";
            //string filePath = e.FullPath;
            //File.Delete(filePath);
            //RecordEntry(fileEvent, filePath);
            //DirectoryCopy(sourceDir, logDir, true);

            Thread th = new Thread(() =>
            {
                DirectoryCopy(sourceDir, logDir, true);
            });

            th.Start();

            th.Abort();

        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            //string fileEvent = "created";
            //string filePath = e.FullPath;
            //RecordEntry(fileEvent, filePath);
            //DirectoryCopy(sourceDir, logDir, true);

            Thread th = new Thread(() =>
           {
               DirectoryCopy(sourceDir, logDir, true);
           });

            th.Start();
            
            th.Abort(); //нужно ли?
            
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            //string fileEvent = "created";
            //string filePath = e.FullPath;
            //RecordEntry(fileEvent, filePath);
            //DirectoryCopy(sourceDir, logDir, true);

            Thread th = new Thread(() =>
            {
                DirectoryCopy(sourceDir, logDir, true);
            });

            th.Start();

            th.Abort(); 
        }

        //private void RecordEntry(string fileEvent, string filePath)
        //{
        //    lock (obj)
        //    {


        //        ////по идее тут нужен FSW? Или еще где-то?
        //        //using (StreamWriter writer = new StreamWriter(@"E:\Studying\EPAM_Task5_logs\log.txt", true)) //стоит убрать writer и сделать копирование файлов?
        //        //{
        //        //    //writer.WriteLine(String.Format("{0} file {1} was {2}",
        //        //    //    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
        //        //    //writer.Flush();
        //        //}
        //    }
        //}

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
                string temppath = Path.Combine(destDirName, file.Name);
                // Overwrite the files in the destination directory 
                file.CopyTo(temppath, true);
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
