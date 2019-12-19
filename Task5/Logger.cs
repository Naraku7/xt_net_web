using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task5
{
    class Logger
    {
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        string sourceDir;
        string logDir = @"E:\Studying\EPAM_Task5_logs\";

        public Logger(string sourceDir)
        {
            this.sourceDir = sourceDir;            
        }

        public void Start()
        {
            using (watcher = new FileSystemWatcher(sourceDir, "*.*"))
            {
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                   | NotifyFilters.LastWrite
                                   | NotifyFilters.FileName
                                   | NotifyFilters.DirectoryName
                                   | NotifyFilters.CreationTime;
                watcher.IncludeSubdirectories = true;

                // Add event handlers.
                watcher.Deleted += OnHandler;
                watcher.Created += OnHandler;
                watcher.Changed += OnHandler;
                watcher.Renamed += OnHandler;

                // Begin watching.
                watcher.EnableRaisingEvents = true;

                while (enabled)
                {
                    Thread.Sleep(1000);
                }
            }
        }
        //public void Stop()
        //{
        //    // End watching.
        //    watcher.EnableRaisingEvents = false;
        //    enabled = false;
        //}


        private void OnHandler(object sender, FileSystemEventArgs e)
        {          
          DateTime date = DateTime.Now;

            string newDir = logDir + date.Day + "."
                    + date.Month + "." + date.Year + "_" + date.Hour + "h"
                    + date.Minute + "m" + date.Second + "s";

            Program.DirectoryCopy(sourceDir, newDir, true);
        }

       
    }
}
