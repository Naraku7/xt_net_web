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
        bool enabled = true;
        string sourceDir;
        string logDir;

        public Logger(string sourceDir, string logDir)
        {
            this.sourceDir = sourceDir;
            this.logDir = logDir;
        }

        public void Start()
        {
            using (watcher = new FileSystemWatcher(sourceDir, "*.txt*"))
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
