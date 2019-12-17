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

        public Logger()
        {
            watcher = new FileSystemWatcher(@"E:\Studying\EPAM_Task5_Files", "*txt");
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
            string fileEvent = "deleted";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "created";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "created";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                //по идее тут нужен FSW? Или еще где-то?
                using (StreamWriter writer = new StreamWriter(@"E:\Studying\EPAM_Task5_logs\log.txt", true)) //стоит убрать writer и сделать копирование файлов?
                {
                    
                    

                    //writer.WriteLine(String.Format("{0} file {1} was {2}",
                    //    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    //writer.Flush();
                }
            }
        }


    }
}
