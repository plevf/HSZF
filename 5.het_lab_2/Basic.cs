using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.het_lab
{
    public class FileProcessedEventArgs : EventArgs
    {
        public string FileName { get; set; }

        public FileProcessedEventArgs(string fileName)
        {
            FileName = fileName;
        }
    }

    public class FileProcessor
    {
        public event Action<string>? FileProcessed; // event fajta delegalt
        public event EventHandler<FileProcessedEventArgs>? FileProcessGeneric; // ? nullable

        public void Process(string file)
        {
            Console.WriteLine($"Processing {file}...");
            FileProcessed?.Invoke( file );
            FileProcessGeneric?.Invoke(this /*a küldő: FileProcessor*/, new FileProcessedEventArgs(file)); //ctrl shift space --> lathatjuk a tulterheleseket
        }
    }
    internal class Basic
    {
        public Basic()
        {
            var processor = new FileProcessor();

            processor.FileProcessed += f => Console.WriteLine($"Log: {f} done."); //eventnek nem lehet erteket adni

            EventHandler<FileProcessedEventArgs> auditHandler = (sender, e) => Console.WriteLine("Audit: " + e.FileName);
            processor.FileProcessGeneric += auditHandler;

            processor.Process("data1.csv");
            processor.Process("data2.csv");
            processor.FileProcessGeneric -= auditHandler;
            processor.Process("data3.csv");
        }
    }
}
