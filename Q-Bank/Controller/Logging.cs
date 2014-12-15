using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Bank.Controller
{
    class Logging
    {
        public string path = @"C:\Q-Bank\log.txt";
        public Logging()
        {
            // Specify the directory you want to manipulate. 
            string directoryPath = @"c:\Q-Bank";

            try
            {
                // Determine whether the directory exists. 
                if (!Directory.Exists(directoryPath))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(directoryPath);
                }

                string filePath = @"C:\Q-Bank\log.txt";

                if (!File.Exists(filePath))
                {
                    using (StreamWriter w = File.CreateText(filePath))
                    {
                        WriteLogging("Log file Created! ", w);
                    }
                }
            }
            catch
            {

            }
        }
        public void WriteLogging(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            //w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        public void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
